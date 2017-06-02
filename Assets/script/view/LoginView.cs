using UnityEngine;
using Susie;
using AppProto;
using System;

public class LoginView : SSMonoBehaviour {

	// Use this for initialization
	void Start () {
		AddMessage (SSSocketTool.TransMsgDefToStr (NetMsgDef.MseAuth) , mseAuthProtoEventHandler);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		
	public void onBtnLogin(){
		var s = SSSocketManager.getInstance ();
		s.SetIP("127.0.0.1", 1443);
		s.SetProtobufToID (new TestProtobufToID());
		s.Connect();
		if (s.IsConnected ()) {
			SendAuth ();
		}
	}
	
	private void SendAuth(){
		MceAuth auth = new MceAuth();
		auth.id = "aaa";
		auth.pass = "aaa";
		SSSocketManager.getInstance ().SendProto (NetMsgDef.MceAuth, auth);
	}
	
	public void mseAuthProtoEventHandler(EventArgs e){
		SSDebug.Log("receive");
		ProtoEventArgs<MseAuth> pe = (ProtoEventArgs<MseAuth>)e;
		SSDebug.Log("msgID = "+pe.MsgID);
		SSDebug.Log("uid = "+pe.Proto.uid);
		SSDebug.Log("name = "+pe.Proto.name);
		SSDebug.Log("suc = "+pe.Proto.succ);
	}
}
