//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: src/MseDungeonTaskInfo.proto
namespace AppProto
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"MDTask")]
  public partial class MDTask : global::ProtoBuf.IExtensible
  {
    public MDTask() {}
    
    private int _type = default(int);
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"type", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int type
    {
      get { return _type; }
      set { _type = value; }
    }
    private int _key_id = default(int);
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"key_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int key_id
    {
      get { return _key_id; }
      set { _key_id = value; }
    }
    private int _current = default(int);
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"current", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int current
    {
      get { return _current; }
      set { _current = value; }
    }
    private int _total = default(int);
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"total", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int total
    {
      get { return _total; }
      set { _total = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"MseDungeonTaskInfo")]
  public partial class MseDungeonTaskInfo : global::ProtoBuf.IExtensible
  {
    public MseDungeonTaskInfo() {}
    
    private int _clear = default(int);
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"clear", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int clear
    {
      get { return _clear; }
      set { _clear = value; }
    }
    private readonly global::System.Collections.Generic.List<MDTask> _task = new global::System.Collections.Generic.List<MDTask>();
    [global::ProtoBuf.ProtoMember(2, Name=@"task", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<MDTask> task
    {
      get { return _task; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}