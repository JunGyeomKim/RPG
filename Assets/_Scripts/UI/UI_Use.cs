using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Use : BaseObject
{

	UseInstance UseInst;
	public UseInstance USE_INSTANCE
	{
		get { return UseInst; }
		set { UseInst = value; }
	}

	//GameObject UsePrefab = null;
	UILabel Label = null;

	public void Init(UseInstance instance)
	{
		UseInst = instance;
		Label = GetComponentInChildren<UILabel>();
		Label.text = UseInst.USE_INFO.NAME;

		//UsePrefab = Resources.Load("Prefabs/Actor/" + UseInst.USE_NO) as GameObject;


	}

	void OnClick()
	{
		GameObject go = UI_Tools.Instance.ShowUI(eUIType.PF_UI_POPUP);
		UI_Popup popup = go.GetComponent<UI_Popup>();

		popup.Set(() =>
		{
			UI_Tools.Instance.HideUI(eUIType.PF_UI_POPUP);
		},
		() =>
		{
			UI_Tools.Instance.HideUI(eUIType.PF_UI_POPUP);
		},
		"몬스터 빙의"
		,
		"이 몬스터로 빙의하시겠습니까??"
		);

	}
}
	

