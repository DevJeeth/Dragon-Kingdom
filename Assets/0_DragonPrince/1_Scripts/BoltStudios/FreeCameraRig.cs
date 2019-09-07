using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BoltStudios.Utils;

namespace BoltStudios.Camera
{
	public class FreeCameraRig : MonoBehaviour
	{

		//Child Pivot to which camera is a child of
		private Transform m_tCameraPivot;


		private float m_fLookVertical;
		public float LookVertical { get => m_fLookVertical; set => m_fLookVertical = value; }

		private float m_fLookHorizontal;
		public float LookHorizontal { get => m_fLookHorizontal; set => m_fLookHorizontal = value; }

		private bool m_bError = false;
		private float m_fLookAngle;                                 // The rig's y axis rotation.
		private float m_TiltAngle;                                  // The pivot's x axis rotation.
		private Quaternion m_PivotTargetRot;
		private Quaternion m_TransformTargetRot;
		public float m_TiltMax = 45f;                               // The maximum value of the x axis rotation of the pivot.
		public float m_TiltMin = 25f;                               // The minimum value of the x axis rotation of the pivot.


		private Transform m_tRefRig;

		[Header("Target to follow")]
		public GameObject m_gTarget;

		[Header("Follow Camera turn speed")]
		public float m_fFollowTurnSpeed = 4;

		[Header("Camera possition follow speed")]
		public float m_fMoveSpeed = 2;

		[Header("free Camera turn speed")]
		public float m_fTurnSpeed = 2;

		[Header("Smooth Slerp Value")]
		[Range(0f, 5f)]
		public float m_fSmoothRotation;

		[Header("Camera parent follow will be done")]
		public eCameraUpdateType eCameraType;


		void Start()
		{
			m_tCameraPivot = transform.GetChild(0);
			m_tRefRig = transform;

			if (m_tCameraPivot == null)
			{
				m_bError = true;
				Debug.LogError("[FreeCameraRig] Pivot not found. Functionality Halted. FIX ISSUE");
			}

		}

		protected void FollowTarget(float deltaTime)
		{
			if (m_gTarget == null) return;

			transform.position = Vector3.Lerp(transform.position, m_gTarget.transform.position, deltaTime * m_fMoveSpeed);  // Move the rig towards target position.
		}


		void Update()
		{

			if (m_bError)
			{
				return;
			}

			if (eCameraType == eCameraUpdateType.Update)
			{
				FollowTarget(Time.deltaTime);
			}
		}

		private void LateUpdate()
		{

			if (m_bError)
			{
				return;
			}

			if (eCameraType == eCameraUpdateType.LateUpdate)
			{
				FollowTarget(Time.deltaTime);
			}

			//if the free cam is activated by touching lower right side of screen dont do this, move to else block
			if (!BoltStudios.Utils.Utilities.s_IsCameraTouchActive)
			{
				transform.rotation = Quaternion.Slerp(transform.rotation, m_gTarget.transform.rotation, Time.deltaTime * m_fFollowTurnSpeed);
				m_tCameraPivot.localRotation = Quaternion.Slerp(m_tCameraPivot.localRotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * m_fSmoothRotation/2);
			}
			else
			{

				//Stop the camera rotation if the user has stopped moving finger
				if (m_fLookHorizontal == 0)
				{
					m_fLookAngle = Mathf.Lerp(m_fLookAngle,0,Time.deltaTime * m_fTurnSpeed/2);
				}
				else
				{
					//Y axis transform rotation based on finger movement
					m_fLookAngle += Mathf.Clamp(m_fLookHorizontal, -1, 1) * m_fTurnSpeed;
				}

				Debug.Log("[FreeCameraRig] Look angle: "+m_fLookAngle+" The horizontal input value: " +m_fLookHorizontal);
				transform.eulerAngles += new Vector3(0, m_fLookAngle, 0) * Time.deltaTime;	

				//X axis pivot rotation
				m_TiltAngle -= Mathf.Clamp(LookVertical, -1, 1) * m_fTurnSpeed;                                                 // on platforms with a mouse, we adjust the current angle based on Y mouse input and turn speed
				m_TiltAngle = Mathf.Clamp(m_TiltAngle, -m_TiltMin, m_TiltMax);                                                  // and make sure the new value is within the tilt range

				m_PivotTargetRot = Quaternion.Euler(m_tCameraPivot.localRotation.x + m_TiltAngle, 0, 0);
				m_tCameraPivot.localRotation = Quaternion.Slerp(m_tCameraPivot.localRotation, m_PivotTargetRot, Time.deltaTime * m_fSmoothRotation / 2);

			}
		}

		private void FixedUpdate()
		{

			if (m_bError)
			{
				return;
			}

			if (eCameraType == eCameraUpdateType.FixedUpdate)
			{
				FollowTarget(Time.fixedDeltaTime);
			}
		}

		//When the joystick is moved reset the camera to moving camera
		public void SetCameraToFolowOnMoving()
		{
			if (coroutine != null)
			{
				Debug.Log("<color=red> free camera corountine stopped & ref removed</color>");
				StopCoroutine(coroutine);
				coroutine = null;
			}
			BoltStudios.Utils.Utilities.s_IsCameraTouchActive = false;
			Debug.Log("<color=purple> Reset camera to moving</color>");
		}


		//this is used to switch between free camera and defeault follow camera
		Coroutine coroutine;
		public void CameraControlActive(bool a_isActive)
		{
			if (coroutine != null)
			{
				Debug.Log("<color=red> free camera corountine stopped & ref removed</color>");
				StopCoroutine(coroutine);
				coroutine = null;
			}

			if (!a_isActive)
			{
				coroutine = StartCoroutine(DelayResetCamera(2f, a_isActive));
			}
			else
			{
				coroutine = StartCoroutine(DelayResetCamera(0f, a_isActive));
			}

			m_fLookAngle = 0f;
			m_TiltAngle = 0f;
		}


		IEnumerator DelayResetCamera(float a_fdelay, bool a_isTouched)
		{
			Debug.Log("<color=purple>[InputControllerManager] START DelayResetCamera: " + a_fdelay + " State: " + a_isTouched+"</color>");
			yield return new WaitForSeconds(a_fdelay);

			Debug.Log("<color=purple>[InputControllerManager] ENDED DelayResetCamera: " + a_fdelay + " State: " + a_isTouched + "</color>");
			BoltStudios.Utils.Utilities.s_IsCameraTouchActive = a_isTouched;
			if (coroutine != null)
			{
				Debug.Log("<color=red> free camera corountine stopped & ref removed</color>");
				StopCoroutine(coroutine);
				coroutine = null;
			}
		}
	}
}
