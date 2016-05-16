using System.IO;
using System;
using ProtoBuf;
using Susie;

public class ProtoEventArgs<T> : EventArgs
{
    private T proto;

    public T Proto
    {
        get { return proto; }
        set { proto = value; }
    }

    private int msgID;
    public int MsgID
    {
        get { return msgID; }
        set { msgID = value; }
    }


    public void Deserialize(Stream stream)
    {
        proto = default(T);
        try
        {
            proto = Serializer.Deserialize<T>(stream);
        }
        catch (System.Exception ex)
        {
            SSDebug.Log(ex.ToString());
        }
    }
}

