using UnityEngine;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using UnityEngine.Assertions;
using System.IO;

namespace Susie{
	public enum SocketBaseCondition{
		Unconnected,
		Connected,
	}

	public class SocketBase
	{
		private static int MAX_BUFFER_SIZE = 4096;
		private IPEndPoint ipInfo;
		private int waitTime;
		private MemoryStream receiveMsg;
		private MemoryStream sendMsg;
		private SocketBaseCondition condition;
		private Socket socket;

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
		public SocketBase(int waitTime){
			this.waitTime = waitTime;
			socket = new Socket (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			Condition = SocketBaseCondition.Unconnected;
			receiveMsg = new MemoryStream ();
			sendMsg = new MemoryStream ();
		}

		public void SetIPAndPort(string ip , int port){
			IPInfo = new IPEndPoint (IPAddress.Parse(ip), port);
		}
			
		public void Connect (){
			// check condition
			if (IsConnected()) {
				Debug("Connect error:socket is connected");
				return;
			}

			//异步连接,连接成功调用connectCallback方法  
			IAsyncResult result = socket.BeginConnect(IPInfo, new AsyncCallback(ConnectCallback), socket);  

			//这里做一个超时的监测，当连接超过5秒还没成功表示超时  
			bool success = result.AsyncWaitHandle.WaitOne(waitTime, true);  
			if (!success)  
			{  
				//超时  
				Close();  
				Debug("connect Time Out");  
			}  
			else  
			{  
				//与socket建立连接成功，开启线程接受服务端数据。  
				Condition = SocketBaseCondition.Connected;
				Thread thread = new Thread(new ThreadStart(Run));  
				thread.IsBackground = true;  
				thread.Start();  
			}  
		}

		private void ConnectCallback(IAsyncResult asyncConnect)  
		{  
			Debug("connect success");  
		}  
			
		public void Close(){
			if (!IsConnected ()) {
				Debug ("Close error:socket is unconnected");
				return;
			}
			Condition = SocketBaseCondition.Unconnected;
			receiveMsg = new MemoryStream ();
			sendMsg = new MemoryStream ();
			socket.Shutdown (SocketShutdown.Both);
			socket.Close();
		}
			
		public bool IsConnected(){
			return Condition == SocketBaseCondition.Connected;
		}

		public void Send (byte[] msg){
			lock (sendMsg) {
				sendMsg.Write(msg,0,msg.Length);
			}
		}

		public byte[] Receve(){	
			lock (sendMsg) {
				byte[] result = sendMsg.ToArray ();
				sendMsg = new MemoryStream ();
				return result;
			}
		}

		private void Run(){
			while (true) {
				if (!IsConnected ()) {
					Close ();
					break;
				}

				// send
				lock (sendMsg) {
					if (sendMsg.Length > 0) {
						SendToServer (sendMsg.ToArray());
						sendMsg = new MemoryStream ();
					}
				}
				// receive
				ReceiveFromServer();
			}
		}

		private void SendToServer (byte[] msg){
			if (!IsConnected ()) {
				Debug ("Send error:socket is unconnected");
				return;
			}

			try  
			{  
				socket.Send(msg);
			}  
			catch(Exception e)  
			{  
				Debug("send message error");  
				Debug (e.ToString());
				Close ();
			}
		}

		private void ReceiveFromServer(){
			if (!IsConnected ()) {
				Debug ("Receive error:socket is unconnected");
				return;
			}

			try  
			{  
				//接受数据保存至bytes当中  
				byte[] bytes = new byte[MAX_BUFFER_SIZE];  
				//Receive方法中会一直等待服务端回发消息  
				//如果没有回发会一直在这里等着。
				int i = socket.Receive(bytes);  
				if (i <= 0)  
				{  
					Close();
				}else{
					lock(receiveMsg){
						receiveMsg.Write(bytes , 0 , i);
					}
				}
			}  
			catch (Exception e)  
			{  
				Debug("Failed to clientSocket error." + e);  
				Close ();
			}  
		}


		private void Debug(string s){
			SSDebug.Log(s);
		}
	}
}