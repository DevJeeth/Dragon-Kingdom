using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
	[SerializeField]
	private RectTransform m_rectGameTitle;
	[SerializeField]
	private RectTransform[] m_arrMenuButtons;

	private void Awake()
	{
		DOTween.Init(true, true, LogBehaviour.Default);

		RectTransform rectChild;

		//Moving all UI off the screen
		foreach(Transform child in transform)
		{
			rectChild = child.GetComponent<RectTransform>();
			if (rectChild == null)
				continue;

			rectChild.anchoredPosition = new Vector2(rectChild.anchoredPosition.x - 500, rectChild.anchoredPosition.y);
		}
	}

	// Start is called before the first frame update
	private void Start()
    {
		GameTitleTweenStart();
	}



	private void GameTitleTweenStart()
	{
		m_rectGameTitle.DOAnchorPos(new Vector2(13, -95), 1).OnComplete(GameTitleTweenComplete);
	}

	private void GameTitleTweenComplete()
	{
		Debug.Log("[UIManager] Game Title Tween Complete");
		ButtonTweenStart();
	}

	private void ButtonTweenStart()
	{
		Debug.Log("[UIManager] Button Tween Started");
		m_iCount = 0; 
		for (int i = 0; i<m_arrMenuButtons.Length; i++)
		{
			m_arrMenuButtons[i].DOAnchorPos(new Vector2(73, m_arrMenuButtons[i].anchoredPosition.y), 1).SetDelay(i*0.25f).OnComplete(ButtonTweenComplete);
		}
	}

	private int m_iCount = 0;
	private void ButtonTweenComplete()
	{
		m_iCount++;

		if(m_iCount >= m_arrMenuButtons.Length)
		{
			Debug.Log("[UIManager] Button Tween Complete");
		}
	}


	// Update is called once per frame
	void Update()
    {
        
    }
}
