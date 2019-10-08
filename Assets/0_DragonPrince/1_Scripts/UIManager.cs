using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	[SerializeField]
	private Text m_textLogToUI;
	private GameManager m_refGameManager;

	private void Awake()
	{
		Application.logMessageReceived += GameLogs;
	}

	// Start is called before the first frame update
	private void Start()
    {
		m_refGameManager = FindObjectOfType<GameManager>();
		if(m_refGameManager == null)
		{
			Debug.LogError("[UIManager] GameManager reference not found");
		}
		
	}

	private void GameLogs(string logString, string stackTrace, LogType type)
	{
		if (m_textLogToUI == null)
			return;

		m_textLogToUI.text += "\n" + type.ToString() + logString;
	}

	public void StartServerConnection()
	{
		WarpNetworkManager.Instance.ConnectedToServer();
	}


	// Update is called once per frame
	void Update()
    {
        
    }
}
