//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: proto/SceneObjMove.proto
namespace AppProto
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"MseSceneObjMove")]
  public partial class MseSceneObjMove : global::ProtoBuf.IExtensible
  {
    public MseSceneObjMove() {}
    
    private string _uid;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"uid", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string uid
    {
      get { return _uid; }
      set { _uid = value; }
    }
    private E_SceneObjMoveS _status;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"status", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public E_SceneObjMoveS status
    {
      get { return _status; }
      set { _status = value; }
    }
    private long _endTime;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"endTime", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public long endTime
    {
      get { return _endTime; }
      set { _endTime = value; }
    }
    private float _posX = default(float);
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"posX", DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
    [global::System.ComponentModel.DefaultValue(default(float))]
    public float posX
    {
      get { return _posX; }
      set { _posX = value; }
    }
    private float _posY = default(float);
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"posY", DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
    [global::System.ComponentModel.DefaultValue(default(float))]
    public float posY
    {
      get { return _posY; }
      set { _posY = value; }
    }
    private float _currentDegree = default(float);
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"currentDegree", DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
    [global::System.ComponentModel.DefaultValue(default(float))]
    public float currentDegree
    {
      get { return _currentDegree; }
      set { _currentDegree = value; }
    }
    private float _targetDegree = default(float);
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"targetDegree", DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
    [global::System.ComponentModel.DefaultValue(default(float))]
    public float targetDegree
    {
      get { return _targetDegree; }
      set { _targetDegree = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"MseSceneObjMoveList")]
  public partial class MseSceneObjMoveList : global::ProtoBuf.IExtensible
  {
    public MseSceneObjMoveList() {}
    
    private readonly global::System.Collections.Generic.List<MseSceneObjMove> _sceneObjMove = new global::System.Collections.Generic.List<MseSceneObjMove>();
    [global::ProtoBuf.ProtoMember(1, Name=@"sceneObjMove", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<MseSceneObjMove> sceneObjMove
    {
      get { return _sceneObjMove; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
    [global::ProtoBuf.ProtoContract(Name=@"E_SceneObjMoveS")]
    public enum E_SceneObjMoveS
    {
            
      [global::ProtoBuf.ProtoEnum(Name=@"STOP", Value=1)]
      STOP = 1,
            
      [global::ProtoBuf.ProtoEnum(Name=@"STOP_AND_ROTATE", Value=2)]
      STOP_AND_ROTATE = 2,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MOVE", Value=3)]
      MOVE = 3,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MOVE_AND_ROTATE", Value=4)]
      MOVE_AND_ROTATE = 4
    }
  
}