using MalbersAnimations;
using MalbersAnimations.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonBehaviour : MonoBehaviour
{
	private GameObject m_gDragonPlayer;
	private Animal m_refAnimal;
	private LookAt m_refLookAt;

	void Start()
    {
		m_gDragonPlayer = GameObject.FindGameObjectWithTag("Player").gameObject;
		m_refAnimal = m_gDragonPlayer.GetComponent<Animal>();
		m_refLookAt = m_gDragonPlayer.GetComponent<LookAt>();
	}

	private bool m_isFlyState = false;
	public void DragonFlyState()
	{
		m_isFlyState = !m_isFlyState;
		m_refAnimal.Fly = m_isFlyState;
	}

	public void DragonMeleeAttack(int a_attackValue)//3 (Test Values)
	{
		m_refAnimal.SetAttack(a_attackValue);
	}

	public void DragonRangeAttack(int a_effectValue)//111 (Test Values)
	{
		m_refAnimal.SetSecondaryAttack();
		//m_refEffectManager._EnableEffect(111);
	}

	public void LookAtSelectedTarget(bool a_bAttack, Transform a_tTarget = null)
	{
		if (a_tTarget == null)
		{
			Debug.Log("<color=green>[RaycastManager] The target transform is empty</color>");
			m_refLookAt.NoTarget();
			return;
		}

		m_refLookAt.Target = a_tTarget;

		Debug.Log("<color=green>[RaycastManager] Target accepted, looking at selected target</color>");
		if (a_bAttack)
		{
			Debug.Log("<color=green>[RaycastManager] Attack enabled, Fireball</color>");
			DragonRangeAttack(111);
		}
	}

}
