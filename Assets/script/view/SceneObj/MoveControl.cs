using System;
using UnityEngine;
using Susie;
using AppProto;

public class MoveControl
{
	private ASceneNode sceneNode;
	private BasicAction[] currentActions;
    private BasicAction currentActionMove;
    private BasicAction currentActionRotate;
    private BasicAction currentActionMoveAndRotate;

	
	public MoveControl(ASceneNode sceneNode) {
		this.sceneNode = sceneNode;	
        currentActions = new BasicAction[4];
        SetStateStop();
	}

	public void UpdateBySceneObjMove(MseSceneObjMove sceneObj){
		UnityEngine.Debug.Log("scneMove = "+ sceneObj.status);
		// 首先停止
		SetStateStop();
		if (sceneObj.status == E_SceneObjMoveS.STOP)
		{
			return;
		}

		DoMove(sceneObj);
		DoRotate(sceneObj);
		if (sceneObj.status == E_SceneObjMoveS.MOVE_AND_ROTATE){
			DoMoveAndRotate(sceneObj);
		}
	}

    private void SetStateStop(){
		for (int i = 0; i < currentActions.Length; i++)
		{
			if(currentActions[i] != null){
				currentActions[i].IsDelete = true;
				currentActions[i] = null;
			}
		}
	}

    private void DoMove(MseSceneObjMove sceneObj){
		var targetPos = new Vector3(sceneObj.posX/sceneNode.SCALE , sceneObj.posY/sceneNode.SCALE , 0);
		var lastTime = GlobalServerTime.getLastTime(sceneObj.endTime);
		UnityEngine.Debug.Log("lastTime = " + lastTime +"," + sceneObj.posX + "," +  sceneObj.posY);
		var tempAction = new MoveToAction(targetPos, lastTime/1000);
		ActionManager.GetInstance().RunAction(sceneNode, tempAction, null);
		currentActions[(int)E_SceneObjMoveS.MOVE] = tempAction;
	}

	private void DoRotate(MseSceneObjMove sceneObj){
		
	}
	
	private void DoMoveAndRotate(MseSceneObjMove sceneObj){
		
	}

}