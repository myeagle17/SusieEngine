using UnityEngine;
using System.Collections;
using Susie;
using System;
using AppProto;

public class UserNode : ASceneNode {
	private MoveControl moveControl;
	// Use this for initialization
	void Start () {
		moveControl = new MoveControl(this);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void UpdateBySceneObjRunning(MseSceneObjMove sceneObj){
		base.UpdateBySceneObjRunning(sceneObj);
		moveControl.UpdateBySceneObjMove(sceneObj);
	}
}
