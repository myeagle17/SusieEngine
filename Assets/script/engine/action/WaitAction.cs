using System;
using UnityEngine;

namespace Susie
{
	public class WaitAction:BasicAction
	{
		public WaitAction(float interval){
			Interval = interval;
		}

		public override void Start() {
			base.Start ();
		}

		public override void BaseUpate (){

		}
	}
}