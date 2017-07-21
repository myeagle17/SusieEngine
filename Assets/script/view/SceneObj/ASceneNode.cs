using UnityEngine;
using System.Collections;
using Susie;
using System;
using AppProto;

public class ASceneNode : SSMonoBehaviour {
	public int SCALE = 60;
	private string uid = "";
	public string UID {
		get{
			return uid;
		}

		set{
			uid = value;
		}
	}
    protected float speed = 0.0f;
    protected float degreeSpeed = 0.0f;
	public virtual void Appear(MseSceneObjAppear objAppear){
		UID = objAppear.uid;
        setPos(objAppear.x/SCALE,objAppear.y/SCALE);
        setDegree(objAppear.degree);
        degreeSpeed = objAppear.degreeSpeed;
        speed = objAppear.speed;
	}

	public virtual void Disappear(){
		UID = "";
		RemoveAllMessage ();
	}

	public virtual void UpdateBySceneObjRunning(MseSceneObjMove sceneObj){
        // Do nothing
		
    }

    private void setPos(float x , float y){
		transform.localPosition = new Vector2(x,y);
    }

    private void setDegree(float degree){
        SSDebug.Log("TODO setDegree");
    }
}
