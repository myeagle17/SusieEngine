using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using LitJson;

namespace Susie
{
    using Property = JsonData;
    public class SSTileMapParser
    {
        public static int MAX_READ_NUM_KEY = 100; // read map whoes key type is number , try times is 100

        public static string TILED_TAG_WIDTH = "width";
        public static string TILED_TAG_HEIGHT = "height";
        public static string TILED_TAG_TILE_HEIGHT = "tileheight";
        public static string TILED_TAG_TILE_WIDTH = "tilewidth";
        public static string TILED_TAG_NEXT_OBJECT_ID = "nextobjectid";
        public static string TILED_TAG_ORIENTATION = "orientation";
        public static string TILED_TAG_VERSION = "version";
        public static string TILED_TAG_PROPERTIES = "properties";
        public static string TILED_TAG_TILESETS = "tilesets";
        public static string TILED_TAG_FIRSTGID = "firstgid";
        public static string TILED_TAG_MARGIN = "margin";
        public static string TILED_TAG_NAME = "name";
        public static string TILED_TAG_SPACING = "spacing";
        public static string TILED_TAG_TILES = "tiles";
        public static string TILED_TAG_IMAGE = "image";
        public static string TILED_TAG_TILE_PROPERTIES = "tileproperties";
        public static string TILED_TAG_LAYERS = "layers";
        public static string TILED_TAG_DATA = "data";
        public static string TILED_TAG_OPACITY = "opacity";
        public static string TILED_TAG_TYPE = "type";
        public static string TILED_TAG_VISIBLE = "visible";
        public static string TILED_TAG_X = "x";
        public static string TILED_TAG_Y = "y";
        public static string TILED_TAG_DRAW_ORDER = "draworder";
        public static string TILED_TAG_OBJECTS = "objects";
        public static string TILED_TAG_ROTATION = "rotation";
        public static string TILED_TAG_ID = "id";
        public static string TILED_TAG_GID = "gid";

        public SSTileMapParser()
        {
        }

        public bool Parse(string url, SSTileMapInfo info)
        {
            string s = ReadStringFromFile(url);
            if (s == null)
                return false;
            JsonData jRoot = JsonMapper.ToObject(s);

            // read tile

            try
            {
                JsonData test1 = jRoot["testtest"];
            }
            catch (KeyNotFoundException ex)
            {
                SSDebug.Log("get test1 error:" + ex);
            }
            SSDebug.Log("exception run");

            ReadBasic(jRoot, info);

            //read tileSet
            ReadTileSets(SSJsonTool.getSubDictionary_json(jRoot, TILED_TAG_TILESETS), info.tileSetInfo);

            //read layer
            ReadLayers(SSJsonTool.getSubDictionary_json(jRoot, TILED_TAG_LAYERS), info.layerInfoList);
            return true;
        }

        private void ReadBasic(JsonData doc, SSTileMapInfo info)
        {
            info.width = SSJsonTool.getIntValue_json(doc, TILED_TAG_WIDTH);
            info.height = SSJsonTool.getIntValue_json(doc, TILED_TAG_HEIGHT);
            info.tileWidth = SSJsonTool.getIntValue_json(doc, TILED_TAG_TILE_WIDTH);
            info.tileHeight = SSJsonTool.getIntValue_json(doc, TILED_TAG_TILE_HEIGHT);
            info.mapSize = new Vector2(info.width * info.tileWidth, info.height * info.tileHeight);
            info.nextObjectID = SSJsonTool.getIntValue_json(doc, TILED_TAG_NEXT_OBJECT_ID);
            info.orientation = SSJsonTool.getStringValue_json(doc, TILED_TAG_ORIENTATION);
            Assert.IsTrue(info.orientation == "orthogonal");
            info.version = SSJsonTool.getIntValue_json(doc, TILED_TAG_VERSION);
            Assert.IsTrue(info.version == 1);
            ReadProperty(SSJsonTool.getSubDictionary_json(doc, TILED_TAG_PROPERTIES), info.property);
        }

        private void ReadTileSets(JsonData tileSetsDoc, SSTileMapTileSetInfo tileSetInfo)
        {
            if (null == tileSetsDoc || (!tileSetsDoc.IsArray)) return;

            for (int i = 0; i < tileSetsDoc.Count; ++i)
            {
                tileSetInfo.addTile(SSJsonTool.getSubDictionary_json(tileSetsDoc , i));
            }
        }
		
		private void ReadLayers(JsonData layerDoc , List<SSTileMapLayerBasicInfo> layerInfoList){
			if (null == layerDoc || (!layerDoc.IsArray)) return;
			
			for (int i = 0 ;i <layerDoc.Count ;++i){
				JsonData singleLayerDoc = SSJsonTool.getSubDictionary_json(layerDoc , i);
				if(SSJsonTool.getStringValue_json(singleLayerDoc , TILED_TAG_TYPE)=="tilelayer"){
					SSTileMapLayerTileInfo tileInfo = new SSTileMapLayerTileInfo();
					tileInfo.Parse(singleLayerDoc);
					layerInfoList.Add(tileInfo);
				}
			}
		}

        private void ReadProperty(JsonData propertyDoc, Property property)
        {
            property = propertyDoc;
        }

        private string ReadStringFromFile(string url)
        {
            if (!File.Exists(url))
            {
                SSDebug.Log("file is not exist:" + url);
                return null;
            }

            FileStream stream = new FileStream(url, FileMode.Open, FileAccess.Read);
            long length = stream.Length;
            byte[] bytes = new byte[length];
            stream.Read(bytes, 0, (int)length);
            Decoder d = Encoding.UTF8.GetDecoder();
            int charLength = d.GetCharCount(bytes, 0, (int)length);
            char[] chars = new char[charLength];
            d.GetChars(bytes, 0, (int)length, chars, 0);
            return new string(chars);
        }


    }
}

