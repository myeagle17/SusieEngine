using System;
using UnityEngine;

namespace Susie
{
	public class SSTileMap
	{
		private SSTileMapInfo info;

		public SSTileMapInfo Info {
			get {
				return info;
			}
		}

		public SSTileMap (string url)
		{
			info = new SSTileMapInfo();
			SSTileMapParser parser = new SSTileMapParser();
			parser.Parse(url , info);
		}
	}
}

