using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class ShopManager : MonoSingleton<ShopManager>
{
	
	Dictionary<int, ShopInfo> DicShopInfo = new Dictionary<int, ShopInfo>();
	public Dictionary<int, ShopInfo> DIC_SHOPINFO { get { return DicShopInfo; } }

	//BUY_TO
	Dictionary<eShopType, List<ShopInfo>> DicBuyTo = new Dictionary<eShopType, List<ShopInfo>>();
	public Dictionary<eShopType, List<ShopInfo>> DIC_BUY_TO { get { return DicBuyTo; } }


	Vector3 BaseStart = new Vector3(0.0f, 0.0f, 0.0f);
	float NextStart_X = 320.0f;


	public void ShopInit()
	{
		TextAsset ShopInfo = Resources.Load<TextAsset>("JSON/SHOP_INFO");
		JSONNode rootNode = JSON.Parse(ShopInfo.text);
		
		foreach (KeyValuePair<string, JSONNode> pair in rootNode["SHOP_INFO"] as JSONObject)
		{
			ShopInfo info = new ShopInfo(pair.Key, pair.Value);
			DicShopInfo.Add(int.Parse(info.KEY), info);
			
		}
		

		//List 생성, 넣어주기 값없이.
		for(eShopType type = eShopType.SHOP_NONE; type < eShopType.SHOP_MAX; type++)
		{
			List<ShopInfo> list = new List<ShopInfo>();
			DicBuyTo.Add(type, list);
		}

		foreach (KeyValuePair<int, ShopInfo> item in DicShopInfo)
		{
			switch (item.Value.SLOT_TYPE)
			{
				case eShopType.SHOP_NONE:
					DicBuyTo[eShopType.SHOP_NONE].Add(item.Value);
					break;
				case eShopType.SHOP_GOLD:
					DicBuyTo[eShopType.SHOP_GOLD].Add(item.Value);
					break;
				case eShopType.SHOP_CRYSTAL:
					DicBuyTo[eShopType.SHOP_CRYSTAL].Add(item.Value);
					break;
				case eShopType.SHOP_STAMINA:
					DicBuyTo[eShopType.SHOP_STAMINA].Add(item.Value);
					break;
				default:
					break;
			}
		}

	}

	public ShopInfo ShowShop(eShopType _index, Transform _trans, bool _IsInit)
	{
		if(_IsInit)
		{
			_trans.gameObject.SetActive(true);
			return null;
		}

		_trans.gameObject.SetActive(true);

		ShopInfo info = null;
		List<ShopInfo> list = new List<ShopInfo>();

		DicBuyTo.TryGetValue(_index, out list);

		if (list == null)
		{
			Debug.LogError("Load Shop_DicBuyTo is Null");
		}

		for (int i = 0; i < list.Count; i++)
		{
			GameObject makeUI = null;
			GameObject go = Resources.Load("Prefabs/UI/" + "PF_UI_SHOPITEM") as GameObject;
			go.transform.FindChild("BuyList").FindChild("Text").GetComponent<UILabel>().text = list[i].NAME;
			go.transform.FindChild("BuyList").FindChild("Texure").GetComponent<UITexture>().mainTexture = Resources.Load("Textures/" + list[i].IMAGE) as Texture;

			//Prefabs 복사 이동
			makeUI = NGUITools.AddChild(_trans.gameObject, go);
			if (list[i].BONUS == "NULL")
			{
				makeUI.transform.FindChild("AddList").gameObject.SetActive(false);
			}

			else
			{
				makeUI.transform.FindChild("AddList").FindChild("Text").GetComponent<UILabel>().text = list[i].BONUS;
			}

			makeUI.transform.localPosition = BaseStart;
			if (i != 0)
			{
				makeUI.transform.localPosition = BaseStart + new Vector3(NextStart_X * i, 0, 0);
			}
		}
		return info;
	}

	public void BuyData()
	{

	}





}
