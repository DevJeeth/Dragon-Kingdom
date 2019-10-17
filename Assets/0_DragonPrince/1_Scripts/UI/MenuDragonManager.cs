using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeplayVR.Base;
using FluffyUnderware.Curvy.Controllers;

namespace DragonLore
{
	public class MenuDragonManager : MonoBehaviour
	{
		public ParticleSystem m_particleDust;
		public AudioClip m_audioWing;
		private AudioSource m_audioSource;

		private SplineController m_refSplineController;


		private void OnEnable ()
		{
			if (EventManager.Instance != null)
				EventManager.Instance.RegisterEvent<DragonSettingsEvent>(DragonChangeState);
		}

		private void OnDisable()
		{
			if (EventManager.Instance != null)
				EventManager.Instance.DeRegisterEvent<DragonSettingsEvent>(DragonChangeState);
		}

		private void Awake()
		{
			
		}

		void Start()
		{
			m_audioSource = GetComponent<AudioSource>();
			m_audioSource.clip = m_audioWing;
			
		}

		void Update()
		{

		}

		public void DragonChangeState(IEventBase a_Event)
		{
			DragonSettingsEvent data = a_Event as DragonSettingsEvent;
			if (data == null)
				return;

			Debug.Log("[MenuDragonManager] Move the Dragon");
			m_refSplineController.Play();
		}

		public void WingsSoundEffect()
		{
			m_audioSource.Play();
		}

		public void WingsCloudEffect()
		{
			m_particleDust.Play();
		}
	}
}
