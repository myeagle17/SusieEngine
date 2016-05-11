using System;
using System.Collections.Generic;
using UnityEngine;

namespace Susie
{
	public class MessageManager
	{
		private static MessageManager ince;

		private Dictionary<string , Message> m_dic;

		public static MessageManager GetIncestance()
		{
			if (ince == null) {
				ince = new MessageManager ();
			}
			return ince;
		}

		public static void Destory(){
			ince = null;
		}
			
		public void Add(string msgName , Message.DelegateMessage messageHandler){
			Message msg = null;
			if (!m_dic.ContainsKey (msgName)) {
				msg = new Message ();
				m_dic.Add (msgName, msg);
			} else {
				msg = m_dic [msgName];
			}
			msg.eventMessage += messageHandler;
		}

		public void Remove(string msgName , Message.DelegateMessage messageHandler){
			if (!m_dic.ContainsKey (msgName)) {
				debug ("Remove error:" + msgName);
				return;
			}
			m_dic [msgName].eventMessage -= messageHandler;
		}

		public void SendMessage(string msgName , EventArgs e){
			if (!m_dic.ContainsKey (msgName)) {
				debug ("SendMessage error" + msgName);
				return;
			}
			m_dic [msgName].Send (e);
		}

		private MessageManager ()
		{
			m_dic = new Dictionary<string , Message> ();
		}

		private void debug(string s)
		{
			SSDebug.Log(s);
		}
	}
}

