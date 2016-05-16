using System;
using Susie;

class AppDebug{
    public static bool Net = true;
    
    public static void NetLog(string msg){
        if(Net)
            SSDebug.Log(msg);
    } 
    

}