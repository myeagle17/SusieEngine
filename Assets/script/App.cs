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
		//testReadProto ();	
	}
	
	// Update is called once per frame
	void Update () {
		AppNetManager.getInceStance().ReceiveAndDeliverMsg();
	}

	// private void testWriteProto(){
	// 	SSDebug.Log ("testProto");
	// 	MceAuth.MceAuth aa = new MceAuth.MceAuth ();
	// 	aa.id = "aaa";
	// 	aa.pass = "hello";
	// 	FileStream stream = new FileStream("hello.dat" ,FileMode.OpenOrCreate ,  FileAccess.Write);
	// 	Serializer.Serialize<MceAuth.MceAuth>(stream , aa);
	// 	stream.Close();
	// 	SSDebug.Log (aa.ToString());
	// }
	
	// private void testReadProto(){
	// 	SSDebug.Log ("testProto");
	// 	FileStream stream = new FileStream("hello1.dat" ,FileMode.Open,  FileAccess.Read);
	// 	MceAuth.MceAuth aa = Serializer.Deserialize<MceAuth.MceAuth>( stream);
	// 	stream.Close();
	// 	SSDebug.Log (aa.pass + aa.id);
	// }
}
