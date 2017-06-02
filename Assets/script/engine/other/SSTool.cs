using System;
using UnityEngine;
using System.IO;
using System.Xml;

namespace Susie
{
	public class SSTool
	{
		public static string ConvertXmlToString(XmlDocument xmlDoc)  
		{  
			MemoryStream stream = new MemoryStream();  
			XmlTextWriter writer = new XmlTextWriter(stream, null);  
			writer.Formatting = Formatting.Indented;  
			xmlDoc.Save(writer);   
			StreamReader sr = new StreamReader(stream, System.Text.Encoding.UTF8);  
			stream.Position = 0;  
			string xmlString = sr.ReadToEnd();  
			sr.Close();  
			stream.Close();   
			return xmlString;  
		}
	}
}
