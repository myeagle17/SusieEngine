using System;
using System.Collections.Generic;

class GlobalData{
    public static UserDataManager UserDataMgr;    
    
    private static bool isInit = false;
    public static void Init(){
        if(isInit)return;

        UserDataMgr = new UserDataManager();
        
        isInit = true;
    }
    
    public static void Clear(){
        if(!isInit)return;
        
        UserDataMgr.clear();
        UserDataMgr = null;
        
        isInit = false;
    }
   
}
