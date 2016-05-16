using System.Collections.Generic;
using LitJson;
namespace Susie
{
	using Property= JsonData;
    public class SSTileMapTileSetInfo
    {
        public int margin;
        public int spacing;
        public int tileWidth;
        public int tileHeight;
        public string name;
        public Property property;
        public Dictionary<int, SSTileMapTileInfo> tileDic;

        public SSTileMapTileSetInfo()
        {
            tileDic = new Dictionary<int, SSTileMapTileInfo>();
        }
		
		public void addTile(JsonData singleTileSetDoc){
			if(null == singleTileSetDoc || (!singleTileSetDoc.IsObject)) return;
			// base prop 
			int firstgid = SSJsonTool.getIntValue_json(singleTileSetDoc , SSTileMapParser.TILED_TAG_FIRSTGID);
			JsonData tilePropertiesDoc = SSJsonTool.getSubDictionary_json(singleTileSetDoc , SSTileMapParser.TILED_TAG_TILE_PROPERTIES);		
			for(int i = 0 ; i <SSTileMapParser.MAX_READ_NUM_KEY ; ++i){
				JsonData tempData = SSJsonTool.getSubDictionary_json(tilePropertiesDoc , ""+i);
				if(tempData==null)continue;
				SSTileMapTileInfo tileInfo = new SSTileMapTileInfo();
				tileInfo.property = tempData;
				tileInfo.gid = firstgid + i;
				tileInfo.isTile = true;
				tileDic.Add(tileInfo.gid,tileInfo);
			}
		}
		
		public Property getPropertyByTileID(int id){
			Property result = null;
			try
			{
				SSTileMapTileInfo tileInfo = tileDic[id];
				result = tileInfo.property;
			}
			catch (System.Exception)
			{
				
			}
			return result;
		}
    };
}