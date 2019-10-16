using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoltStudios.Event
{
	[CreateAssetMenu(fileName = "New Event", menuName = "Create Event", order = 52)]
	public class Events : ScriptableObject
	{
		private List<EventListener> m_lstEventListner = new List<EventListener>();

		public void RegisterEvent(EventListener a_EventListener)
		{
			m_lstEventListner.Add(a_EventListener);
		}

		public void DeregisterEvent(EventListener a_EventListener)
		{
			if (m_lstEventListner.Contains(a_EventListener))
			{
				m_lstEventListner.Remove(a_EventListener);
			}
		}

		public void TriggerEvent()
		{
			for (int i = 0; i < m_lstEventListner.Count; i++)
			{
				m_lstEventListner[i].m_UnityEvent.Invoke();
			}
		}

	}
}
