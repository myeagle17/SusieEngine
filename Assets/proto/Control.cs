//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: proto/Control.proto
namespace AppProto
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"MceControl")]
  public partial class MceControl : global::ProtoBuf.IExtensible
  {
    public MceControl() {}
    
    private E_DIR _dir;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"dir", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public E_DIR dir
    {
      get { return _dir; }
      set { _dir = value; }
    }
    private bool _isMove = default(bool);
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"isMove", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(default(bool))]
    public bool isMove
    {
      get { return _isMove; }
      set { _isMove = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
    [global::ProtoBuf.ProtoContract(Name=@"E_DIR")]
    public enum E_DIR
    {
            
      [global::ProtoBuf.ProtoEnum(Name=@"LEFT", Value=1)]
      LEFT = 1,
            
      [global::ProtoBuf.ProtoEnum(Name=@"RIGHT", Value=2)]
      RIGHT = 2,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CENTER", Value=3)]
      CENTER = 3
    }
  
}