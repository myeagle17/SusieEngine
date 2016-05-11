using System;

namespace Susie
{
	public class Message
	{
		public delegate void DelegateMessage(EventArgs e);
		public event DelegateMessage eventMessage;
		public void Send(EventArgs e){
			eventMessage(e);
		}
	}
}

