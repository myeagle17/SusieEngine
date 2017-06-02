using UnityEngine;
using System.Collections;
using Susie;
using ProtoBuf;
using System.IO;

public class App : MonoBehaviour {
	[RuntimeInitializeOnLoadMethod]
	static void Initialize()
	{
		Engine.Init ();
		GlobalData.Init();
		
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		SSSocketManager.getInstance().UpdateReceive();
	}
}
