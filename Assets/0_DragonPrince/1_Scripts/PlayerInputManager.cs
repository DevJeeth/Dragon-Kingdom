using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
	private static PlayerInputManager instance;
	public static PlayerInputManager Instance
	{
		get
		{
			if (instance == null)
			{
				instance = FindObjectOfType<PlayerInputManager>();
			}
			return instance;
		}

	}

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
	}


	void Start()
    {
        
    }


	void Update()
	{

	}

	public void CameraTouchArea(bool a_isTouched)
	{
		Debug.Log("<color=red>Camera Input: </color>"+a_isTouched);
		BoltStudios.Utils.Utilities.s_IsCameraTouchActive = a_isTouched;
	}
}
