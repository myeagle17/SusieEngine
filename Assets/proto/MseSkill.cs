//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: src/MseSkill.proto
namespace AppProto
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"SkillTarget")]
  public partial class SkillTarget : global::ProtoBuf.IExtensible
  {
    public SkillTarget() {}
    
    private long _oid = default(long);
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"oid", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(long))]
    public long oid
    {
      get { return _oid; }
      set { _oid = value; }
    }
    private int _x = default(int);
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"x", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int x
    {
      get { return _x; }
      set { _x = value; }
    }
    private int _y = default(int);
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"y", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int y
    {
      get { return _y; }
      set { _y = value; }
    }
    private int _hp_change = default(int);
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"hp_change", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int hp_change
    {
      get { return _hp_change; }
      set { _hp_change = value; }
    }
    private int _hp_last = default(int);
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"hp_last", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int hp_last
    {
      get { return _hp_last; }
      set { _hp_last = value; }
    }
    private readonly global::System.Collections.Generic.List<int> _buf_type = new global::System.Collections.Generic.List<int>();
    [global::ProtoBuf.ProtoMember(6, Name=@"buf_type", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public global::System.Collections.Generic.List<int> buf_type
    {
      get { return _buf_type; }
    }
  
    private readonly global::System.Collections.Generic.List<int> _buf_time = new global::System.Collections.Generic.List<int>();
    [global::ProtoBuf.ProtoMember(7, Name=@"buf_time", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public global::System.Collections.Generic.List<int> buf_time
    {
      get { return _buf_time; }
    }
  
    private bool _miss = default(bool);
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"miss", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(default(bool))]
    public bool miss
    {
      get { return _miss; }
      set { _miss = value; }
    }
    private bool _crit = default(bool);
    [global::ProtoBuf.ProtoMember(9, IsRequired = false, Name=@"crit", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(default(bool))]
    public bool crit
    {
      get { return _crit; }
      set { _crit = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"MseSkill")]
  public partial class MseSkill : global::ProtoBuf.IExtensible
  {
    public MseSkill() {}
    
    private long _player_oid = default(long);
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"player_oid", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(long))]
    public long player_oid
    {
      get { return _player_oid; }
      set { _player_oid = value; }
    }
    private int _skillid = default(int);
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"skillid", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int skillid
    {
      get { return _skillid; }
      set { _skillid = value; }
    }
    private readonly global::System.Collections.Generic.List<SkillTarget> _target = new global::System.Collections.Generic.List<SkillTarget>();
    [global::ProtoBuf.ProtoMember(3, Name=@"target", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<SkillTarget> target
    {
      get { return _target; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}