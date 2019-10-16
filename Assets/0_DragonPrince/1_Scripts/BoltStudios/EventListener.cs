using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventListener : MonoBehaviour
{
	public UnityEvent m_UnityEvent;
	public BoltStudios.Event.Events m_Event;

	private void OnEnable()
	{
		m_Event.RegisterEvent(this);
	}

	private void OnDisable()
	{
		m_Event.RegisterEvent(this);
	}

}
