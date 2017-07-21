using UnityEngine;
using Susie;
using AppProto;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginView : SSMonoBehaviour {
	public InputField inputField;
	// Use this for initialization
	void Start () {
		AddMessage (SSSocketTool.TransMsgDefToStr (NetProtoType.MseAuth) , mseAuthProtoEventHandler);
	}
	
	// Update is called once per frame
	void Update () {
		SSSocketManager.getInstance().UpdateReceive();
	}

	void OnApplicationQuit() {
		Debug.Log("Application ending after " + Time.time + " seconds");
		SSSocketManager.getInstance ().Close ();
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

	public void onBtnDisconnect(){
		var s = SSSocketManager.getInstance ();
		s.Close ();
	}
	
	private void SendAuth(){
		MceAuth auth = new MceAuth();
		auth.id = inputField.text;
		auth.pass = "aaa";
		SSSocketManager.getInstance ().SendProto (NetProtoType.MceAuth, auth);
	}
	
	public void mseAuthProtoEventHandler(EventArgs e){
		ProtoEventArgs<MseAuth> pe = (ProtoEventArgs<MseAuth>)e;
		if (!pe.Proto.succ) {
			SSSocketManager.getInstance ().Close ();
			return;
		}

		ModelManager.user.UID = pe.Proto.uid;
		GlobalServerTime.setServerTime (pe.Proto.serverTime);
		SceneManager.LoadScene ("battle");
		// test();
	}
}
