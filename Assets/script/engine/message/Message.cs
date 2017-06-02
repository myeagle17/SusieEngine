using System;
using System.Collections.Generic;

namespace Susie
{
	public class Message
	{
		public delegate void DelegateMessage(EventArgs e);
		private string m_msgName;
		private Dictionary<Object,DelegateMessage> m_delegateDic;

		public Message(string msgName){
			m_msgName = msgName;
			m_delegateDic = new Dictionary<object, DelegateMessage>();
		}

		public void Add(Object obj , DelegateMessage msgDelegate){
			if (m_delegateDic.ContainsKey (obj)) {
				SSDebug.Log ("add delegate repeatedly:" + m_msgName);
				return;
			}
			m_delegateDic.Add (obj,msgDelegate);
		}

		public void Remove (Object obj)
		{
			if (false == m_delegateDic.ContainsKey (obj)) {
				SSDebug.Log ("remove obj error:" + m_msgName);
				return;
			}
			m_delegateDic.Remove (obj);
		}

		public void Send(EventArgs e)
		{
			foreach (var item in m_delegateDic) {
				item.Value (e);
			}	
		}

		public override string ToString()
		{
			return m_msgName + " length = " + m_delegateDic.Count;
		}
	}
}

