using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Option : BaseObject
{
	bool IsInit = false;

	

	GameObject OptionPrefab = null;
	UIButton CloseButton = null;
	UIButton SetButton = null;


	UISlider SoundSlider = null;
	UILabel SoundValueText;

	public void Init()
	{
		if (IsInit)
			return;

		OptionPrefab = Resources.Load("Prefabs/UI/PF_UI_OPTION") as GameObject;
		CloseButton = FindInChild("CloseButton").GetComponent<UIButton>();
		EventDelegate.Add(CloseButton.onClick, new EventDelegate(this, "HideOption"));

		SetButton = FindInChild("SetButton").GetComponent<UIButton>();
		EventDelegate.Add(SetButton.onClick, new EventDelegate(this, "SetValue"));

		//sound ProgressBar-------------------------------------------------------
		SoundSlider = FindInChild("SoundSlider").GetComponent<UISlider>();
		EventDelegate.Add(SoundSlider.onChange, new EventDelegate(this, "ChangeValue"));

		SoundValueText = FindInChild("ValueLabel").GetComponent<UILabel>();
		if (SoundSlider == null)
		{
			Debug.Log("sondSlider is null");
		}
		
		SoundSlider.value = (GameManager.Instance.IS_SOUND / 100);//현재 초기값.
		SoundValueText.text = SoundSlider.value.ToString();

		//-------------------------------------------------------------------------
		IsInit = true;
	}

	void ChangeValue()
	{
		SoundValueText.text = ((int)(SoundSlider.value* 100)).ToString();
		
	}
		 


	void HideOption()
	{
		SoundSlider.value = (GameManager.Instance.IS_SOUND / 100);
		SoundValueText.text = ((int)(SoundSlider.value * 100)).ToString();
		UI_Tools.Instance.HideUI(eUIType.PF_UI_OPTION);
		
	}

	public void SetValue()
	{
		GameManager.Instance.IS_SOUND = ((int)(SoundSlider.value * 100));
		PlayerGoodsManager.Instance.SetLocalData();
	}



}

