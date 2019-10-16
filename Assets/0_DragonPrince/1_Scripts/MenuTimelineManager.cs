using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class MenuTimelineManager : MonoBehaviour
{

	PlayableDirector _director;

	Dictionary<string, double> m_dicMarkerInfo = new Dictionary<string, double>();
	Dictionary<string, double> m_dicEnvmarkerInfo = new Dictionary<string, double>();

	private string m_strCurrentClipName = "";
	[SerializeField]
	private BoltStudios.Event.Events m_Events;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{

	}

	private void OnDestroy()
	{
	}

	// Use this for initialization
	void Start()
	{
		_director = GetComponent<PlayableDirector>();

		if (_director == null)
		{
			Debug.LogError("_director is null");
			return;
		}

		TimelineAsset timelineAsset = _director.playableAsset as TimelineAsset;
		MarkerTrack markerTrack = timelineAsset.markerTrack;

		Debug.Log("Markers Count : " + markerTrack.GetMarkerCount().ToString());
		foreach (Marker marker in markerTrack.GetMarkers())
		{
			SignalEmitter emitter = marker as SignalEmitter;

			//Debug.LogError("[Marker Adding] " + marker.name + " " + marker.time + " " + emitter.asset.name);
			m_dicMarkerInfo.Add(marker.name, marker.time);
		}


		if(BoltStudios.Utils.Utilities.MenuState == BoltStudios.Utils.eMenuState.None)
		{
			_director.Play();
		}
		
	}


	// Update is called once per frame
	void Update()
	{

		if (Input.GetKeyUp(KeyCode.Space))
		{
			//Debug.Log("Space bar pressed: " + m_dicMarkerInfo["StartSignal_GrandPa_Idle_Standing_" + m_ShotName]);
			//GoToMarker("GrandPa_Idle_Standing_" + m_ShotName, true);
		}
	}

	/// <summary>
	/// Takes the Clips Name to Go to the Marker on the Director
	/// </summary>
	/// <param name="a_strMakerName"></param>
	/// <param name="a_bIsPlay"></param>
	private void GoToMarker(string a_strMakerName, bool a_bIsPlay)
	{

		if (_director.state == PlayState.Playing)
			_director.Stop();

		if (!m_dicMarkerInfo.ContainsKey("StartSignal_" + a_strMakerName))
		{
			Debug.LogError("[ArtDirector] The Clip name doesnt exist, check clip name sent : " + a_strMakerName);
			return;
		}


		m_strCurrentClipName = a_strMakerName;
		_director.time = m_dicMarkerInfo["StartSignal_" + a_strMakerName];
		_director.Play();
		//TODO: Need to Check for the Clip Name   

	}

	public void ReceivePauseSignal()
	{
		Debug.Log("[ArtDirect] Received Pause Signal");
		_director.Pause();

		if(BoltStudios.Utils.Utilities.MenuState == BoltStudios.Utils.eMenuState.None)
		{
			m_Events.TriggerEvent();
		}
	}
}
