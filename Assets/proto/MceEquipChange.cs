//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: src/MceEquipChange.proto
namespace AppProto
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"MceEquipChange")]
  public partial class MceEquipChange : global::ProtoBuf.IExtensible
  {
    public MceEquipChange() {}
    
    private string _ship_id = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"ship_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string ship_id
    {
      get { return _ship_id; }
      set { _ship_id = value; }
    }
    private readonly global::System.Collections.Generic.List<string> _on_list = new global::System.Collections.Generic.List<string>();
    [global::ProtoBuf.ProtoMember(2, Name=@"on_list", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<string> on_list
    {
      get { return _on_list; }
    }
  
    private readonly global::System.Collections.Generic.List<string> _off_list = new global::System.Collections.Generic.List<string>();
    [global::ProtoBuf.ProtoMember(3, Name=@"off_list", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<string> off_list
    {
      get { return _off_list; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}