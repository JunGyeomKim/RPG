using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class UI_MainStage : BaseObject
{
	bool IsInit = false;

	GameObject IconPrefab = null;
	UIGrid Grid = null;

	UIButton CloseButton = null;
	UIPanel ScrolPanel = null;

	public void Init()
	{
		SetScrolViewPos();
		if (IsInit == true)
			return;

		IconPrefab = Resources.Load("Prefabs/UI/PF_UI_MAINSTAGEICON") as GameObject;
		Grid = GetComponentInChildren<UIGrid>();
		CloseButton = GetComponentInChildren<UIButton>();
		EventDelegate.Add(CloseButton.onClick, () =>
		{
			UI_Tools.Instance.HideUI(eUIType.PF_UI_MAINSTAGE);
		});


		AddIcon();
		IsInit = true;
	}

	void AddIcon()
	{
		Dictionary<int, Dictionary<int, StageInfo>> tempDictionary = StageManager.Instance.DIC_STAGEINFO;

		foreach (KeyValuePair<int, Dictionary<int, StageInfo>> pair in tempDictionary)
		{
			GameObject go = NGUITools.AddChild(Grid.gameObject, IconPrefab);
			UI_MainStageIcon stageIcon = go.GetComponent<UI_MainStageIcon>();
			stageIcon.Init(pair.Key, pair.Value);
		}

		Grid.repositionNow = true;
	}

	void SetScrolViewPos()
	{
		Transform trans = FindInChild("StageScroll").FindChild("StagePanel");
		if(trans == null)
		{
			Debug.LogError("MainStage_ Scoll trans is NUll");
		}
		trans.transform.localPosition = new Vector3(-310, 0, 0);
		ScrolPanel = trans.GetComponent<UIPanel>();
		ScrolPanel.clipOffset = new Vector2(310, 0);
	}

}

