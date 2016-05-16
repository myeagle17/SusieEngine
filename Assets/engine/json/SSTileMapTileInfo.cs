using LitJson;
namespace Susie
{
	using Property= JsonData;
    
	public class SSTileMapTileInfo
	{
		public int gid;
		public bool isTile;
		public Property property;
		
		public SSTileMapTileInfo(){
			isTile = false;						
		}	
		
	};
}