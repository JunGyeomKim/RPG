using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Shop : MonoBehaviour
{
	UIButton GoldBtn = null;
	UIButton CrystalBtn = null;
	UIButton StaminaBtn = null;
	UIButton CloseBtn = null;

	UISprite GoldBtnSprite = null;
	UISprite CrystalBtnSprite = null;
	UISprite StaminaBtnSprite = null;

	UILabel TitleText = null;
	UILabel Text = null;

	Transform GoldTrans = null;
	Transform CrystalTrans = null;
	Transform StaminaTrans = null;


	bool GoldIsInit = false;
	bool CrystalIsInit = false;
	bool StaminaIsInit = false;

	private void Start()
	{
		transform.localPosition = new Vector3(0, -50, 0);
	}

	private void Awake()
	{

		//Trans Parensts.
		GoldTrans = transform.FindChild("ScrolView").FindChild("Grid").FindChild("Gold").transform;
		CrystalTrans = transform.FindChild("ScrolView").FindChild("Grid").FindChild("Crystral").transform;
		StaminaTrans = transform.FindChild("ScrolView").FindChild("Grid").FindChild("Stamina").transform;	

		//Shop TitleText, Text
		TitleText = transform.FindChild("BackGround").FindChild("TitleText").GetComponent<UILabel>();
		Text = transform.FindChild("BackGround").FindChild("Text").GetComponent<UILabel>();

		//MoneyBtn, Sprite
		Transform trans = transform.FindChild("Money").FindChild("Tap");
		if (trans == null)
		{
			Debug.LogError("Shop_Money is not found");
		}
		GoldBtn = trans.GetComponent<UIButton>();
		EventDelegate.Add(GoldBtn.onClick, new EventDelegate(this, "Gold"));
		trans = null;


		//Crystal Btn
		trans = transform.FindChild("Crystal").FindChild("Tap");
		if (trans == null)
		{
			Debug.LogError("Shop_Crystal is Null");
		}
		CrystalBtn = trans.GetComponent<UIButton>();
		EventDelegate.Add(CrystalBtn.onClick, new EventDelegate(this, "Cryistal"));
		trans = null;


		//Stamamina Btn
		trans = transform.FindChild("Stamina").FindChild("Tap");
		if (trans == null)
		{
			Debug.LogError("Shop_Stamina is Null");
		}
		StaminaBtn = trans.GetComponent<UIButton>();
		EventDelegate.Add(StaminaBtn.onClick, new EventDelegate(this, "Stamina"));
		trans = null;

		//Close Btn
		trans = transform.FindChild("CloseBtn");
		if (trans == null)
		{
			Debug.LogError("Shop_Stamina is Null");
		}
		CloseBtn = trans.GetComponent<UIButton>();
		EventDelegate.Add(CloseBtn.onClick, new EventDelegate(this, "Close"));
		trans = null;



		//Gold Sprtie
		trans = transform.FindChild("Money").FindChild("Tap").FindChild("Image");
		if (trans == null)
		{
			Debug.Log("Money Sprite is NULL");
		}
		GoldBtnSprite = trans.GetComponent<UISprite>();
		trans = null;

		//Crystal Sprtie
		trans = transform.FindChild("Crystal").FindChild("Tap").FindChild("Image");
		if (trans == null)
		{
			Debug.Log("Crystal Sprite is NULL");
		}
		CrystalBtnSprite = trans.GetComponent<UISprite>();
		trans = null;

		//Stamina Sprtie
		trans = transform.FindChild("Stamina").FindChild("Tap").FindChild("Image");
		if (trans == null)
		{
			Debug.Log("Stamina Sprite is NULL");
		}
		StaminaBtnSprite = trans.GetComponent<UISprite>();
		trans = null;

	}

	void SetScrolviewTransform()
	{
		Transform trans = transform.FindChild("ScrolView");
		if (trans == null)
		{
			Debug.Log("Trans is NULL");
		}
		trans.transform.localPosition= new Vector3(0, -66.0f,0.0f);
		trans.GetComponent<UIPanel>().clipOffset = Vector2.zero;
	}


	void Gold()
	{
		SetScrolviewTransform();
		Init(eShopType.SHOP_GOLD);
	}

	void Cryistal()
	{
		SetScrolviewTransform();
		Init(eShopType.SHOP_CRYSTAL);
	}

	void Stamina()
	{
		SetScrolviewTransform();
		Init(eShopType.SHOP_STAMINA);
	}


	void Close()
	{
		UI_Tools.Instance.HideUI(eUIType.PF_UI_SHOP);
	}

	public void Init(eShopType _eShopType)
	{
		switch (_eShopType)
		{
			case eShopType.SHOP_GOLD:
				{
					TitleText.text = "GOLD 구매";
					Text.text = "골드 부족 시, 크리스털로 골드를 구매 하실 수 있습니다.";

					StaminaBtnSprite.color = new Color(0.5f, 0.5f, 0.5f);
					CrystalBtnSprite.color = new Color(0.5f, 0.5f, 0.5f);

					GoldBtnSprite.color = new Color(1.0f, 1.0f, 1.0f);

					ShopManager.Instance.ShowShop(eShopType.SHOP_GOLD, GoldTrans, GoldIsInit);
					HideUI(eShopType.SHOP_GOLD);// 매개변수 제외 HIDE
					GoldIsInit = true;
				}
				break;

			case eShopType.SHOP_CRYSTAL:
				{
					TitleText.text = "CRYSTAL 구매";
					Text.text = "크리스탈 부족 시, 충전을 통하여 구매 하실 수 있습니다.";

					GoldBtnSprite.color = new Color(0.5f, 0.5f, 0.5f);
					StaminaBtnSprite.color = new Color(0.5f, 0.5f, 0.5f);
					CrystalBtnSprite.color = new Color(1.0f, 1.0f, 1.0f);

					ShopManager.Instance.ShowShop(eShopType.SHOP_CRYSTAL, CrystalTrans, CrystalIsInit);
					HideUI(eShopType.SHOP_CRYSTAL);// 매개변수 제외 HIDE

					CrystalIsInit = true;
				}
				break;

			case eShopType.SHOP_STAMINA:
				{
					TitleText.text = "STAMINA 구매";
					Text.text = "스테미너 부족 시, 크리스탈로 충전 하실 수 있습니다.";

					GoldBtnSprite.color = new Color(0.5f, 0.5f, 0.5f);
					CrystalBtnSprite.color = new Color(0.5f, 0.5f, 0.5f);
					StaminaBtnSprite.color = new Color(1.0f, 1.0f, 1.0f);

					ShopManager.Instance.ShowShop(eShopType.SHOP_STAMINA, StaminaTrans, StaminaIsInit);
					HideUI(eShopType.SHOP_STAMINA);// 매개변수 제외 HIDE
					StaminaIsInit = true;
				}
				break;
		}
	}


	void HideUI(eShopType _type)
	{
		switch (_type)
		{
			case eShopType.SHOP_NONE:
				break;
			case eShopType.SHOP_GOLD:
				{
					CrystalTrans.gameObject.SetActive(false);
					StaminaTrans.gameObject.SetActive(false);
				}
				break;
			case eShopType.SHOP_CRYSTAL:
				{
					GoldTrans.gameObject.SetActive(false);
					StaminaTrans.gameObject.SetActive(false);
				}
				break;
			case eShopType.SHOP_STAMINA:
				{
					GoldTrans.gameObject.SetActive(false);
					CrystalTrans.gameObject.SetActive(false);
				}
				break;
			case eShopType.SHOP_MAX:
				break;
			default:
				break;
		}


	}


}

