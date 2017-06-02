namespace Susie{
	public class SSSocketTool
	{
		public static byte[] intToByte4(int num)  {
			byte[] abyte=new byte[4]; //int为32位除4位，数组为8
			abyte[3] = (byte)(num & 0xff);
			abyte [2] = (byte)((num & 0xff00)>>8);
			abyte [1] = (byte)((num & 0xff0000)>>16);
			abyte [0] = (byte)((num & 0xff000000)>>24);
			return abyte;
		}

		public static byte[] shortToByte2(short num){
			byte[] abyte = new byte[2];
			abyte [1] = (byte)(num & 0xff);
			abyte [0] = (byte)((num & 0xff00)>>8);
			return abyte;
		}
		
		public static short byte2ToShort(byte[] bytes){
			return (short)(bytes[0]*256 + bytes[1]);
		}
		
		public static int byte4ToInt(byte[] bytes){
			return bytes[0]*16777216 + bytes[1]*65536 + bytes[2]*256 + bytes[3];
		}

		public static string TransMsgDefToStr(int msgID){
        	return "NetMsgDef:" + msgID;
    	} 

	}
}