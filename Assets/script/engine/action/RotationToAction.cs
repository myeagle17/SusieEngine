using System;
using UnityEngine;

namespace Susie
{
	public class RotationToAction:BasicAction
	{
		private Quaternion m_oldQuaternion;
		private float m_targetAngle;
		private Vector3 m_targetAxis;

		public RotationToAction(float angle , Vector3 axis , float interval){
			m_targetAngle = angle;
			m_targetAxis = axis;
			Interval = interval;
		}

		public override void Start() {
			base.Start ();
			m_oldQuaternion = MonoBehaviour.transform.rotation;
		}

		public override void BaseUpate (){
			float curAngle = CurTime / Interval * m_targetAngle;
			MonoBehaviour.transform.rotation = m_oldQuaternion * Quaternion.AngleAxis (curAngle, m_targetAxis);
		}
	}
}

