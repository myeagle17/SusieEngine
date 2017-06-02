using System;
using UnityEngine;

namespace Susie
{
	public class MoveToAction:BasicAction
	{
		private Vector3 m_target;
		private Vector3 m_start;
		public MoveToAction(Vector3 target , float interval){
			Interval = interval;
			m_target = target;
		}

		public override void Start() {
			base.Start ();
			m_start = MonoBehaviour.transform.localPosition;

		}

		public override void BaseUpate (){
			Vector3 tempPos = Vector3.Lerp (m_start, m_target, CurTime / Interval);
			MonoBehaviour.transform.localPosition = tempPos;
		}
	}
}