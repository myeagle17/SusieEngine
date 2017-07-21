using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using UnityEngine;

namespace Susie
{

	public class SocketBase : ISocketBase
	{

		private Socket socket;
		private bool isRun;
		//连接，关闭连接，查询连接状态，接收数据，发送数据，错误代码返回
		public SocketBase(int waitTime) : base(waitTime)
		{
			Condition = SocketBaseCondition.Unconnected;
			receiveMsg = new MemoryStream();
			sendMsg = new MemoryStream();
			isRun = false;
		}

		public override void Connect()
		{
			TestDebug("Connect");
			// check condition
			if (IsConnected())
			{
				TestDebug("Connect error:socket is connected");
				return;
			}

			//异步连接,连接成功调用connectCallback方法 
			socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			Condition = SocketBaseCondition.Connected;
			try {
				socket.Connect (ipInfo);
			} catch (Exception ex) {
				Condition = SocketBaseCondition.Unconnected;
				TestDebug("connect Time out");
			}

			if (IsConnected ()) {
				socket.ReceiveTimeout = receiveTimeout;
				isRun = true;
				Thread thread = new Thread (new ThreadStart (Run));
				thread.IsBackground = true;
				thread.Start ();
			}
		}
			
		public override void Close()
		{
			TestDebug ("Close");
			if (!IsConnected())
			{
				return;
			}
			Condition = SocketBaseCondition.Unconnected;
			receiveMsg = new MemoryStream();
			sendMsg = new MemoryStream();
			socket.Shutdown(SocketShutdown.Both);
			socket.Close();
			socket = null;
			isRun = false;
		}

		public override void Send(byte[] msg)
		{
			socket.BeginSend (msg,0,msg.Length ,SocketFlags.None , new AsyncCallback(SendCallback), socket );
		}

		private void SendCallback(IAsyncResult asyncConnect)
		{
			try {
				socket.EndSend(asyncConnect);
			} catch (Exception ex) {
				Debug.LogError ("Socket send error:"+ ex);
				Close ();
			}
		}

		public override MemoryStream Receve()
		{
			return receiveMsg;
		}

		private void Run()
		{
			while (isRun)
			{

				if (!IsConnected())
				{
					break;
				}
					
				ReceiveFromServer();
			}
		}
			
		private void ReceiveFromServer()
		{
			if (!IsConnected())
			{
				TestDebug("Receive error:socket is unconnected");
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
				TestDebug("Failed to clientSocket error." + e);
				Close();
			}
		}


		private void TestDebug(string s)
		{
			//SSDebug.Log(s);
		}
	}
}