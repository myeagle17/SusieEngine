using System;
using LitJson;

namespace Susie
{
	public class SSJsonTool
	{
		public static int getIntValue_json(JsonData doc , string tag){
			JsonData data = getSubDictionary_json (doc, tag);
			if((data!=null)&&data.IsInt){
				return (int)data;
			}else{
				return -1;
			}
		}
		
		public static int getIntValue_json(JsonData doc , int tag){
			JsonData data = getSubDictionary_json (doc, tag);
			if((data!=null)&&data.IsInt){
				return (int)data;
			}else{
				return -1;
			}
		}

		public static string getStringValue_json(JsonData doc , string tag){
			JsonData data = getSubDictionary_json (doc, tag);
			if((data!=null)&&data.IsString){
				return (string)data;
			}else{
				return "";
			} 
		}
	
		public static JsonData getSubDictionary_json(JsonData doc , string tag){
			JsonData data = null;
			try {
				data = doc[tag];
			} catch (Exception ex) {
				return null;
			}
			return data; 
		}

		public static JsonData getSubDictionary_json(JsonData doc , int tag){
			JsonData data = null;
			try {
				data = doc[tag];
			} catch (Exception ex) {
				return null;
			}
			return data; 
		}
	}
}

