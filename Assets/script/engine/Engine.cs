using System;
using Susie;

namespace Susie
{
	public class Engine
	{
		public static void Init ()
		{
			SSDebug.Log ("Engine.init()");
			MessageManager.GetIncestance ();
		}
	}
}

