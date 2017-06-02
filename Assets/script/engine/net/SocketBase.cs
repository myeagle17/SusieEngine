using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace Susie
{

	public class SocketBase : ISocketBase
	{

		private Socket socket;

		//连接，关闭连接，查询连接状态，接收数据，发送数据，错误代码返回
		public SocketBase(int waitTime) : base(waitTime)
		{
			Condition = SocketBaseCondition.Unconnected;
			receiveMsg = new MemoryStream();
			sendMsg = new MemoryStream();
			socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
		}

		public override void Connect()
		{
			// check condition
			if (IsConnected())
			{
				Debug("Connect error:socket is connected");
				return;
			}

			//异步连接,连接成功调用connectCallback方法  
			IAsyncResult result = socket.BeginConnect(IPInfo, new AsyncCallback(ConnectCallback), socket);
		}

		private void ConnectCallback(IAsyncResult asyncConnect)
		{
			if (socket.Connected)
			{
				socket.ReceiveTimeout = receiveTimeout;
				//与socket建立连接成功，开启线程接受服务端数据。  
				Condition = SocketBaseCondition.Connected;
				Thread thread = new Thread(new ThreadStart(Run));
				thread.IsBackground = true;
				thread.Start();
			}
			else
			{
				Close();
				Debug("connect Time out");
			}
		}

		public override void Close()
		{
			Debug("Close");
			if (!IsConnected())
			{
				Debug("Close error:socket is unconnected");
				return;
			}
			Condition = SocketBaseCondition.Unconnected;
			receiveMsg = new MemoryStream();
			sendMsg = new MemoryStream();
			socket.Shutdown(SocketShutdown.Both);
			socket.Close();
		}

		public override void Send(byte[] msg)
		{
			lock (sendMsg)
			{
				sendMsg.Write(msg, 0, msg.Length);
			}
		}

		public override MemoryStream Receve()
		{
			return receiveMsg;
		}

		private void Run()
		{
			while (true)
			{

				if (!IsConnected())
				{
					break;
				}

				// send
				lock (sendMsg)
				{
					if (sendMsg.Length > 0)
					{
						Debug("send:" + sendMsg.ToString());
						SendToServer(sendMsg.ToArray());
						sendMsg = new MemoryStream();
					}
				}

				ReceiveFromServer();
			}
		}


		private void SendToServer(byte[] msg)
		{
			Debug("sendToServer");
			if (!IsConnected())
			{
				Debug("Send error:socket is unconnected");
				return;
			}

			try
			{
				socket.Send(msg);
			}
			catch (Exception e)
			{
				Debug("send message error");
				Debug(e.ToString());
				Close();
			}
		}

		private void ReceiveFromServer()
		{
			if (!IsConnected())
			{
				Debug("Receive error:socket is unconnected");
				return;
			}
			try
			{
				if (socket.Available <= 0) return;
				//接受数据保存至bytes当中  
				byte[] bytes = new byte[MAX_BUFFER_SIZE];
				//Receive方法中会一直等待服务端回发消息  
				//如果没有回发会一直在这里等着。
				int i = socket.Receive(bytes);
				if (i > 0)
				{
					lock (receiveMsg)
					{
						receiveMsg.Write(bytes, 0, i);
					}
				}
			}
			catch (Exception e)
			{
				Debug("Failed to clientSocket error." + e);
				Close();
			}
		}


		private void Debug(string s)
		{
			SSDebug.Log(s);
		}
	}
}