//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: src/MceEnterDungeon.proto
namespace AppProto
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"MceEnterDungeon")]
  public partial class MceEnterDungeon : global::ProtoBuf.IExtensible
  {
    public MceEnterDungeon() {}
    
    private int _dungeon_id = default(int);
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"dungeon_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int dungeon_id
    {
      get { return _dungeon_id; }
      set { _dungeon_id = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}