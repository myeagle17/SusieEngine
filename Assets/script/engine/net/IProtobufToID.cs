using System;
using System.IO;
using ProtoBuf;

namespace Susie{
	public abstract class IProtobufToID
	{
		// override
		public abstract void decode(short msgType , byte[] msgBytes);
	}
}