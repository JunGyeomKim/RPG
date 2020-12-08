using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_StageIcon : BaseObject {

    StageInfo Info = null;
    public StageInfo INFO { get { return Info; } }

	int stageNum = 0;
	UILabel UseStamina = null;
    UILabel StageName = null;

    public void Init(int _stageNum, StageInfo _info)
    {
        Info = _info;
        StageName = this.FindInChild("StageName").GetComponent<UILabel>();
        StageName.text = Info.NAME;
		stageNum = _stageNum;
		UseStamina = this.FindInChild("UseStamina").GetComponent<UILabel>();
		UseStamina.text = INFO.USE_STAMINA;
    }

    public void OnClick()
    {
		GameObject go = UI_Tools.Instance.ShowUI(eUIType.PF_UI_POPUP);
		UI_Popup popup = go.GetComponent<UI_Popup>();

		popup.Set(
			() =>
			{
				Debug.Log(Info.NAME + " 입장");
				GameManager.Instance.STAGENUM = stageNum;
				GameManager.Instance.STAGEKEY = INFO.KEY;

				Scene_Manager.Instance.LoadScene(eSceneType.SCENE_GAME);
				UI_Tools.Instance.HideUI(eUIType.PF_UI_POPUP);
			}
			,

			() =>
			{
				UI_Tools.Instance.HideUI(eUIType.PF_UI_POPUP);
			},
			"스테이지 선택",
			"스테이지 " + INFO.NAME + " 을 입장하시겠습니까?"
			);
	}

}
