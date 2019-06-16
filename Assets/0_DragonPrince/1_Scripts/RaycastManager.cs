using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastManager : MonoBehaviour
{

	[Header("Layers to hit")]
	public LayerMask m_layermaskRayCastInput;
	[Header("Ray Distance")]
	public float m_fRayDistance;


	private DragonBehaviour m_refDragonBehaviour;
	private bool m_bIsError = false;

	// Start is called before the first frame update
	void Start()
	{
		m_refDragonBehaviour = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<DragonBehaviour>();
		if(m_refDragonBehaviour == null)
		{
			m_bIsError = true;
			Debug.LogError("[RaycastManager] DragonBehaviour not found. Functionality Halted. FIX ISSUE");
		}
	}

	// Update is called once per frame
	void Update()
	{

		if(m_bIsError)
		{
			return;
		}

#if UNITY_EDITOR
		EditorMouseInput();
#else
		MobileTouchInput()
#endif

	}

	void EditorMouseInput()
	{
		RaycastHit hit;
		if (Input.GetMouseButtonDown(0))
		{
			Debug.Log("[RaycastManager] Mouse input");
			// Construct a ray from the current touch coordinates
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			// Create a particle if hit
			if (Physics.Raycast(ray, out hit, m_fRayDistance, m_layermaskRayCastInput, QueryTriggerInteraction.Ignore))  //m_layermaskRayCastInput,out hit,QueryTriggerInteraction.Collide
			{
				Debug.Log("<color=orange>[RaycastManager] Raycset hit: " + hit.transform.name + "</color>");
				if (hit.transform.CompareTag("Enemy"))
				{
					Debug.Log("<color=red>[RaycastManager] The enemy has been selected, Fire ball attack</color>");
					LookAtSelectedTarget(hit.transform);
				}
			}
		}
	}

	void MobileTouchInput()
	{
		RaycastHit hit;
		for (var i = 0; i < Input.touchCount; ++i)
		{
			if (Input.GetTouch(i).phase == TouchPhase.Began)
			{
				Debug.Log("[RaycastManager] Touch input");
				// Construct a ray from the current touch coordinates
				Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
				// Create a particle if hit
				if (Physics.Raycast(ray, out hit, m_fRayDistance, m_layermaskRayCastInput, QueryTriggerInteraction.Ignore))  //m_layermaskRayCastInput,out hit,QueryTriggerInteraction.Collide
				{
					Debug.Log("<color=orange>[RaycastManager] Raycset hit: " + hit.transform.name + "</color>");
					if (hit.transform.CompareTag("Enemy"))
					{
						Debug.Log("<color=red>[RaycastManager] The enemy has been selected, Fire ball attack</color>");
					}
				}

			}
		}
	}

	void LookAtSelectedTarget(Transform a_tTarget)
	{
		if (a_tTarget == null)
		{
			Debug.LogError("[RaycastManager] The target transform is empty");
			return;
		}

		m_refDragonBehaviour.LookAtSelectedTarget(true, a_tTarget);
	}


}
