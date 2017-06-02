using Susie;
using System;
using AppProto;

class UserDataManager:ADataManager{
    public string uid;
    public double oid;
    public int tid;
    public string userName;
    public int level;
    public int head;
    public int vipLevel;
    public int speed;
    public int power;
    public string shipid;
    public int suit;
    public int exp;
    public int exp_max;
    public int camp;
    public int scene_id = 0;
    public int x = 0;
    public int y = 0;
    public int d = 0;
    public int hp_max = 1;
    public int hp = 1;
   
    public UserDataManager(){
         
    }
    
    public override void clear(){
        
    }
    
    public void UpdateByMseUserInfo(AppProto.MseUserInfo p_msg){
       
    }
    
    public void mseUserInfoProtoEventHandler(EventArgs e){
		ProtoEventArgs<MseUserInfo> pe = (ProtoEventArgs<MseUserInfo>)e;
        UpdateByMseUserInfo(pe.Proto);
	}
}