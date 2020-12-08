using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Stage : MonoBehaviour {

    bool IsInit = false;
	int stageNum = 0;

	int ChildNum = 0;

    GameObject IconPrefab;
    UIGrid Grid;

    UIButton CloseButton;

    public void Init(int _stageNum)
    {
		stageNum = _stageNum;

        if (IsInit == true)
		{
			DeleteIcon();
			AddIcon();

			return;
		}
		IconPrefab = Resources.Load("Prefabs/UI/PF_UI_STAGEICON") as GameObject;
		Grid = GetComponentInChildren<UIGrid>();
		CloseButton = GetComponentInChildren<UIButton>();
		EventDelegate.Add(CloseButton.onClick, () =>
		{
			UI_Tools.Instance.HideUI(eUIType.PF_UI_STAGE);
		});

		AddIcon();

		IsInit = true;
    }

	void DeleteIcon()
	{
		for (int i = 0; i < ChildNum; i++)
		{
			Transform transform = Grid.transform.GetChild(i);			
			if (transform != null)
			{
				Destroy(transform.gameObject);
			}
		}
		ChildNum = 0;
	}


	void AddIcon()
    {
		Dictionary<int, StageInfo> tempDictionary = StageManager.Instance.DIC_STAGEINFO[stageNum];

		foreach (KeyValuePair<int, StageInfo> pair in tempDictionary)
        {
            GameObject go = NGUITools.AddChild(Grid.gameObject, IconPrefab);
			UI_StageIcon stageIcon= go.GetComponent<UI_StageIcon>();
			stageIcon.Init(stageNum, pair.Value);
			ChildNum++;
		}

        Grid.repositionNow = true;

    }


}
