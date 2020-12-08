using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_PlayerGacha : BaseObject
{
	bool IsInit = false;

	GameObject PlayerGachaPrefab;
	Transform CharacterGacha;
	Transform ItemGacha;


	UIButton CloseButton = null;

	UIButton CharacterButton = null;
	UISprite CharacterSprite = null;

	UIButton ItemButton = null;
	UISprite ItemSprite = null;

	UIButton SingleItemGachaButton = null;
	UIButton ContinuityItemGachaButton = null;


	UIButton SingleCharacterGachaButton = null;
	UIButton ContinuityCharacterGachaButton = null;

	public void Init()
	{
		if (IsInit)
			return;
		
		
		PlayerGachaPrefab = Resources.Load("Prefabs/UI/PF_UI_PLAYERGACHA")as GameObject;

		
		CharacterGacha = FindInChild("CHARACTERGACHA").GetComponent<Transform>();
		ItemGacha = FindInChild("ITEMGACHA").GetComponent<Transform>();


		CloseButton = FindInChild("CloseButton").GetComponent<UIButton>();
		EventDelegate.Add(CloseButton.onClick, new EventDelegate(this, "HidePlayerGacha"));

		CharacterButton = FindInChild("CharacterButton").GetComponent<UIButton>();
		CharacterSprite = CharacterButton.transform.FindChild("Image").GetComponent<UISprite>();
		EventDelegate.Add(CharacterButton.onClick, new EventDelegate(this, "CharacterSelect"));

		ItemButton = FindInChild("ItemButton").GetComponent<UIButton>();
		ItemSprite = ItemButton.transform.FindChild("Image").GetComponent<UISprite>();
		EventDelegate.Add(ItemButton.onClick, new EventDelegate(this, "ItemSelect"));

		CharacterGacha.gameObject.SetActive(true);
		ItemGacha.gameObject.SetActive(false);


		//------------------------------------------------------------------------------------------------------------------------------------------
		SingleItemGachaButton = FindInChild("SingleItemGacha").GetComponent<UIButton>();
		EventDelegate.Add(SingleItemGachaButton.onClick,
			() =>
			{
				ItemManager.Instance.Gacha();
			});


		ContinuityItemGachaButton = FindInChild("ContinuityItemGacha").GetComponent<UIButton>();
		EventDelegate.Add(ContinuityItemGachaButton.onClick,
			() =>
			{
				ItemManager.Instance.ContinuityGacha();
			});

		//------------------------------------------------------------------------------------------------------------------------------------------

		SingleCharacterGachaButton = FindInChild("SingleCharacterGacha").GetComponent<UIButton>();
		EventDelegate.Add(SingleCharacterGachaButton.onClick,
			() =>
			{
				GachaManager.Instance.Gacha();
			});

		ContinuityCharacterGachaButton = FindInChild("ContinuityCharacterGacha").GetComponent<UIButton>();
		EventDelegate.Add(ContinuityCharacterGachaButton.onClick,
			() =>
			{
				GachaManager.Instance.Gacha();
			});

		//------------------------------------------------------------------------------------------------------------------------------------------

		//EventDelegate.Add(SingleItemGachaButton.onClick, new EventDelegate(this, "HideSingleItemGacha"));
		//EventDelegate.Add(ContinuityItemGachaButton.onClick, new EventDelegate(this, "HideSingleItemGacha"));
		//EventDelegate.Add(SingleCharacterGachaButton.onClick, new EventDelegate(this, "HideSingleItemGacha"));
		//EventDelegate.Add(ContinuityCharacterGachaButton.onClick, new EventDelegate(this, "HideSingleItemGacha"));


		IsInit = true;

	}

	void HidePlayerGacha()
	{
		UI_Tools.Instance.HideUI(eUIType.PF_UI_PLAYERGACHA);
	}

	void CharacterSelect()
	{
		CharacterSprite.spriteName = "blue_pressed_colored";
		ItemSprite.spriteName = "red_pressed_colored";
		CharacterGacha.gameObject.SetActive(true);
		ItemGacha.gameObject.SetActive(false);
	}

	void ItemSelect()
	{
		CharacterSprite.spriteName = "red_pressed_colored";
		ItemSprite.spriteName = "blue_pressed_colored";
		CharacterGacha.gameObject.SetActive(false);
		ItemGacha.gameObject.SetActive(true);
	}

	void HideSingleItemGacha()
	{
		UI_Tools.Instance.HideUI(eUIType.PF_UI_PLAYERGACHA);
	}
}
