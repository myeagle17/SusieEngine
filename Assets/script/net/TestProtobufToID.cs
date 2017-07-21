using System;
using System.IO;
using Susie;
public class TestProtobufToID:IProtobufToID
{

		public static int MseAuth                  = 1001;
	public static int MseEnterGame             = 1002;
	public static int MseHeartbeat             = 1003;
	public static int MseUserInfo              = 1004;
	public static int MseSceneObjAppear        = 1005;
	public static int MseSceneObjAppearList    = 1006;
	public static int MseSceneObjMove          = 1007;
	public static int MseSceneObjMoveList      = 1008;
	public static int MseSceneObjDisappear     = 1009;
	public static int MseSceneObjDisappearList = 1010;
	// override
	public override void decode(short msgType, byte[] msgBytes)
	{
		if (msgType == NetProtoType.MseAuth) {
			ReceivePackType<AppProto.MseAuth> (msgType, msgBytes);
		}
		else if (msgType == NetProtoType.MseEnterGame) {
			ReceivePackType<AppProto.MseEnterGame> (msgType, msgBytes);
		}
		else if (msgType == NetProtoType.MseHeartbeat) {
			ReceivePackType<AppProto.MseHeartbeat> (msgType, msgBytes);
		}
		else if (msgType == NetProtoType.MseUserInfo) {
			ReceivePackType<AppProto.MseUserInfo> (msgType, msgBytes);
		}
		else if (msgType == NetProtoType.MseSceneObjAppear) {
			ReceivePackType<AppProto.MseSceneObjAppear> (msgType, msgBytes);
		}
		else if (msgType == NetProtoType.MseSceneObjAppearList) {
			ReceivePackType<AppProto.MseSceneObjAppearList> (msgType, msgBytes);
		}
		else if (msgType == NetProtoType.MseSceneObjMove) {
			ReceivePackType<AppProto.MseSceneObjMove> (msgType, msgBytes);
		}
		else if (msgType == NetProtoType.MseSceneObjMoveList) {
			ReceivePackType<AppProto.MseSceneObjMoveList> (msgType, msgBytes);
		}
		else if (msgType == NetProtoType.MseSceneObjAppearList) {
			ReceivePackType<AppProto.MseSceneObjDisappear> (msgType, msgBytes);
		}
		else if (msgType == NetProtoType.MseSceneObjAppearList) {
			ReceivePackType<AppProto.MseSceneObjDisappearList> (msgType, msgBytes);
		}		
		else{
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
