using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BoltStudios;

public class GameManager : MonoBehaviour
{

	private static GameManager instance;
	public static GameManager Instance
	{
		get
		{
			if(instance == null)
			{
				instance = FindObjectOfType<GameManager>();
			}
			return instance;
		}

	}

	private void Awake()
	{
		if(instance == null)
		{
			instance = this;
		}
	}

	// Start is called before the first frame update
	void Start()
    {
		WarpNetworkManager.Instance.PlayerName = "Geralt";
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
