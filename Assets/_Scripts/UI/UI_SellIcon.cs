using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_SellIcon : BaseObject
{

	StageInfo Info = null;
	public StageInfo INFO { get { return Info; } }

	UILabel StageName = null;

	public void Init(StageInfo _info)
	{
		Info = _info;
		StageName = this.GetComponentInChildren<UILabel>();
		StageName.text = Info.NAME;

	}

	public void OnClick()
	{
		GameObject go = UI_Tools.Instance.ShowUI(eUIType.PF_UI_POPUP);
		UI_Popup popup = go.GetComponent<UI_Popup>();

		popup.Set(() =>
		{
			Debug.Log(Info.NAME + " 판매");

			UI_Tools.Instance.HideUI(eUIType.PF_UI_POPUP);
		},
		() =>
		{
			UI_Tools.Instance.HideUI(eUIType.PF_UI_POPUP);
		},
		"아이템 판매",
		"해당 아이템을 " + Info.NAME + "판매하시겠습니까?"
		);


	}

}
