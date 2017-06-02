using System;
using System.IO;
using Susie;
public class TestProtobufToID:IProtobufToID
{
	// override
	public override void decode(short msgType, byte[] msgBytes)
	{
		if (msgType == NetMsgDef.MseAuth) {
			ReceivePackType<AppProto.MseAuth> (msgType, msgBytes);
		} else{
			SSDebug.Log("unkown msgType = " + msgType);
		}
	}
	private void ReceivePackType<T>(short msgType , byte[] msgBytes)
	{
		MemoryStream ms = new MemoryStream(msgBytes);
		T t = ProtoBuf.Serializer.Deserialize<T>(ms);
		ProtoEventArgs<T> eventArgs = new ProtoEventArgs<T>();
		eventArgs.Proto = t;
		eventArgs.MsgID = msgType;
		MessageManager.GetIncestance().SendMessage(SSSocketTool.TransMsgDefToStr(msgType) , eventArgs);
	}
}
