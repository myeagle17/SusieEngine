using System;
using System.Collections.Generic;

namespace Susie
{
	// can stop , resume , quicker deng
	public class ActionManager
	{
		private static ActionManager Ince = null;

		private List<BasicAction> m_actionList;

		private List<BasicAction> m_addActionList;

		public static ActionManager GetInstance(){
			if (null == Ince) {
				Ince = new ActionManager ();
			}
			return Ince;
		}
			

		private ActionManager ()
		{
			m_actionList = new List<BasicAction> ();
			m_addActionList = new List<BasicAction> ();
		}

		public void RunAction(SSMonoBehaviour monoBehaviour , BasicAction action , BasicAction.DelegateMessage delegateActionFinish){
			action.MonoBehaviour = monoBehaviour;
			action.SetFinishDelegate (delegateActionFinish);
			if (action.Interval <= 0.0f) {
				action.DoFinishDelegate ();
				return;
			}

			m_addActionList.Add(action);
			action.Start ();

		}

		public void Update()
		{
			foreach (var action in m_actionList) {
				action.Update ();
			}

			foreach (var action in m_addActionList) {
				action.Update ();
				m_actionList.Add (action);
			}
			m_addActionList.Clear ();

			DelActionReadyForDel ();
		}

		public void RemoveMonoBehaviour(SSMonoBehaviour monoBehaviour){
			foreach (var action in m_actionList) {
				if (action.MonoBehaviour == monoBehaviour) {
					action.IsDelete = true;
				}
			}
			DelActionReadyForDel ();
		}

		public override string ToString()
		{
			return "action length = " + m_actionList.Count;
		}

		private void DelActionReadyForDel(){
			m_actionList.RemoveAll (ac=>ac.IsDelete);
		}

	}
}

