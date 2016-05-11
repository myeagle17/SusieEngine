using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using LitJson;

namespace Susie
{
	using Property= JsonData ;
	public class SSTileMapParser
	{	
		private static int MAX_READ_NUM_KEY = 100; // read map whoes key type is number , try times is 100

		private static string TILED_TAG_WIDTH			= "width";
		private static string TILED_TAG_HEIGHT			= "height";
		private static string TILED_TAG_TILE_HEIGHT		= "tileheight";
		private static string TILED_TAG_TILE_WIDTH		= "tilewidth";
		private static string TILED_TAG_NEXT_OBJECT_ID	= "nextobjectid";
		private static string TILED_TAG_ORIENTATION		= "orientation";
		private static string TILED_TAG_VERSION			= "version";
		private static string TILED_TAG_PROPERTIES		= "properties";
		private static string TILED_TAG_TILESETS			= "tilesets";
		private static string TILED_TAG_FIRSTGID			= "firstgid";
		private static string TILED_TAG_MARGIN			= "margin";
		private static string TILED_TAG_NAME				= "name";
		private static string TILED_TAG_SPACING			= "spacing";
		private static string TILED_TAG_TILES				= "tiles";
		private static string TILED_TAG_IMAGE				= "image";
		private static string TILED_TAG_TILE_PROPERTIES		= "tileproperties";
		private static string TILED_TAG_LAYERS			= "layers";
		private static string TILED_TAG_DATA				= "data";
		private static string TILED_TAG_OPACITY			= "opacity";
		private static string TILED_TAG_TYPE				= "type";
		private static string TILED_TAG_VISIBLE			= "visible";
		private static string TILED_TAG_X					= "x";
		private static string TILED_TAG_Y					= "y";
		private static string TILED_TAG_DRAW_ORDER		= "draworder";
		private static string TILED_TAG_OBJECTS			= "objects";
		private static string TILED_TAG_ROTATION			= "rotation";
		private static string TILED_TAG_ID				= "id";
		private static string TILED_TAG_GID				= "gid";
		public SSTileMapParser ()
		{
		}

		public bool Parse(string url , SSTileMapInfo info){
			string s = ReadStringFromFile(url);
			if(s==null)
				return false;
			JsonData jRoot = JsonMapper.ToObject(s);

			// read tile

			try {
				JsonData test1 = jRoot["testtest"];
			} catch (KeyNotFoundException ex) {
				SSDebug.Log("get test1 error:"+ex);
			}
			SSDebug.Log("exception run");

			ReadBasic(jRoot , info);
			
			//read tileSet
			ReadTileSets(SSJsonTool.getSubDictionary_json(jRoot , TILED_TAG_TILESETS) , info.tileSetInfoList);
			
			//read layer
			//readLayers(DICTOOL.getSubDictionary_json(doc , TILED_TAG_LAYERS) , pInfo.pLayersInfo);
			return true;
		}

		private void ReadBasic(JsonData doc, SSTileMapInfo info)
		{
			info.width = SSJsonTool.getIntValue_json(doc , TILED_TAG_WIDTH);
			info.height = SSJsonTool.getIntValue_json(doc , TILED_TAG_HEIGHT);
			info.tileWidth = SSJsonTool.getIntValue_json(doc , TILED_TAG_TILE_WIDTH);
			info.tileHeight = SSJsonTool.getIntValue_json(doc , TILED_TAG_TILE_HEIGHT);
			info.mapSize = new Vector2(info.width * info.tileWidth , info.height * info.tileHeight);
			info.nextObjectID = SSJsonTool.getIntValue_json(doc , TILED_TAG_NEXT_OBJECT_ID);
			info.orientation = SSJsonTool.getStringValue_json(doc , TILED_TAG_ORIENTATION);
			Assert.IsTrue(info.orientation == "orthogonal");
			info.version = SSJsonTool.getIntValue_json(doc , TILED_TAG_VERSION);
			Assert.IsTrue(info.version == 1);
			ReadProperty(SSJsonTool.getSubDictionary_json(doc , TILED_TAG_PROPERTIES) , info.property);
		}

