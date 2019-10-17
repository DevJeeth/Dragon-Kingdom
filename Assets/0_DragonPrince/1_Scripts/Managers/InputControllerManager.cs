using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HedgehogTeam.EasyTouch;
using MalbersAnimations;
using MalbersAnimations.Utilities;
using BoltStudios.Camera;

public class InputControllerManager : MonoBehaviour
{
	private Animal m_refAnimal;
	private FreeCameraRig m_refFreeCameraRig;
	private EffectManager m_refEffectManager;

	private float m_fHorizontal, m_fVertical, m_fLookHorizontal, m_fLookVertical;
	private bool m_bIsError = false;

    void Start()
    {
		//Gets the Animal script component for Dragon inputs
		m_refAnimal = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<Animal>(); ;
		if(m_refAnimal == null)
		{
			Debug.LogError("[PlayerConntrollerManager] Animal not found. Functionality Halted. FIX ISSUE");
		}

		//Gets the FreeCameraRig Component to update the inputs to  it
		m_refFreeCameraRig = GameObject.FindGameObjectWithTag("MainCamera").gameObject.GetComponent<FreeCameraRig>();
		if (m_refFreeCameraRig == null)
		{
			Debug.LogError("[PlayerConntrollerManager] FreeCameraRig not found. Functionality Halted. FIX ISSUE");
		}

	}

   
    void Update()
    {

		if(m_bIsError)
			return;

		//joystick input for movement
		m_fHorizontal = ETCInput.GetAxis("Horizontal");
		m_fVertical  = ETCInput.GetAxis("Vertical");


		//touch input  for free camera
		m_fLookHorizontal = ETCInput.GetAxis("LookHorizontal");
		m_fLookVertical = ETCInput.GetAxis("LookVertical");

		//Movement input
		//m_refAnimal.MovementAxis = new Vector2(m_fHorizontal,m_fVertical);
		m_refAnimal.MovementForward = m_fVertical;
		m_refAnimal.MovementRight = m_fHorizontal;


		//free camera input
		m_refFreeCameraRig.LookHorizontal = m_fLookHorizontal;
		m_refFreeCameraRig.LookVertical = m_fLookVertical;

    }

}
