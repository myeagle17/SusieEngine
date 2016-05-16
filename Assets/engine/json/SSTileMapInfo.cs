using System;
using System.Collections.Generic;
using LitJson;
using UnityEngine;


namespace Susie
{	
	using Property= JsonData;
	
	public enum SSTileMapLayerType
	{
		Tile,
		Object,
		Pic
	}
	
	public class SSTileMapInfo
	{
		//value
		public int width;
		public int height;
		public int tileWidth;
		public int tileHeight;
		public int nextObjectID;
		public string orientation;
		public int version;
		public string globalDir;
		public Property property;

		public SSTileMapTileSetInfo tileSetInfo;
		
		public List<SSTileMapLayerBasicInfo> layerInfoList;
		public Vector2 mapSize;

		public SSTileMapInfo(){
			tileSetInfo = new SSTileMapTileSetInfo();
			layerInfoList = new List<SSTileMapLayerBasicInfo>();
		}
		
		public Property getPropertyByTileID(int id){
			return tileSetInfo.getPropertyByTileID(id);
		}
	}


	public class SSTileMapLayerBasicInfo
	{
		public SSTileMapLayerType type;
		
		public int height;
		public string name;
		public int opacity;
		public int visible;
		public int width;
		public int x;
		public int y;
		public Property property;
		
		public virtual void Parse(JsonData layerInfoDoc){
			
		}
	};
	
	public class SSTileMapLayerTileInfo:SSTileMapLayerBasicInfo{
		public List<int> data;
		
		public override void Parse(JsonData layerInfoDoc){
			base.Parse(layerInfoDoc);
			data = new List<int>();
			JsonData dataDoc = SSJsonTool.getSubDictionary_json(layerInfoDoc,SSTileMapParser.TILED_TAG_DATA);
			if (null == dataDoc)return;
			for (int i = 0; i < dataDoc.Count; i++)
			{
				data.Add(SSJsonTool.getIntValue_json(dataDoc , i));
			}	
		}
	}
}

