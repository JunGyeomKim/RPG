using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;


public class ShopInfo
{
	string StrKey = string.Empty;
	string Name = string.Empty;
	string Bonus = string.Empty;
	string BuyTo = string.Empty;
	string BuyEa = string.Empty;
	string Image = string.Empty;
	string BuyTotalName = string.Empty;
	int BuyTotal = 0;

	eShopType SlotType = eShopType.SHOP_NONE;


	//GETTER
	public string KEY { get { return StrKey; } }
	public string NAME { get { return Name; } }
	public string BONUS { get { return Bonus; } }
	public string BUY_TO { get { return BuyTo; } }
	public string BUY_EA { get { return BuyEa; } }
	public string IMAGE { get { return Image; } }
	public string BUY_TOTAL_NAME { get { return BuyTotalName; } }
	public int BUY_TOTAL { get { return BuyTotal; } }
	public eShopType SLOT_TYPE { get { return SlotType; } }
	

	public ShopInfo(string _strKey, JSONNode nodeData)//(Key, Value)
	{
		StrKey = _strKey;
		Name = nodeData["NAME"];
		Bonus = nodeData["BONUS"];
		BuyTo = nodeData["BUY_TO"];
		BuyEa = nodeData["BUY_EA"];
		Image = nodeData["IMAGE"];
		BuyTotal = nodeData["BUY_TOTAL"];
		BuyTotalName = nodeData["BUY_TOTAL_NAME"];

		SlotType = (eShopType)int.Parse(nodeData["SLOT_TYPE"]);
		
	}
}
