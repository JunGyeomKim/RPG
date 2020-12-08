using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_SellSelect : BaseObject
{
	UIButton CloseButton = null;
	GameObject SelectPrefab = null;

	UIButton MonsterSelectBtn = null;
	UIButton ItemSelectBtn = null;

	private void Start()
	{
		//----------------------------- 아이템 판매 선택 --------------------------------
		Transform trans = FindInChild("ItemSelectBtn");
		if (trans == null)
		{
			Debug.LogError("ItemSelectBtn is not found");
		}
		ItemSelectBtn = trans.GetComponent<UIButton>();
		EventDelegate.Add(ItemSelectBtn.onClick, new EventDelegate(this, "ShowItemSelectBtn"));


		//--------------------------- 몬스터 판매 선택 ----------------------------------

		trans = FindInChild("MonsterSelectBtn");
		if(trans == null)
		{
			Debug.LogError("MonsterSelectBtn is not found");
		}
		MonsterSelectBtn = trans.GetComponent<UIButton>();
		EventDelegate.Add(MonsterSelectBtn.onClick, new EventDelegate(this, "ShowMonsterSelectBtn"));
	}

	public void Init()
	{
		SelectPrefab = Resources.Load("Prefabs/UI/PF_UI_SellSelect") as GameObject;

		CloseButton = FindInChild("CloseButton").GetComponent<UIButton>();
		EventDelegate.Add(CloseButton.onClick, new EventDelegate(this, "HideSellSelect"));

	}

	void HideSellSelect()
	{
		UI_Tools.Instance.HideUI(eUIType.PF_UI_SellSelect);
	}

	// -------아이템 판매 선택----------
	void ShowItemSelectBtn()
	{
		Debug.Log("ItemSellSelect");
		GameObject go = UI_Tools.Instance.ShowUI(eUIType.PF_UI_ITEMSALE);
		// UI_SellSelect sellselect = go.GetComponent<UI_SellSelect>();
		// sellselect.Init();

		ItemManager.Instance.curUIState = eUIType.PF_UI_ITEMSALE;

		UI_ITEMSALE itemsale = go.GetComponent<UI_ITEMSALE>();
		itemsale.Init();
		itemsale.Reset();


	}

	void ShowMonsterSelectBtn()
	{
		Debug.Log("MonsterSellSelect");
		GameObject go = UI_Tools.Instance.ShowUI(eUIType.PF_UI_MONSTERSALE);

		UI_MONSTERSALE monstersale = go.GetComponent<UI_MONSTERSALE>();
		monstersale.Init();
	}




}

