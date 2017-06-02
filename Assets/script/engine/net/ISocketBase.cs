using System;
using System.Net;
using System.IO;

namespace Susie
{
	public enum SocketBaseCondition{
		Unconnected,
		Connected,
	}

	public abstract class ISocketBase
	{
		protected static int MAX_BUFFER_SIZE = 4096;
		protected IPEndPoint ipInfo;
		protected int waitTime;
		protected int receiveTimeout = 100;
		protected MemoryStream receiveMsg;
		protected MemoryStream sendMsg;
		protected SocketBaseCondition condition;

		public MemoryStream ReceiveMsg{
			get{
				return receiveMsg;
			}
		}

		public SocketBaseCondition Condition {
			get {
				return condition;
			}
			set {
				condition = value;
			}
		}

		public IPEndPoint IPInfo {
			get {
				return ipInfo;
			}
			set {
				ipInfo = value;
			}
		}

		//连接，关闭连接，查询连接状态，接收数据，发送数据，错误代码返回
		public ISocketBase(int waitTime){
			this.waitTime = waitTime;
		}

		public void SetIPAndPort(string ip , int port){
			IPInfo = new IPEndPoint (IPAddress.Parse(ip), port);
		}

		public bool IsConnected(){
			return Condition == SocketBaseCondition.Connected;
		}

		public int ReceiveTimeout{
			set{
				receiveTimeout = value;
			}
		}

		//interface
		public abstract void Connect ();

		public abstract void Close();

		public abstract void Send (byte[] msg);

		public abstract MemoryStream Receve ();

	}

}