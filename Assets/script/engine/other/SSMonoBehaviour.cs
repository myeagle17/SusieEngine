using UnityEngine;
using System;
using Susie;
using System.Collections.Generic;
using UnityEngine.Assertions;

public class SSMonoBehaviour : MonoBehaviour
{

	private List<string> m_msgDataList = new List<string> ();

	protected delegate void DelegateTriggerEnter (Collider col);

	private Dictionary<string , DelegateTriggerEnter> m_triggerMap = new Dictionary<string, DelegateTriggerEnter> ();

	protected delegate void DelegateCollisionEnter (Collision collision);

	private Dictionary<string , DelegateCollisionEnter> m_collisionMap = new Dictionary<string, DelegateCollisionEnter> ();

	void OnDestroy ()
	{
		Clear ();
	}

	void OnTriggerEnter (Collider otherObj)
	{
		SSDebug.Log ("trigger:" + otherObj.tag);
		if (!m_triggerMap.ContainsKey (otherObj.tag)) {
			return;
		}
		m_triggerMap [otherObj.tag] (otherObj);
	}

	void OnCollisionEnter (Collision collision)
	{
		GameObject tempGameObject = collision.gameObject;
		SSDebug.Log ("collisionEnter:" + tempGameObject.tag);
		if (!m_collisionMap.ContainsKey (tempGameObject.tag)) {
			return;
		}
		m_collisionMap [tempGameObject.tag] (collision);
	}

	public void RunAction (BasicAction action, BasicAction.DelegateMessage delegateMessage)
	{
		ActionManager.GetInstance ().RunAction (this, action, delegateMessage);
	}

	public virtual void Clear ()
	{
		RemoveAllMessage ();
		ActionManager.GetInstance ().RemoveMonoBehaviour (this);
	}

	protected void AddMessage (string msgName, Message.DelegateMessage msgDelegate)
	{
		m_msgDataList.Add (msgName);
		MessageManager.GetIncestance ().Add (msgName, this.gameObject, msgDelegate);
	}

	protected void AddTrigger (string tag, DelegateTriggerEnter delegateTrigger)
	{
		Assert.IsNotNull (delegateTrigger);
		m_triggerMap.Add (tag, delegateTrigger);
	}

	protected void AddCollision (string tag, DelegateCollisionEnter delegateCollision)
	{
		Assert.IsNotNull (delegateCollision);
		m_collisionMap.Add (tag, delegateCollision);
	}

	protected void RemoveAllMessage ()
	{
		foreach (var item in m_msgDataList) {
			MessageManager.GetIncestance ().Remove (item, this.gameObject);
		}
	}

}
