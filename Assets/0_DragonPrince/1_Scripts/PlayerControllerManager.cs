using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HedgehogTeam.EasyTouch;
using MalbersAnimations;

public class PlayerControllerManager : MonoBehaviour
{
	private Animal m_refDragonInput;
	private MFreeLookCamera m_refFreeLookCamera;

	private float m_fHorizontal, m_fVertical, m_fLookHorizontal, m_fLookVertical;

    void Start()
    {
		m_refDragonInput = gameObject.GetComponent<Animal>();
		m_refFreeLookCamera = GameObject.FindGameObjectWithTag("MainCamera").gameObject.GetComponent<MFreeLookCamera>();

		if(m_refFreeLookCamera == null)
		{
			Debug.LogError("Camera not found");
		}

	}

   
    void Update()
    {

		if(m_refFreeLookCamera == null)
				return;

		m_fHorizontal = ETCInput.GetAxis("Horizontal");
		m_fVertical  = ETCInput.GetAxis("Vertical");

		m_fLookHorizontal = ETCInput.GetAxis("LookHorizontal");
		m_fLookVertical = ETCInput.GetAxis("LookVertical");

		//m_refDragonInput.MovementAxis = new Vector2(m_fHorizontal,m_fVertical);
		m_refDragonInput.MovementForward = m_fVertical;
		m_refDragonInput.MovementRight = m_fHorizontal;

		m_refFreeLookCamera.m_fLookHorizontal = m_fLookHorizontal;
		m_refFreeLookCamera.m_fLookVertical = m_fLookVertical;
    }


	private bool m_isFlyState = false;
	public void DragonFlyState()
	{
		m_isFlyState = !m_isFlyState;
		m_refDragonInput.Fly = m_isFlyState;
	}
}
