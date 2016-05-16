using System;

namespace Susie
{
	// 接收发，不加心跳
	public class SSSocket
	{
		private SocketBase socketBase;
		private bool isConnected;

		public SSSocket(string ip , int port){
			socketBase = new SocketBase(5000);
			socketBase.SetIPAndPort (ip, port);
			isConnected = false;
		}

		public bool Connect(){
			socketBase.Connect();
			isConnected = socketBase.IsConnected ();
			return isConnected;
		}

		public bool IsConnected{
			get {
				return isConnected;
			}
		}

		public void SendBytes(byte[] bytes){
			socketBase.Send (bytes);
		}

		// public void SendString(string str){
		// 	byte[] bytes = Encoding.UTF8.GetBytes (str);
		// 	SendBytes (bytes);
		// }
		
		public bool IsPackValid(){
			return socketBase.ReceiveMsg != null && socketBase.ReceiveMsg.Length>0;
		}
		
		public byte[] ReadPackToByte(){
			if(!IsPackValid())return null;
			return socketBase.Receve();
		}

		public static byte[] intToByte4(int num)  {
			byte[] abyte=new byte[4]; //int为32位除4位，数组为8
			abyte[3] = (byte)(num & 0xff);
			abyte [2] = (byte)((num & 0xff00)>>8);
			abyte [1] = (byte)((num & 0xff0000)>>16);
			abyte [0] = (byte)((num & 0xff000000)>>24);
			return abyte;
		}

		public static byte[] shortToByte2(short num){
			byte[] abyte = new byte[2];
			abyte [1] = (byte)(num & 0xff);
			abyte [0] = (byte)((num & 0xff00)>>8);
			return abyte;
		}
		
		public static short byte2ToShort(byte[] bytes){
			return (short)(bytes[0]*256 + bytes[1]);
		}
		
		public static int byte4ToInt(byte[] bytes){
			return bytes[0]*16777216 + bytes[1]*65536 + bytes[2]*256 + bytes[3];
		}
	}
}