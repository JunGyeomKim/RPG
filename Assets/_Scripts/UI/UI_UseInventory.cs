using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_UseInventory : BaseObject
{

	bool IsInit = false;
	GameObject UseInventoryPrefab = null;

	UIGrid Grid;
	UIButton CloseButton = null;

	UILabel GradeLabel = null;
	UILabel UseName = null;


	//인벤토리 참고해서 제작할 것
	public void Init()
	{
		if (IsInit)
			return;

		UseInventoryPrefab = Resources.Load("Prefabs/UI/PF_UI_USE") as GameObject;
		Grid = GetComponentInChildren<UIGrid>();

		CloseButton = FindInChild("CloseButton").GetComponent<UIButton>();
		EventDelegate.Add(CloseButton.onClick, new EventDelegate(this, "HideUseInventory"));
	}


	public void Reset()
	{
		for (int i = 0; i < Grid.transform.childCount; i++)
		{
			Destroy(Grid.transform.GetChild(i).gameObject);
		}

		AddUse();
	}


	void AddUse()
	{

		List<UseInstance> list = GachaManager.Instance.LIST_USE;
		for (int i = 0; i < list.Count; i++)
		{
			GameObject go = Instantiate(UseInventoryPrefab, Grid.transform) as GameObject;
			go.transform.localScale = Vector3.one;
			go.GetComponent<UI_Use>().Init(list[i]);
		}

		Grid.repositionNow = true;
	}

	void HideUseInventory()
	{
		UI_Tools.Instance.HideUI(eUIType.PF_UI_USEINVENTORY);
	}
}
