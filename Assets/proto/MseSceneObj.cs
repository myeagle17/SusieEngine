//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: src/MseSceneObj.proto
// Note: requires additional types generated from: MObj.proto
namespace AppProto
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"MseSceneObj")]
  public partial class MseSceneObj : global::ProtoBuf.IExtensible
  {
    public MseSceneObj() {}
    
    private readonly global::System.Collections.Generic.List<MObj> _obj_list = new global::System.Collections.Generic.List<MObj>();
    [global::ProtoBuf.ProtoMember(1, Name=@"obj_list", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<MObj> obj_list
    {
      get { return _obj_list; }
    }
  
    private readonly global::System.Collections.Generic.List<long> _del_list = new global::System.Collections.Generic.List<long>();
    [global::ProtoBuf.ProtoMember(2, Name=@"del_list", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public global::System.Collections.Generic.List<long> del_list
    {
      get { return _del_list; }
    }
  
    private readonly global::System.Collections.Generic.List<MDetialObj> _hp_list = new global::System.Collections.Generic.List<MDetialObj>();
    [global::ProtoBuf.ProtoMember(3, Name=@"hp_list", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<MDetialObj> hp_list
    {
      get { return _hp_list; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}