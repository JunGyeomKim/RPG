using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ITEMSALE : BaseObject
{
	UIButton CloseButton = null;
	GameObject SelectPrefab = null;
	UIGrid Grid;
	GameObject ItemPrefab = null;

	//UIScrollView ScrollView = null;

	UIButton SortPriceBtn = null;

	public void Init()
	{
		ItemPrefab = Resources.Load("Prefabs/UI/PF_UI_ITEM") as GameObject;
		Grid = GetComponentInChildren<UIGrid>();

		SelectPrefab = Resources.Load("Prefabs/UI/PF_UI_ITEMSALE") as GameObject;

		CloseButton = FindInChild("CloseButton").GetComponent<UIButton>();
		EventDelegate.Add(CloseButton.onClick, new EventDelegate(this, "HideITEMSALE"));

		//ScrollView = FindInChild("ScrolView").GetComponent<UIScrollView>();

		SortPriceBtn = FindInChild("SortPriceButton").GetComponent<UIButton>();
		EventDelegate.Add(SortPriceBtn.onClick, new EventDelegate(this, "SortPrice")); //범용성을 위한 다른 방법도 있을 것이다.

		//EventDelegate.Add(SortPriceBtn.onClick, () =>
		//{
		//	SortPrice();
		//}
		//);

		

	}


	public void Reset()
	{
		for (int i = 0; i < Grid.transform.childCount; i++)
		{
			Destroy(Grid.transform.GetChild(i).gameObject);
		}

		AddItem();
	}

	void AddItem()
	{
		List<ItemInstance> list = ItemManager.Instance.LIST_ITEM;
		for (int i = 0; i < list.Count; i++)
		{
			GameObject go = Instantiate(ItemPrefab, Grid.transform) as GameObject;
			go.transform.localScale = Vector3.one;
			go.GetComponent<UI_Item>().Init(list[i]);
		}

		Grid.repositionNow = true;
	}

	void HideITEMSALE()
	{
		//Reset();
		UI_Tools.Instance.HideUI(eUIType.PF_UI_ITEMSALE);

	}

	//0702 선택정렬을 이용하여 가장 높은 가격의 아이템을 그리드에서 먼저 출력하도록 재정렬 함
	void SortPrice()
	{
	

		List<ItemInstance> list = ItemManager.Instance.LIST_ITEM;
		List<ItemInstance> TempList = new List<ItemInstance>();     //Templist를 사용하는 이유는 ItemManager.Instance.LIST_ITEM로 받아온 리스트를 이용하면
			//List를 전달, Class를 받아오므로 ItemManager.Instance.LIST_ITEM의 list를 직접적으로 건들게 된다.
			//때문에 값복사를 위해 새로 Templist를 할당한다.
			//이렇게 하지 않으면 인벤토리에서도, 후에 SALE창을 들어와도 특정 순으로 정렬된 것이 계속 남아있을 것이다.


		for (int i = 0; i < list.Count; i++)
		{
			TempList.Add(list[i]);			//새로 할당한 list에 값복사를 실시.
		}

			for (int i = 0; i < TempList.Count-1; i++)		//선택정렬을 이용하여 가장 큰 값을 앞으로 옮긴다.
		{
			for (int j = i; j < TempList.Count; j++)
			{
				if(TempList[i].ITEM_INFO.PRICE< TempList[j].ITEM_INFO.PRICE)
				{
					ItemInstance Temp = TempList[i];
					TempList[i] = TempList[j];
					TempList[j] = Temp;
				}
				
			}
			
		}

			//이후는 사실 Reset과 유사하나, TempList를 이용해야 하는 것에 유의한다.
		for (int i = 0; i < Grid.transform.childCount; i++)
		{
			Destroy(Grid.transform.GetChild(i).gameObject);
		}

		for (int i = 0; i < TempList.Count; i++)
		{
			GameObject go = Instantiate(ItemPrefab, Grid.transform) as GameObject;
			go.transform.localScale = Vector3.one;
			go.GetComponent<UI_Item>().Init(TempList[i]);
		}

		Grid.repositionNow = true;

	}

	//void UpdateItem()
	//{
	//	for (int j = 0; j < Grid.transform.childCount; j++)

	//	{

	//		NGUITools.Destroy(Grid.transform.GetChild(j).gameObject); ion();

	//	}

	//	Grid.transform.DetachChildren(); // <-중요. 안 할 경우 지워진 child가 계속 남아있을 수 있음...


	//	//Grid.Reposition();
	//	//ScrollView.ResetPosition();
	//	List<ItemInstance> list = ItemManager.Instance.LIST_ITEM;
	//	for (int i = 0; i < list.Count; i++)
	//	{

	//		GameObject go = Instantiate(ItemPrefab, Grid.transform) as GameObject;
	//		go.transform.localScale = Vector3.one;
	//		go.GetComponent<UI_Item>().Init(list[i]);
	//	}

	//	//Grid.repositionNow = true;
	//}





}