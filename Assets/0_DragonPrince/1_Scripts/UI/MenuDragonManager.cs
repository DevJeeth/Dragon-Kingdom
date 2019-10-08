using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeplayVR.Base;

namespace DragonLore
{
	public class MenuDragonManager : MonoBehaviour
	{
		public ParticleSystem m_particleDust;
		public AudioClip m_audioWing;
		private AudioSource m_audioSource;

		void Start()
		{
			m_audioSource = GetComponent<AudioSource>();
			m_audioSource.clip = m_audioWing;
		}


		void Update()
		{

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
