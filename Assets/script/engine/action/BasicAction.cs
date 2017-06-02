using System;
using UnityEngine;

namespace Susie
{
	public abstract class BasicAction
	{
		private bool m_isDelete;

		private float m_interval;

		private float m_curTime;

		public delegate void DelegateMessage ();

		private DelegateMessage m_delegateMessage;

		private SSMonoBehaviour m_monoBehaviour;

		public bool	IsDelete {
			get { return m_isDelete; }
			set { m_isDelete = value; }
		}

		public float Interval {
			get { return m_interval; }
			set { m_interval = value; }
		}

		public float CurTime {
			get { return m_curTime; }
			set { m_curTime = value; }
		}

		public SSMonoBehaviour MonoBehaviour {
			get { return m_monoBehaviour; }
			set { m_monoBehaviour = value; }
		}

		public BasicAction ()
		{
			m_isDelete = false;	
		}

		public void SetFinishDelegate (DelegateMessage delegateMessage)
		{
			m_delegateMessage = delegateMessage;
		}

		public virtual void Start ()
		{
			m_isDelete = false;
			m_curTime = 0.0f;
		}

		public void Update ()
		{
			if (m_isDelete)
				return;
			if (m_curTime >= m_interval) {
				m_curTime = m_interval;
				m_isDelete = true;
			}

			BaseUpate ();

			if (!m_isDelete) {
				m_curTime += Time.deltaTime;
			} else {
				DoFinish ();
				DoFinishDelegate ();
			}
		}

		public void DoFinishDelegate ()
		{
			if (null != m_delegateMessage) {
				m_delegateMessage ();
				m_delegateMessage = null;
			}
		}

		public abstract void BaseUpate ();

		public virtual void DoFinish ()
		{

		}
	}
}

