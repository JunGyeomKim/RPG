using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MainStageIcon : BaseObject {
	int stageKey = 0;

	Dictionary<int, StageInfo> dictionaryInfo = null;
	public Dictionary<int, StageInfo> DICTIONARYINFO
	{
		get { return dictionaryInfo; }
	}

	UILabel StageName = null;

	public void Init(int _key, Dictionary<int, StageInfo> _dictionaryInfo)
	{
		dictionaryInfo = _dictionaryInfo;
		StageName = this.GetComponentInChildren<UILabel>();
		StageName.text = "Stage " + _key.ToString();
		stageKey = _key;
	}

	public void OnClick()
	{
		GameObject go = UI_Tools.Instance.ShowUI(eUIType.PF_UI_STAGE);
		UI_Stage Stage = go.GetComponent<UI_Stage>();
		Stage.Init(stageKey);
	}
}
