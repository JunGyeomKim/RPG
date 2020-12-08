using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MONSTERSALE : BaseObject
{
	UIButton CloseButton = null;
	GameObject SelectPrefab = null;

	public void Init()
	{
		SelectPrefab = Resources.Load("Prefabs/UI/PF_UI_MONSTERSALE") as GameObject;

		CloseButton = FindInChild("CloseButton").GetComponent<UIButton>();
		EventDelegate.Add(CloseButton.onClick, new EventDelegate(this, "HideMONSTERSALE"));

	}

	void HideMONSTERSALE()
	{
		UI_Tools.Instance.HideUI(eUIType.PF_UI_MONSTERSALE);
	}
}
