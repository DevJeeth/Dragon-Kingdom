using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HedgehogTeam.EasyTouch;
using MalbersAnimations;
using MalbersAnimations.Utilities;
using BoltStudios.Camera;

public class InputControllerManager : MonoBehaviour
{
	private Animal m_refDragonInput;
	private FreeCameraRig m_refFreeCameraRig;
	private EffectManager m_refEffectManager;

	private float m_fHorizontal, m_fVertical, m_fLookHorizontal, m_fLookVertical;

    void Start()
    {
		//Gets the Animal script component for Dragon inputs
		m_refDragonInput = gameObject.GetComponent<Animal>();

		//Gets the FreeCameraRig Component to update the inputs to  it
		m_refFreeCameraRig = GameObject.FindGameObjectWithTag("MainCamera").gameObject.GetComponent<FreeCameraRig>();
		if (m_refFreeCameraRig == null)
		{
			Debug.LogError("[PlayerConntrollerManager] FreeCameraRig not found");
		}

	}

   
    void Update()
    {

		if(m_refFreeCameraRig == null)
				return;

		//joystick input for movement
		m_fHorizontal = ETCInput.GetAxis("Horizontal");
		m_fVertical  = ETCInput.GetAxis("Vertical");


		//touch input  for free camera
		m_fLookHorizontal = ETCInput.GetAxis("LookHorizontal");
		m_fLookVertical = ETCInput.GetAxis("LookVertical");

		//Movement input
		//m_refDragonInput.MovementAxis = new Vector2(m_fHorizontal,m_fVertical);
		m_refDragonInput.MovementForward = m_fVertical;
		m_refDragonInput.MovementRight = m_fHorizontal;


		//free camera input
		m_refFreeCameraRig.LookHorizontal = m_fLookHorizontal;
		m_refFreeCameraRig.LookVertical = m_fLookVertical;

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

}
