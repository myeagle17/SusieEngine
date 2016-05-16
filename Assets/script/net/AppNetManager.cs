using System.IO;
using Susie;
using ProtoBuf;

public class AppNetManager
{
	private static AppNetManager Ince;
	private SSSocket susieSocket;
	private MemoryStream receiveMemoryStream;
	
	private string name = "aaa";
	private string password = "aaa";
	private string ip = "192.168.6.89";
	private int port = 1443;
	
	public static AppNetManager getInceStance (){
		if (Ince == null) {
			Ince = new AppNetManager ();
		}
		return Ince;
	}

	private AppNetManager(){
		susieSocket = new SSSocket (ip, port);
		receiveMemoryStream = new MemoryStream();
	}

	public bool Connect(){
		return susieSocket.Connect ();
	}

	public bool isConnected(){
		return susieSocket.IsConnected;
	}
		
	public void Login(string name , string password)
	{
		// Assert.IsTrue (isConnected ());
		// this.name = name;
		// this.password = password;
		// susieSocket.SendString ("a," + name + "," + password);
	}
	
	public void SendProto<T>(int msgDef , T ins){
		MemoryStream ms = new MemoryStream();
		try
		{
			Serializer.Serialize<T>(ms , ins);
			byte[] msgBytes = ms.ToArray();
			MemoryStream msgSend = new MemoryStream();
			
			// total length
			short length = (short)(msgBytes.Length + 6);
			msgSend.Write(SSSocket.shortToByte2(length),0,2);
		
			// msgDef
			msgSend.Write(SSSocket.shortToByte2((short)msgDef),0,2);
						
			// magic num
			msgSend.Write(SSSocket.intToByte4(1),0,4);
			
			// msgBytes
			msgSend.Write(msgBytes,0,msgBytes.Length);
			
			// send
			susieSocket.SendBytes(msgSend.ToArray());
	
		}
		catch (System.Exception)
		{
			SSDebug.Log("SendProto error");
		}
	}
	
	public void ReceiveAndDeliverMsg(){
		// check pack is valid
		if(!susieSocket.IsPackValid())return;
		
		// add to buffer
		byte[] receiveBytes = susieSocket.ReadPackToByte();
		receiveMemoryStream.Seek(0,SeekOrigin.End);
		receiveMemoryStream.Write(receiveBytes,0,receiveBytes.Length);
		
		// debug
		if (AppDebug.Net){
			SSDebug.Log("=================ReceiveAndDeliverMsg begin:");
		}
		
		// read
		while(true){
			receiveMemoryStream.Seek(0,SeekOrigin.Begin);
			// read length
			byte[] lengthBytes = new byte[2];
			int tempReadLength = receiveMemoryStream.Read(lengthBytes,0,2);
			if(tempReadLength<2){
				break;
			}
			
			short length = SSSocket.byte2ToShort(lengthBytes);
			if(AppDebug.Net){
				SSDebug.Log("length = "+length);
			}
			// read msgDef
			byte[] msgDefBytes = new byte[2];
			tempReadLength = receiveMemoryStream.Read(msgDefBytes,0,2);
			if(tempReadLength<2){
				break;
			}
			short msgDef = SSSocket.byte2ToShort(msgDefBytes);
			
			// skip magic num
			byte[] magicNumBytes = new byte[4];
			tempReadLength = receiveMemoryStream.Read(magicNumBytes , 0 ,4);
			if(tempReadLength<4){
				break;
			}
			int magicNum = SSSocket.byte4ToInt(magicNumBytes);
			// pack
			short msgLength = (short)(length - 6);
			byte[] msgBytes = new byte[msgLength];
			tempReadLength = receiveMemoryStream.Read(msgBytes , 0 , msgLength);
			if(tempReadLength < msgLength){
				break;
			}
			
			// sendPack
			ReceivePack(msgDef , msgBytes);
			
			// clear used bytes
			long rest = receiveMemoryStream.Length - receiveMemoryStream.Position;
			MemoryStream memoryStreamNew = new MemoryStream();
			if(rest>0){
				byte[] leftBytes =new byte[rest];
				receiveMemoryStream.Read(leftBytes , 0 , (int)rest);
				memoryStreamNew.Write(leftBytes,0,(int)rest);
			}
			receiveMemoryStream = memoryStreamNew;
		}
		if (AppDebug.Net){
			SSDebug.Log("=================ReceiveAndDeliverMsg end:");
		}
	}

	private void ReceivePack(short msgDef , byte[] packs){		
		if(msgDef == NetMsgDef.MseAuth)
		{
			ReceivePackType<AppProto.MseAuth>(msgDef , packs);
		}
		else if(msgDef == NetMsgDef.MseSceneObj)
		{
			ReceivePackType<AppProto.MseSceneObj>(msgDef , packs);
		}
		else if(msgDef == NetMsgDef.MseMove)
		{
			ReceivePackType<AppProto.MseMove>(msgDef , packs);
		}
		else if(msgDef == NetMsgDef.MsePoshort)
		{
			//ReceivePackType<AppProto.MsePoshort>(msgDef , packs);
		}
		else if(msgDef == NetMsgDef.MseUserInfo)
		{
			SSDebug.Log("userInfo send");
			ReceivePackType<AppProto.MseUserInfo>(msgDef , packs);
		}	
		else{
			//SSDebug.Log("ReceivePack error , can't find msgDef:" + msgDef);
		}
	}
	
	private void ReceivePackType<T>(short msgDef , byte[] packs){
		MemoryStream ms = new MemoryStream(packs);
		T t = ProtoBuf.Serializer.Deserialize<T>(ms);
		ProtoEventArgs<T> eventArgs = new ProtoEventArgs<T>();
		eventArgs.Proto = t;
		eventArgs.MsgID = msgDef;
		MessageManager.GetIncestance().SendMessage(NetMsgProtoConfig.TransMsgDefToStr(msgDef) , eventArgs);
	}
}
