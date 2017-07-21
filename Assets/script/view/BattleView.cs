using UnityEngine;
using System.Collections;
using Susie;
using AppProto;
using System;
using System.Collections.Generic;
using UnityEngine.Assertions;

public class BattleView : SSMonoBehaviour
{
    public GameObject userPrefab;
	public GameObject userParentObj;
    private Dictionary<String, UserNode> userNodeDic;

    private KeyControl keyControl;

    // Use this for initialization
    void Start()
    {
        userNodeDic = new Dictionary<string, UserNode>();

        AddMessage(SSSocketTool.TransMsgDefToStr(NetProtoType.MseEnterGame), mseEnterGameProtoEventHandler);
        AddMessage(SSSocketTool.TransMsgDefToStr(NetProtoType.MseSceneObjAppear), mseSceneObjAppearProtoEventHandler);
        AddMessage(SSSocketTool.TransMsgDefToStr(NetProtoType.MseSceneObjAppearList), mseSceneObjAppearListProtoEventHandler);
        AddMessage(SSSocketTool.TransMsgDefToStr(NetProtoType.MseSceneObjMove), mseSceneObjMoveProtoEventHandler);
        AddMessage(SSSocketTool.TransMsgDefToStr(NetProtoType.MseSceneObjMoveList), mseSceneObjMoveListProtoEventHandler);
        AddMessage(SSSocketTool.TransMsgDefToStr(NetProtoType.MseSceneObjDisappear), mseSceneObjDisappearProtoEventHandler);
        AddMessage(SSSocketTool.TransMsgDefToStr(NetProtoType.MseSceneObjDisappearList), mseSceneObjDisappearListProtoEventHandler);

        sendEnterGame();

        keyControl = new KeyControl ();
        keyControl.Reset();
    }

    // Update is called once per frame
    void Update()
    {
        SSSocketManager.getInstance().UpdateReceive();
        keyControl.Update();
        ActionManager.GetInstance().Update();
    }

    void OnApplicationQuit()
    {
        Debug.Log("Application ending after " + Time.time + " seconds");
        SSSocketManager.getInstance().Close();
    }

    void sendEnterGame()
    {
        MceEnterGame msg = new MceEnterGame();
        SSSocketManager.getInstance().SendProto(NetProtoType.MceEnterGame, msg);
    }

    private void createUser(MseSceneObjAppear objAppear)
    {
        String uid = objAppear.uid;
        var newUser = Instantiate(userPrefab);
		// newUser.transform.parent = userParentObj.transform;
        var userNode = newUser.GetComponent<UserNode>();
        Assert.IsNotNull(userNode);
        userNode.Appear(objAppear);
        userNodeDic.Add(uid, userNode);
    }

    private void runUser(MseSceneObjMove objMove)
    {
        var userNode = getUserNodeByUID(objMove.uid);
        if (null != userNode)
        {
            userNode.UpdateBySceneObjRunning(objMove);
        }
    }

    private UserNode getUserNodeByUID(string uid)
    {
        if (!userNodeDic.ContainsKey(uid))
        {
            SSDebug.Log("Error:can't find user by " + uid);
            return null;

        }
        return userNodeDic[uid];
    }

    private void destoryUser(MseSceneObjDisappear objDisappear)
    {
        String uid = objDisappear.uid;
        var userNode = getUserNodeByUID(uid);
        if (null != userNode)
        {
            userNode.Disappear();
            userNodeDic.Remove(uid);
        }
    }

    private void mseEnterGameProtoEventHandler(EventArgs e)
    {
        Debug.Log("receive MseEnterGame");
    }

    private void mseSceneObjAppearProtoEventHandler(EventArgs e)
    {
        ProtoEventArgs<MseSceneObjAppear> pe = (ProtoEventArgs<MseSceneObjAppear>)e;
        createUser(pe.Proto);
    }

    private void mseSceneObjAppearListProtoEventHandler(EventArgs e)
    {
        ProtoEventArgs<MseSceneObjAppearList> pe = (ProtoEventArgs<MseSceneObjAppearList>)e;
        foreach (var sceneObj in pe.Proto.sceneObjAppear)
        {
            createUser(sceneObj);
        }
    }

    private void mseSceneObjMoveProtoEventHandler(EventArgs e)
    {
        ProtoEventArgs<MseSceneObjMove> pe = (ProtoEventArgs<MseSceneObjMove>)e;
        runUser(pe.Proto);
    }

    private void mseSceneObjMoveListProtoEventHandler(EventArgs e)
    {
        var pe = (ProtoEventArgs<MseSceneObjMoveList>)e;
        foreach (var sceneObj in pe.Proto.sceneObjMove)
        {
            runUser(sceneObj);
        }
    }

    private void mseSceneObjDisappearProtoEventHandler(EventArgs e)
    {
        var pe = (ProtoEventArgs<MseSceneObjDisappear>)e;
        destoryUser(pe.Proto);
    }

    private void mseSceneObjDisappearListProtoEventHandler(EventArgs e)
    {
        var pe = (ProtoEventArgs<MseSceneObjDisappearList>)e;
        foreach (var sceneObj in pe.Proto.sceneObjDisappear)
        {
            destoryUser(sceneObj);
        }
    }

}

