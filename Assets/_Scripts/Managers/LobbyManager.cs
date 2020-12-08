using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager : MonoSingleton<LobbyManager>
{
	GameObject go = null;
	Transform TopPlayerState = null;
	UI_TopPlayerState Top = null;

	public void LoadLobby()
	{
		//로비 불러오기
		go = UI_Tools.Instance.ShowUI(eUIType.PF_UI_LOBBY);		
	}

	public void DisableLobby()
	{
		UI_Tools.Instance.HideUI(eUIType.PF_UI_LOBBY);
	}

}
