//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: src/MceNpcTalk.proto
namespace AppProto
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"MceNpcTalk")]
  public partial class MceNpcTalk : global::ProtoBuf.IExtensible
  {
    public MceNpcTalk() {}
    
    private int _npc_id = default(int);
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"npc_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int npc_id
    {
      get { return _npc_id; }
      set { _npc_id = value; }
    }
    private int _task_id = default(int);
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"task_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int task_id
    {
      get { return _task_id; }
      set { _task_id = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}