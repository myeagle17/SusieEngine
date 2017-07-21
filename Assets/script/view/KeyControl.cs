using UnityEngine;
using System.Collections;
using AppProto;
using Susie;

public class KeyControl
{
	private E_DIR dir;
	private bool isMove;
	
	public void Reset(){
		dir = E_DIR.CENTER;
		isMove = false;
	}

	public void Update(){
		var tempDir = dir;
		var tempIsMove = isMove;
        if (Input.GetKey(KeyCode.A))
        {
            tempDir = E_DIR.LEFT;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            tempDir = E_DIR.RIGHT;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            tempIsMove = true;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            tempIsMove = false;
        }
        ChangeAndSend(tempDir , tempIsMove);
	}

	private void ChangeAndSend(E_DIR dir , bool isMove){
		bool isChange = false;
		if(this.dir != dir){
			this.dir = dir;
			isChange = true;
		}

		if(this.isMove != isMove){
			this.isMove = isMove;
			isChange = true;
		}

		if(isChange){
			MceControl msg = new MceControl();
        	msg.dir = dir;
			msg.isMove = isMove;
			SSDebug.Log("send isMove = "+msg.isMove);
			SSSocketManager.getInstance().SendProto(NetProtoType.MceControl, msg);
		}
	}
}

