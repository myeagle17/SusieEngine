//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: src/MseAuth.proto
namespace AppProto
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"MseAuth")]
  public partial class MseAuth : global::ProtoBuf.IExtensible
  {
    public MseAuth() {}
    
    private string _uid = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"uid", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string uid
    {
      get { return _uid; }
      set { _uid = value; }
    }
    private bool _succ = default(bool);
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"succ", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(default(bool))]
    public bool succ
    {
      get { return _succ; }
      set { _succ = value; }
    }
    private bool _redirect = (bool)false;
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"redirect", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue((bool)false)]
    public bool redirect
    {
      get { return _redirect; }
      set { _redirect = value; }
    }
    private string _redirect_port = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"redirect_port", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string redirect_port
    {
      get { return _redirect_port; }
      set { _redirect_port = value; }
    }
    private string _redirect_ip = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"redirect_ip", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string redirect_ip
    {
      get { return _redirect_ip; }
      set { _redirect_ip = value; }
    }
    private string _redirect_pass = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"redirect_pass", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string redirect_pass
    {
      get { return _redirect_pass; }
      set { _redirect_pass = value; }
    }
    private string _name = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string name
    {
      get { return _name; }
      set { _name = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}