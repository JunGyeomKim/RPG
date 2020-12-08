using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Resume : BaseObject
{
	
	UIButton ResumeBtn = null;
	UIButton BackBtn = null;
	UIButton CloseBtn = null;

	void Start ()
	{
		//ResumeBtn;
		Transform trans = FindInChild("ResumeBtn");
		if (trans == null)
		{
			Debug.Log("ResumeBtn Is Null");
		}
		ResumeBtn = trans.GetComponent<UIButton>();
		EventDelegate.Add(ResumeBtn.onClick, new EventDelegate(this, "OnResumeBtn"));
		trans = null;

		//BackBtn
		trans = FindInChild("BackBtn");
		if (trans == null)
		{
			Debug.Log("BackBtn Is Null");
		}
		BackBtn = trans.GetComponent<UIButton>();
		EventDelegate.Add(BackBtn.onClick, new EventDelegate(this, "OnBackBtn"));
		trans = null;

		//CloseBtn
		trans = FindInChild("CloseBtn");
		if(trans == null)
		{
			Debug.Log("CloseBtn Is Null");
		}
		CloseBtn = trans.GetComponent<UIButton>();
		EventDelegate.Add(CloseBtn.onClick, new EventDelegate(this, "OnBackBtn"));
	}

	void OnResumeBtn()
	{
		Time.timeScale = 0.0f;
	}

	void OnBackBtn()
	{
		Time.timeScale = 1.0f;
		UI_Tools.Instance.HideUI(eUIType.PF_UI_RESUME);
	}




}
