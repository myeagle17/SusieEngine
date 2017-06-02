using System;
using System.IO;
using ProtoBuf;


namespace Susie
{
	// 接收发，不加心跳
	public class SSSocketManager
	{
		private static SSSocketManager ince = null;

		private ISocketBase socketBase;

		private IProtobufToID protobufToID;

		public static SSSocketManager getInstance()
		{
			if (null == ince)
			{
				ince = new SSSocketManager();
			}
			return ince;
		}

		private SSSocketManager()
		{
			socketBase = new SocketBase(5000);
			// default ip address
			socketBase.SetIPAndPort("127.0.0.1", 2002);
		}

		public void SetIP(string ip, int port)
		{
			socketBase.SetIPAndPort(ip, port);
		}

		public void SetProtobufToID(IProtobufToID protobufToID){
			this.protobufToID = protobufToID;
		}

		public bool Connect()
		{
			socketBase.Connect();
			return socketBase.IsConnected();
		}

		public bool IsConnected()
		{
			return socketBase.IsConnected();
		}

		public void Close()
		{
			if (IsConnected())
			{
				socketBase.Close();
			}
		}

		public void SendProto<T>(int msgDef, T ins)
		{
			MemoryStream ms = new MemoryStream();
			try
			{
				Serializer.Serialize(ms, ins);
				byte[] msgBytes = ms.ToArray();
				ms.SetLength(0);

				// total length
				short length = (short)(msgBytes.Length + 6);

				ms.Write(SSSocketTool.shortToByte2(length), 0, 2);

				// msgDef
				ms.Write(SSSocketTool.shortToByte2((short)msgDef), 0, 2);

				// magic num
				ms.Write(SSSocketTool.intToByte4(1), 0, 4);

				// msgBytes
				ms.Write(msgBytes, 0, msgBytes.Length);

				// send
				socketBase.Send(ms.ToArray());
			}
			catch (System.Exception)
			{
				SSDebug.Log("SendProto error");
			}
		}

		public Boolean UpdateReceive()
		{
			if (!IsConnected()) return false;
			
			short msgType;
			byte[] msgBytes;
			var receiveMs = socketBase.Receve();
			lock (receiveMs)
			{
				var pos = receiveMs.Position;
				receiveMs.Seek(0, SeekOrigin.Begin);
				// check int length
				if (receiveMs.Length < 4)
				{
					receiveMs.Position = pos;
					return false;
				}
				// read pack length
				var tempBytes = new byte[4];
				receiveMs.Read(tempBytes, 0, 4);
				receiveMs.Position = 4;
				var packLength = SSSocketTool.byte4ToInt(tempBytes);
				// check length
				if (receiveMs.Length < packLength + 4)
				{
					receiveMs.Position = pos;
					return false;
				}
				// msgType
				receiveMs.Read(tempBytes, 0, 2);
				receiveMs.Position = 6;
				msgType = SSSocketTool.byte2ToShort(tempBytes);
				// magic num
				receiveMs.Read(tempBytes, 0, 4);
				receiveMs.Position = 10;
				int magicNum = SSSocketTool.byte4ToInt(tempBytes);
				// protobuf
				msgBytes = new byte[packLength - 6];
				receiveMs.Read(msgBytes, 0, msgBytes.Length);
				// reset receiveMs
				receiveMs.SetLength(0);
			}
			if(null != protobufToID)
				protobufToID.decode(msgType , msgBytes);
			return true;
		}
	}
}