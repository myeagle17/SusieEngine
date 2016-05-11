using System;
using UnityEngine;
using UnityEngine.Assertions;
using Susie;

public class AppNetManager
{
	private static AppNetManager Ince;

	private SSSocket susieSocket;

	private string name = "aaa";
	private string password = "aaa";
	private string ip = "192.168.6.89";
	private int port = 1443;

	public AppNetManager getInceStance (){
		if (Ince == null) {
			Ince = new AppNetManager ();
		}
		return Ince;
	}

	private AppNetManager(){
		susieSocket = new SSSocket (ip, port);
	}

	public bool Connect(){
		return susieSocket.Connect ();
	}

	public bool isConnected(){
		return susieSocket.IsConnected;
	}
		
	public void Login(string name , string password)
	{
		Assert.IsTrue (isConnected ());
		this.name = name;
		this.password = password;
		susieSocket.SendString ("a," + name + "," + password);
	}






}
