using System;
using System.Collections.Generic;
using Susie;
using AppProto;

class NetMsgProtoConfig{
    //private Dictionary<NetS2CMsgDef , string> dicProto; 
    public  NetMsgProtoConfig(){
       // dicProto.Add(NetS2CMsgDef.MceAuth , "AppProto.MseAuth");
    }
    
    public static string TransMsgDefToStr(int msgID){
        return "NetMsgDef:" + msgID;
    } 
    
    public static Type GetFromMsgDef(int msgID){
        
        return new AppProto.MseAuth().GetType();
    }
}