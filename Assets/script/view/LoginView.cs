﻿using UnityEngine;
using LitJson;
using Susie;
using AppProto;
using System;

public class LoginView : MonoBehaviour {

	// Use this for initialization
	void Start () {
		MessageManager.GetIncestance().Add(NetMsgProtoConfig.TransMsgDefToStr(NetMsgDef.MseAuth) , mseAuthProtoEventHandler);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void onBtnLogin(){
		// AppNetManager netManager = AppNetManager.getInceStance();
		// bool isConnected = netManager.Connect();
		// if(isConnected){
		// 	SSDebug.Log("sendAuth");
		// 	SendAuth();
		// }
		
		testTileMap();	
	}
	
	public void testTileMap(){
		string src = Application.streamingAssetsPath + "/desert.json";
		SSDebug.Log("src = " + src);
		SSTileMap map = new SSTileMap(src);
		JsonData data = map.Info.getPropertyByTileID(12);
		string type = SSJsonTool.getStringValue_json (data , "type");
		int a = 3;
	}
	
	private void SendAuth(){
		MceAuth auth = new MceAuth();
		auth.id = "aaa";
		auth.pass = "aaa";
		AppNetManager.getInceStance().SendProto<MceAuth>(NetMsgDef.MceAuth,auth);
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
