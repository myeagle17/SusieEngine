using Susie;
using System;
using UnityEngine;

public class SSTimeRecord{
	private float 	m_time = 0.0f;
	private float   m_startTime = -1.0f;


	public void StartRecord()
	{
		m_time = 0.0f;
		m_startTime = UnityEngine.Time.timeSinceLevelLoad;
	}

	public void PauseRecord()
	{
		m_time += UnityEngine.Time.timeSinceLevelLoad - m_startTime;
	}

	public void Resume(){
		m_startTime = UnityEngine.Time.timeSinceLevelLoad;
	}

	public void EndRecord()
	{
		m_time += UnityEngine.Time.timeSinceLevelLoad - m_startTime;
		m_startTime = -1.0f;
	}

	public float GetTIme()
	{
		float result = m_time;
		if (m_startTime >= 0) {
			result += UnityEngine.Time.timeSinceLevelLoad - m_startTime;
		}
		return result;
	}
}