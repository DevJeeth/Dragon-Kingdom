using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HedgehogTeam.EasyTouch;
using MalbersAnimations;
using MalbersAnimations.Utilities;
using BoltStudios.Camera;

public class PlayerControllerManager : MonoBehaviour
{
	private Animal m_refDragonInput;
	private MFreeLookCamera m_refFreeLookCamera;
	private FreeCameraRig m_refFreeCameraRig;
	private EffectManager m_refEffectManager;

	private float m_fHorizontal, m_fVertical, m_fLookHorizontal, m_fLookVertical;

    void Start()
    {
		m_refDragonInput = gameObject.GetComponent<Animal>();
		//m_refFreeLookCamera = GameObject.FindGameObjectWithTag("MainCamera").gameObject.GetComponent<MFreeLookCamera>();
		m_refFreeCameraRig = GameObject.FindGameObjectWithTag("MainCamera").gameObject.GetComponent<FreeCameraRig>();
		if (m_refFreeCameraRig == null)
		{
			Debug.LogError("Camera not found");
		}

	}

   
    void Update()
    {

		if(m_refFreeCameraRig == null)
				return;

		m_fHorizontal = ETCInput.GetAxis("Horizontal");
		m_fVertical  = ETCInput.GetAxis("Vertical");

		m_fLookHorizontal = ETCInput.GetAxis("LookHorizontal");
		m_fLookVertical = ETCInput.GetAxis("LookVertical");


		//m_refDragonInput.MovementAxis = new Vector2(m_fHorizontal,m_fVertical);
		m_refDragonInput.MovementForward = m_fVertical;
		m_refDragonInput.MovementRight = m_fHorizontal;

		//m_refFreeLookCamera.m_fLookHorizontal = m_fLookHorizontal;
		//m_refFreeLookCamera.m_fLookVertical = m_fLookVertical;

		m_refFreeCameraRig.LookHorizontal = m_fLookHorizontal;
		m_refFreeCameraRig.LookVertical = m_fLookVertical;

		if (Input.GetKeyDown(KeyCode.A))
		{
			BoltStudios.Utils.Utilities.s_IsCameraTouchActive = !BoltStudios.Utils.Utilities.s_IsCameraTouchActive;
		}
    }


	private bool m_isFlyState = false;
	public void DragonFlyState()
	{
		m_isFlyState = !m_isFlyState;
		m_refDragonInput.Fly = m_isFlyState;
	}

	public void DragonMeleeAttack(int a_attackValue)
	{
		m_refDragonInput.SetAttack(a_attackValue);
	}

	public void DragonRangeAttack(int a_effectValue)
	{
		m_refDragonInput.SetSecondaryAttack();
		//m_refEffectManager._EnableEffect(111);
	}

	public void CameraTouchArea(bool a_isTouched)
	{
		BoltStudios.Utils.Utilities.s_IsCameraTouchActive = a_isTouched;
	}
}
