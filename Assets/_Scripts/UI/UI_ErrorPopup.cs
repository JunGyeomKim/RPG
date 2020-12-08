using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void ErrorEvent();

public class UI_ErrorPopup : BaseObject
{
	UILabel TitleLabel = null;
	UILabel ContentLabel = null;

	UIButton ConfirmationButton = null;


	ErrorEvent Error;


	private void Awake()
	{
		TitleLabel = FindInChild("Title").GetComponent<UILabel>();
		ContentLabel = FindInChild("Content").GetComponent<UILabel>();

		ConfirmationButton = FindInChild("ConfirmationButton").GetComponent<UIButton>();

		EventDelegate.Add(ConfirmationButton.onClick, new EventDelegate(this, "OnClickConfirmationButton"));

	}

	public void Set(ErrorEvent _error, string _title, string _content)
	{
		Error = _error;
		TitleLabel.text = _title;
		ContentLabel.text = _content;
	}



	public void OnClickConfirmationButton()
	{
		if (Error != null)
		{

			Error();
		}
	}



}
