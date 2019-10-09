using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class MenuTimelineManager : MonoBehaviour
{

	public TimelineAsset m_timeline;
	private Playable m_director;
	private Dictionary<string, double> m_dicMarkers = new Dictionary<string, double>();
	private Marker m_marker;
    void Start()
    {
		m_director = GetComponent<Playable>();

	}


    void Update()
    {
        
    }
}
