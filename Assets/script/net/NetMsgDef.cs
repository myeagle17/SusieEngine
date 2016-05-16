using System;
using Susie;

public class NetMsgDef{
    // s2c
    public static short MseAuth         = 512;
    public static short MseSceneObj     = 513;
    public static short MseMove         = 514;
    public static short MsePoshort      = 515;
    public static short MseUserInfo     = 516;
    public static short MseBagInfo      = 517;
    public static short MseTaskInfo     = 518;
    public static short MseTransScene   = 519;
    public static short MseBag          = 520;
    public static short MseTaskReward   = 521;
    public static short MseErrorMsg     = 522;
    public static short MseShipInfo     = 523;
    public static short MseShipList     = 524;
    public static short MseEquipChange  = 525;
    public static short MseEquipList    = 526;
    public static short MseApplyBuffer  = 527;
    public static short MseExecuteSkill = 528;
    public static short MseSkill        = 529;
    public static short MseObjDisappear = 530;
    public static short MseMedalList    = 531;
    public static short MseMedalUpgrade = 532;
    public static short MseMedalgemChange   = 533;
    public static short MseMedalgemCompose  = 534;
    public static short MseEquipEnhance     = 535;
    public static short MseEquipAttrRandom  = 536;
    public static short MseEquipResolve     = 537;
    public static short MseEquipUpdateStar  = 538;
    public static short MseEnterDungeon     = 539;
    public static short MseAirWall          = 540;
    public static short MseDungeonSettle    = 541;
    public static short MseDungeonTaskInfo  = 542; 
 
    // c2s
    public static short MceHeartbeat        = 1024;
    public static short MceAuth             = 1025;
    public static short MceMove             = 1026;
    public static short MceEnterScene       = 1027;
    public static short MceUserInfo         = 1028;
    public static short MceEnterGame        = 1029;
    public static short MceNpcTalk          = 1030;
    public static short MceTaskReward       = 1031;
    public static short MceShipInfo         = 1032;
    public static short MceEquipChange      = 1033;
    public static short MceExecuteSkill     = 1034;
    public static short MceMedalUpgrade     = 1035;
    public static short MceMedalgemChange   = 1036;
    public static short MceMedalgemCompose  = 1037;
    public static short MceEquipEnhance     = 1038;
    public static short MceEquipAttrRandom  = 1039;
    public static short MceEquipResolve     = 1040;
    public static short MceEquipUpdateStar  = 1041;
    public static short MceEnterDungeon     = 1042;
    public static short MceExitDungeon      = 1043; 
}
