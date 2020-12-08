using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ShopItem : BaseObject
{

	UIButton BuyBtn = null;

	eShopType ThisShopType = eShopType.SHOP_NONE;

	int BuyTotal;
	string BuyName = string.Empty;
	string ShopType = string.Empty;

	string BuyTo = string.Empty;
	string BuyEa = string.Empty;
	string Total = string.Empty;
	string BuyTotalName = string.Empty;


	void Start()
	{
		
		Transform trans = transform.FindChild("BuyBtn");
		if (trans == null)
		{
			Debug.LogError("UI_SHOP BuyBtn is Null");
		}
		BuyBtn = trans.GetComponent<UIButton>();
		EventDelegate.Add(BuyBtn.onClick, new EventDelegate(this, "OnClickBuyBtn"));

		
	}

	void OnClickBuyBtn()
	{
		//Total 구매량 체크
		for (int i = 1; i < ShopManager.Instance.DIC_SHOPINFO.Count; i++)
		{
			//Debug.Log(i + " DIC 체크");
			if (ShopManager.Instance.DIC_SHOPINFO[i].NAME == this.transform.FindChild("BuyList").FindChild("Text").GetComponent<UILabel>().text)
			{
				BuyTotal = ShopManager.Instance.DIC_SHOPINFO[i].BUY_TOTAL;
				BuyName = ShopManager.Instance.DIC_SHOPINFO[i].NAME;
				ThisShopType = ShopManager.Instance.DIC_SHOPINFO[i].SLOT_TYPE;
				BuyTo = ShopManager.Instance.DIC_SHOPINFO[i].BUY_TO;
				BuyEa = ShopManager.Instance.DIC_SHOPINFO[i].BUY_EA;
				BuyTotalName = ShopManager.Instance.DIC_SHOPINFO[i].BUY_TOTAL_NAME;
			}
			
		}


		//타입 체크
		switch (ThisShopType)
		{
			case eShopType.SHOP_NONE:
				break;
			case eShopType.SHOP_GOLD:
				{
					ShopType = "GOLD 구매";
				}
				break;
			case eShopType.SHOP_CRYSTAL:
				{
					ShopType = "CRTSTAL 구매";
				}
				break;
			case eShopType.SHOP_STAMINA:
				{
					ShopType = "STAMINA 구매";
				}
				break;
			case eShopType.SHOP_MAX:
				break;
			default:
				break;
		}

		GameObject go = UI_Tools.Instance.ShowUI(eUIType.PF_UI_POPUP);
		UI_Popup popup = go.GetComponent<UI_Popup>();

		popup.Set(() =>
		{
			//값 정보 저장.
			SetGoods();//삭제 추가.
			UI_Tools.Instance.HideUI(eUIType.PF_UI_POPUP);
		},
		() =>
		{
			UI_Tools.Instance.HideUI(eUIType.PF_UI_POPUP);
		},
			ShopType
		,
			"\n구매시" + BuyTo + " " + BuyEa + " 가 필요 합니다. \n\n" + BuyName + "을 구매 하시겠습니까??"
		);

	}

	void AddGoods()
	{
		//상점 구매 +
		switch (BuyTotalName)
		{
			case "GOLD"://골드구매
				{
					GameManager.Instance.IS_GOLD = GameManager.Instance.IS_GOLD + BuyTotal;//골드 구매
					PlayerGoodsManager.Instance.SetLocalData();

					GameObject go = GameObject.Find("PF_UI_TOPPLAYERSTATE");
					UI_TopPlayerState Top = go.GetComponent<UI_TopPlayerState>();
					Top.SetAllGoods();
					
				}
				break;

			case "CRYSTAL"://크리스탈구매
				{
					GameManager.Instance.IS_CRYSTAL = GameManager.Instance.IS_CRYSTAL + BuyTotal;//크리스탈 구매
					PlayerGoodsManager.Instance.SetLocalData();

					GameObject go = GameObject.Find("PF_UI_TOPPLAYERSTATE");
					UI_TopPlayerState Top = go.GetComponent<UI_TopPlayerState>();
					Top.SetAllGoods();
				}
				break;

			case "STAMINA"://스테미너 구매
				{
					GameManager.Instance.IS_STAMINA = GameManager.Instance.IS_STAMINA + BuyTotal;// 스테미너 구매.
					PlayerGoodsManager.Instance.SetLocalData();

					GameObject go = GameObject.Find("PF_UI_TOPPLAYERSTATE");
					UI_TopPlayerState Top = go.GetComponent<UI_TopPlayerState>();
					Top.SetAllGoods();
				}
				break;
		}

	}

	void OnErrorPopup()
	{
		GameObject go = UI_Tools.Instance.ShowUI(eUIType.PF_UI_ERROR_POPUP);
		UI_ErrorPopup ErrorPopup = go.GetComponent<UI_ErrorPopup>();

		ErrorPopup.Set(() =>
		{
			UI_Tools.Instance.HideUI(eUIType.PF_UI_ERROR_POPUP);
		},

		"오류!"
		,
		"보유 하신 재화가 부족하여\n 물품을 구매 할 수 없습니다."
		);
	}

	void SetGoods()
	{
		switch (BuyTo)
		{
			case "GOLD"://골드 차감
				{
					if (GameManager.Instance.IS_GOLD >= int.Parse(BuyEa))
					{
						GameManager.Instance.IS_GOLD = GameManager.Instance.IS_GOLD - int.Parse(BuyEa);
						AddGoods();
					}
					else
						OnErrorPopup();

				}
				break;

			case "CRYSTAL"://크리스탈 차감
				{
					if (GameManager.Instance.IS_CRYSTAL >= int.Parse(BuyEa))
					{
						GameManager.Instance.IS_CRYSTAL = GameManager.Instance.IS_CRYSTAL - int.Parse(BuyEa);
						AddGoods();
					}
					else
						OnErrorPopup();


				}
				break;

			case "STAMINA"://스테미너 차감
				{
					if (GameManager.Instance.IS_STAMINA >= int.Parse(BuyEa))
					{
						GameManager.Instance.IS_STAMINA = GameManager.Instance.IS_STAMINA - int.Parse(BuyEa);
						AddGoods();
					}
					else
						OnErrorPopup();

				}
				break;
		}
	}

}


