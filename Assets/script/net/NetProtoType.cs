using System;
using Susie;

public class NetProtoType {
// client
	public static int MceAuth                  = 1;
	public static int MceControl               = 2;
	public static int MceEnterGame             = 3;
	public static int MceHeartbeat             = 4;
	// server
	public static int MseAuth                  = 1001;
	public static int MseEnterGame             = 1002;
	public static int MseHeartbeat             = 1003;
	public static int MseUserInfo              = 1004;
	public static int MseSceneObjAppear        = 1005;
	public static int MseSceneObjAppearList    = 1006;
	public static int MseSceneObjMove          = 1007;
	public static int MseSceneObjMoveList      = 1008;
	public static int MseSceneObjDisappear     = 1009;
	public static int MseSceneObjDisappearList = 1010;
}