		private void ReadTileSets(JsonData tileSetsDoc, List<SSTileMapTileSetInfo> tileSetInfoList)
		{
			if(null == tileSetsDoc || (!tileSetsDoc.IsArray)) return;

			for(int i = 0 ; i < tileSetsDoc.Count ; ++i){
				SSTileMapTileSetInfo tileSetInfo = new SSTileMapTileSetInfo();
				ReadSingleTileSet(tileSetsDoc[i] , tileSetInfo);
				tileSetInfoList.Add(tileSetInfo);
			}
		}
		
		private void ReadSingleTileSet(JsonData singleTileSetDoc , SSTileMapTileSetInfo pTileSetInfo)
		{
			if(null == singleTileSetDoc || (!singleTileSetDoc.IsObject)) return;
			// basic prop
			pTileSetInfo.firstgid = SSJsonTool.getIntValue_json(singleTileSetDoc , TILED_TAG_FIRSTGID);
			pTileSetInfo.margin = SSJsonTool.getIntValue_json(singleTileSetDoc , TILED_TAG_MARGIN);
			pTileSetInfo.name = SSJsonTool.getStringValue_json(singleTileSetDoc , TILED_TAG_NAME);
			pTileSetInfo.spacing = SSJsonTool.getIntValue_json(singleTileSetDoc , TILED_TAG_SPACING);
			pTileSetInfo.tileWidth = SSJsonTool.getIntValue_json(singleTileSetDoc , TILED_TAG_TILE_WIDTH);
			pTileSetInfo.tileHeight = SSJsonTool.getIntValue_json(singleTileSetDoc , TILED_TAG_TILE_HEIGHT);
			// property
			ReadProperty(SSJsonTool.getSubDictionary_json(singleTileSetDoc , TILED_TAG_PROPERTIES) , pTileSetInfo.property);
			// tiles
			JsonData tilesDoc = SSJsonTool.getSubDictionary_json(singleTileSetDoc , TILED_TAG_TILES);
			if(tilesDoc == null)return;

			for(int i = 0 ; i<MAX_READ_NUM_KEY ; ++i){
				JsonData tileDoc = SSJsonTool.getSubDictionary_json(tilesDoc , i);
				if (tileDoc == null) continue;
				SSTileMapTileInfo tileInfo = new SSTileMapTileInfo();
				tileInfo.imgSrc = SSJsonTool.getStringValue_json(tileDoc , TILED_TAG_IMAGE);
				pTileSetInfo.tileDic.Add(i,tileInfo);
			}

			// tiles properties
			JsonData tilePropertiesDoc = SSJsonTool.getSubDictionary_json(singleTileSetDoc , TILED_TAG_TILE_PROPERTIES);
			if(null == tilePropertiesDoc)return;

			for(int i = 0 ; i <MAX_READ_NUM_KEY ; ++i){
				JsonData tempData = SSJsonTool.getSubDictionary_json(tilePropertiesDoc , i);
				if(tempData==null)continue;
				SSTileMapTileInfo tileInfo = pTileSetInfo.tileDic[i];
				if(tileInfo == null) continue;
				ReadProperty(tempData , tileInfo.property);
			}
		}

		private void ReadProperty(JsonData propertyDoc , Property property)
		{
			property =propertyDoc;
		}

		private string ReadStringFromFile(string url){
			if(!File.Exists(url)){
				SSDebug.Log("file is not exist:" + url);
				return null;
			}

			FileStream stream = new FileStream(url ,FileMode.Open ,  FileAccess.Read);
			long length = stream.Length;
			byte[] bytes = new byte[length];
			stream.Read(bytes , 0 , (int)length);
			Decoder d = Encoding.UTF8.GetDecoder();
			int charLength = d.GetCharCount(bytes , 0 , (int)length);
			char[] chars = new char[charLength];
			d.GetChars(bytes,0,(int)length,chars,0);
			return new string(chars);
		}
	}
}

