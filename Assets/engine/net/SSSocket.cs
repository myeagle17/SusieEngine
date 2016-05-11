using System;
using System.Text;

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
			short length = (short)bytes.Length;
			socketBase.Send (shortToByte4(length));
			socketBase.Send (bytes);
		}

		public void SendString(string str){
			byte[] bytes = Encoding.UTF8.GetBytes (str);
			SendBytes (bytes);
		}

		public static byte[] intToByte4(int Num)  {
			byte[] abyte=new byte[8]; //int为32位除4位，数组为8
			int j=0xf; 
			int z = 4; //转换的位数 
			for (int i = 0; i < 8; i++)
			{
				int y = j << z * i;
				int x = Num & y;
				x = x >> (z * i);
				abyte[i] = (byte)(x);
			}
			return abyte;
		}

		public static byte[] shortToByte4(short num){
			byte[] abyte = new byte[4];
			abyte [0] = (byte)(num & 0x000f);
			abyte [1] = (byte)((num & 0x00f0)>>4);
			abyte [2] = (byte)((num & 0x0f00)>>8);
			abyte [3] = (byte)((num & 0xf000)>>12);
			return abyte;
		}

	}
}