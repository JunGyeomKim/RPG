using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_InGame : BaseObject {

    //GameObject SkillStatePrefab = null;

    //Skill
    UIButton FirstSkillBtn = null;
    public UIButton SecondSkillBtn = null;

    //Resume
    UIButton ResumeBtn = null;

    //Possession
    UIButton PossessionBtn = null;
    UILabel PossessionLabel = null;
    public UILabel POSSESSION_LABEL
    {
        get { return PossessionLabel; }
    }

	UISprite AutoCheckBtn = null;
	public UISprite AUTO_CHECK_BTN
	{
		get { return AutoCheckBtn; }
	}

    //State
    HPBoard HP = null;

    void Awake()
    {
        //SkillState
        //SkillStatePrefab = Resources.Load("Prefabs/UI/PF_UI_SKILLSTATE") as GameObject;
        //if (SkillStatePrefab == null)
        //{
        //    Debug.LogError("Prefabs/UI 의 경로에 PF_UI_SKILLSTATE이름의 프리팹이 없습니다.");
        //}
        //GameObject skillState = Instantiate(SkillStatePrefab);
        GameObject skillState = UI_Tools.Instance.ShowUI(eUIType.PF_UI_SKILLSTATE);
        skillState.transform.localPosition = new Vector3(-410, -305, 0);
        FirstSkillBtn = skillState.transform.FindChild("1_SKILL").GetComponent<UIButton>();
        SecondSkillBtn = skillState.transform.FindChild("2_SKILL").GetComponent<UIButton>();
        //eventDelegate 연결해줘야함
        EventDelegate.Add(FirstSkillBtn.onClick, new EventDelegate(this, "FirstSkill"));
        EventDelegate.Add(SecondSkillBtn.onClick, new EventDelegate(this, "SecondSkill"));
        SecondSkillBtn.gameObject.SetActive(false);

		//Resume

		ResumeBtn = FindInChild("ResumeBtn").GetComponent<UIButton>();
		EventDelegate.Add(ResumeBtn.onClick, new EventDelegate(this, "Resume"));

		//Possession

		PossessionBtn = FindInChild("Possession Btn").GetComponent<UIButton>();
        EventDelegate.Add(PossessionBtn.onClick, new EventDelegate(this, "Possession"));
        PossessionLabel = PossessionBtn.transform.FindChild("Text").GetComponent<UILabel>();

        //State
        HP = FindInChild("HPBar").GetComponent<HPBoard>();
    }

    public void SetDataHit(string strKey, double maxHP, double currHP)
    {
        HP.SetData(strKey, maxHP, currHP);
    }

    void Possession()
    {
        GameManager.Instance.Possession();
        SecondSkillBtn.gameObject.SetActive(true);
    }
    void FirstSkill()
    {

    }
    void SecondSkill()
    {
        ActorManager.Instance.SpecterScript.SpecterAttack();
    }

	void Resume()
	{
		UI_Tools.Instance.ShowUI(eUIType.PF_UI_RESUME);
	}
}
