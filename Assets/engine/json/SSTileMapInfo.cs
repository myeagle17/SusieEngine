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

		public List<SSTileMapTileSetInfo> tileSetInfoList;
		public List<SSTileMapTileSetInfo> layersInfo;
		public Vector2 mapSize;

		public SSTileMapInfo ()
		{
			tileSetInfoList = new List<SSTileMapTileSetInfo>();
		}
	}

	
	public class SSTileMapTileSetInfo
	{
		public int firstgid;
		public int margin;
		public int spacing;
		public int tileWidth;
		public int tileHeight;
		public string name;
		public Property property;
		public Dictionary<int , SSTileMapTileInfo> tileDic;

		public SSTileMapTileSetInfo(){
			tileDic = new Dictionary<int , SSTileMapTileInfo>();
		}
	};
	
	public class SSTileMapTileInfo
	{
		public string imgSrc;
		public bool isTile;
		public Property property;
		
		public SSTileMapTileInfo(){
			isTile = false;
		}
	};

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
	};
	
	public class SSTileMapLayerTileInfo:SSTileMapLayerBasicInfo{
		public List<int> data;
	}
}

