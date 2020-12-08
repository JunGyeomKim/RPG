using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_TopPlayerState : BaseObject
{
	UIButton GoldBuyBtn = null;
	UIButton CyristalBuyBtn = null;
	UIButton StaminaBuyBtn = null;

	UILabel GoldText = null;
	UILabel CrystalText = null;
	UILabel StaminaText = null;


	public void	Init()
	{
		//데이터 초기값 ScenManager에서 가져옴.

		this.transform.localPosition = new Vector3(0, 320, 0);

		//Gold Btn
		Transform trans = FindInChild("Gold");
		if (trans == null)
		{
			Debug.LogError("GoldBuyBtn is not found");
		}
		GoldBuyBtn = trans.FindChild("BuyBtn").GetComponent<UIButton>();
		GoldText = trans.FindChild("Text").GetComponent<UILabel>();
		trans = null;

		//Cyristal Btn
		trans = FindInChild("Crystal");
		if (trans == null)
		{
			Debug.LogError("Cyristal is not found");
		}

		CyristalBuyBtn = trans.FindChild("BuyBtn").GetComponent<UIButton>();
		CrystalText = trans.FindChild("Text").GetComponent<UILabel>();
		trans = null;

		//Stamina Btn

		trans = FindInChild("Stamina");
		if (trans == null)
		{
			Debug.LogError("Cyristal is not found");
		}
		StaminaBuyBtn = trans.FindChild("BuyBtn").GetComponent<UIButton>();
		StaminaText = trans.FindChild("NowText").GetComponent<UILabel>();
		trans = null;



		EventDelegate.Add(GoldBuyBtn.onClick, new EventDelegate(this, "Gold"));
		EventDelegate.Add(CyristalBuyBtn.onClick, new EventDelegate(this, "Cyristal"));
		EventDelegate.Add(StaminaBuyBtn.onClick, new EventDelegate(this, "Stamina"));

	}


	void Gold()
	{
		GameObject go = UI_Tools.Instance.ShowUI(eUIType.PF_UI_SHOP);
		UI_Shop shop = go.GetComponent<UI_Shop>();
		shop.Init(eShopType.SHOP_GOLD);
		//ShopManager.Instance.LoadShop();
	}

	void Cyristal()
	{
	
		GameObject go = UI_Tools.Instance.ShowUI(eUIType.PF_UI_SHOP);
		UI_Shop shop = go.GetComponent<UI_Shop>();
		shop.Init(eShopType.SHOP_CRYSTAL);

	}

	void Stamina()
	{
		GameObject go = UI_Tools.Instance.ShowUI(eUIType.PF_UI_SHOP);
		UI_Shop shop = go.GetComponent<UI_Shop>();
		shop.Init(eShopType.SHOP_STAMINA);

	}

	public void SetGoldText(int gold)
	{
		GoldText.text = gold.ToString();
	}
	
	public void SetAllGoods()
	{
		PlayerGoodsManager.Instance.GetLocalData();
		GoldText.text = GameManager.Instance.IS_GOLD.ToString();
		CrystalText.text = GameManager.Instance.IS_CRYSTAL.ToString();
		StaminaText.text = GameManager.Instance.IS_STAMINA.ToString();
	}
		
}
