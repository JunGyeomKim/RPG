using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Clear : BaseObject
{

	UIButton GoLobbyBtn = null;
	UIButton RetryBtn = null;

	UILabel TimeText = null;
	
	private void Start()
	{
		//Retry Btn
		Transform trans = FindInChild("RetryBtn");
		if(trans == null)
		{
			Debug.Log("UI_CLEAR  RetryBtn is NULL");
		}
		RetryBtn = trans.GetComponent<UIButton>();
		trans = null;

		//GoLobby Btn
		trans = FindInChild("GoLobbyBtn");
		if (trans == null)
		{
			Debug.Log("UI_CLEAR  GoLobbyBtn is NULL");
		}
		GoLobbyBtn = trans.GetComponent<UIButton>();
		trans = null;

		// Time Text
		trans = FindInChild("ClearTime").FindChild("TimeGround").FindChild("Text");
		if (trans == null)
		{
			Debug.Log("UI_CLEAR  GoLobbyBtn is NULL");
		}
		TimeText = trans.GetComponent<UILabel>();
		trans = null;

		EventDelegate.Add(RetryBtn.onClick, new EventDelegate(this, "OnRetry"));
		EventDelegate.Add(GoLobbyBtn.onClick, new EventDelegate(this, "OnGoLobby"));
	}

	void OnRetry()
	{
		//데이터 저장할것
		UI_Tools.Instance.HideUI(eUIType.PF_UI_CLEAR);
		Scene_Manager.Instance.LoadScene(eSceneType.SCENE_GAME, true);
	}

	void OnGoLobby()
	{
		//데이터 저장.
		UI_Tools.Instance.HideUI(eUIType.PF_UI_CLEAR);
		Scene_Manager.Instance.LoadScene(eSceneType.SCENE_LOBBY);
	}


}
