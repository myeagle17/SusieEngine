//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: proto/SceneObjDisappear.proto
namespace AppProto
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"MseSceneObjDisappear")]
  public partial class MseSceneObjDisappear : global::ProtoBuf.IExtensible
  {
    public MseSceneObjDisappear() {}
    
    private string _uid;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"uid", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string uid
    {
      get { return _uid; }
      set { _uid = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"MseSceneObjDisappearList")]
  public partial class MseSceneObjDisappearList : global::ProtoBuf.IExtensible
  {
    public MseSceneObjDisappearList() {}
    
    private readonly global::System.Collections.Generic.List<MseSceneObjDisappear> _sceneObjDisappear = new global::System.Collections.Generic.List<MseSceneObjDisappear>();
    [global::ProtoBuf.ProtoMember(1, Name=@"sceneObjDisappear", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<MseSceneObjDisappear> sceneObjDisappear
    {
      get { return _sceneObjDisappear; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}