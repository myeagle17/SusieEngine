using System;
using System.IO;
using ProtoBuf;
using System.Diagnostics;


namespace Susie
{
	// 接收发，不加心跳
	public class SSSocketManager
	{
		private bool isDebug = false;

		private static SSSocketManager ince = null;

		private ISocketBase socketBase;

		private IProtobufToID protobufToID;

		private MemoryStream bufferReceiveMs;

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
			socketBase.SetIPAndPort("192.168.105.175", 2002);
			// 
			bufferReceiveMs = new MemoryStream();
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
			// check connected
			if (!IsConnected()) return false;
			// ready bytes frome socketBase
			var receiveMs = socketBase.Receve();
			lock (receiveMs)
			{
				var receiveBytes = receiveMs.ToArray ();
				bufferReceiveMs.Write (receiveBytes , 0 , receiveBytes.Length);
				receiveMs.SetLength (0);
			}
				
			// decode bytes
			return DecodeBytes ();
		}

		public Boolean DecodeBytes()
		{			
			short msgType;
			byte[] msgBytes;
			int lengthOfLeftBytes = 0;
			var pos = bufferReceiveMs.Position;
			bufferReceiveMs.Seek(0, SeekOrigin.Begin);
			// check int length
			if (bufferReceiveMs.Length < 4)
			{
				bufferReceiveMs.Position = pos;
				return false;
			}
			// read pack length
			var tempBytes = new byte[4];
			bufferReceiveMs.Read(tempBytes, 0, 4);
			bufferReceiveMs.Position = 4;
			var packLength = SSSocketTool.byte4ToInt(tempBytes);
			DebugPrint ("packLength = " + packLength);
			// check length
			if (bufferReceiveMs.Length < packLength + 4)
			{
				bufferReceiveMs.Position = pos;
				return false;
			}
			// msgType
			bufferReceiveMs.Read(tempBytes, 0, 2);
			bufferReceiveMs.Position = 6;
			msgType = SSSocketTool.byte2ToShort(tempBytes);
			// magic num
			bufferReceiveMs.Read(tempBytes, 0, 4);
			bufferReceiveMs.Position = 10;
			int magicNum = SSSocketTool.byte4ToInt(tempBytes);
			DebugPrint ("magicNum = " + magicNum);
			// protobuf
			msgBytes = new byte[packLength - 6];
			bufferReceiveMs.Read(msgBytes, 0, msgBytes.Length);
			DebugPrint ("receive msgType:"+msgType);
			DebugPrint ("receive msgBytes = " + msgBytes.Length);
			
			if(null != protobufToID){
				protobufToID.decode(msgType , msgBytes);
			}

			var sumOfReadBytes = 10 + msgBytes.Length;
			// left
			lengthOfLeftBytes = (int)bufferReceiveMs.Length - sumOfReadBytes;
			if(lengthOfLeftBytes>0){
				bufferReceiveMs.Position = sumOfReadBytes;
				msgBytes = new byte[lengthOfLeftBytes];
				bufferReceiveMs.Read(msgBytes , 0 , lengthOfLeftBytes);
				bufferReceiveMs.SetLength(0);
				bufferReceiveMs.Write(msgBytes , 0 , lengthOfLeftBytes);
			}else{
				// reset receiveMs
				bufferReceiveMs.SetLength(0);
			}
			// if left then receive too
			if(lengthOfLeftBytes>0){
				return DecodeBytes();
			}else{
				return true;
			}
		}

		private void DebugPrint(String msg){
			if (isDebug) {
				SSDebug.Log (msg);
			}
		}
	}
}