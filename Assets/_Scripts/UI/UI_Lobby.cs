using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Lobby : BaseObject {


    UIButton StageButton = null;
    UIButton GachaButton = null;
    UIButton InvenButton = null;
	UIButton OptionButton = null;
	UIButton SellButton = null;
	UIButton UseButton = null;


	private void Awake()
    {
		
		//StageButton-------------------------------------------------------------------------------------

		Transform trans = FindInChild("StageButton");
        if (trans == null)
        {
            Debug.LogError("StageButton is not found");
        }
        StageButton = trans.GetComponent<UIButton>();
        EventDelegate.Add(StageButton.onClick, new EventDelegate(this, "ShowStage"));
		
		
		//기존의 가챠 코드
		//-------------------------------------------------------------------------------------------------
		//trans = FindInChild("GachaButton");
		//if (trans == null)
		//{
		//    Debug.LogError("GachaButton is not found");
		//}
		//GachaButton = trans.GetComponent<UIButton>();
		//EventDelegate.Add(GachaButton.onClick, () =>
		//{
		//    ItemManager.Instance.Gacha();
		//});
		//------------------------------------------------------------------------------------------------------
		
		//준케이 수정코드는 밑부터 시작합니다.
		trans = FindInChild("GachaButton");
		if (trans == null)
		{
			Debug.LogError("GachaButton is not found");
		}
		GachaButton = trans.GetComponent<UIButton>();
		EventDelegate.Add(GachaButton.onClick, new EventDelegate(this, "PlayerGachaButton"));
		//--------------------------------------------------------------------------------------------------




		//inventoryButton----------------------------------------------------------------------------------------
		trans = FindInChild("InventoryButton");
        if (trans == null)
        {
            Debug.LogError("InventoryButton is not found");
        }
        InvenButton= trans.GetComponent<UIButton>();
        EventDelegate.Add(InvenButton.onClick, new EventDelegate(this, "ShowInventory"));
		//--------------------------------------------------------------------------------------------------



		// OptionButton--------------------------------------------------------------------------
		trans = FindInChild("OptionButton");
		if (trans == null)
		{
			Debug.LogError("OptionButton is not found");
		}
		OptionButton = trans.GetComponent<UIButton>();
		EventDelegate.Add(OptionButton.onClick, new EventDelegate(this, "showOption"));
		trans = null;
		//---------------------------------------------------------------------------------------


		//Sell Button-------------------------
		trans = FindInChild("SellButton");
		if(trans == null)
		{
			Debug.LogError("LOBBY_ SellButton is NULL");
		}
		SellButton = trans.GetComponent<UIButton>();
		EventDelegate.Add(SellButton.onClick, new EventDelegate(this, "ShowSellButton"));

		//---------------------------------------------------------------------------------------

		//Top Player State
		GameObject go = UI_Tools.Instance.ShowUI(eUIType.PF_UI_TOPPLAYERSTATE);
		UI_TopPlayerState Top = go.GetComponent<UI_TopPlayerState>();
		Top.Init();
		Top.SetAllGoods();

		//Use Button(07-06추가)
		trans = FindInChild("UseButton");
		if (trans == null)
		{
			Debug.LogError("LOBBY_ Use Button is NULL");
		}
		UseButton = trans.GetComponent<UIButton>();
		EventDelegate.Add(UseButton.onClick, new EventDelegate(this, "ShowUseButton"));
		//------------------------------------------------------------------------------------------------


	}

	void ShowStage()
    {
        GameObject go = UI_Tools.Instance.ShowUI(eUIType.PF_UI_MAINSTAGE);
        UI_MainStage mainStage = go.GetComponent<UI_MainStage>();
        mainStage.Init();
    }

	void ShowInventory()
	{
		GameObject go = UI_Tools.Instance.ShowUI(eUIType.PF_UI_INVENTORY);
		UI_Inventory inven = go.GetComponent<UI_Inventory>();
		inven.Init();
		inven.Reset();
	}

	void showOption()
	{
		GameObject go = UI_Tools.Instance.ShowUI(eUIType.PF_UI_OPTION);
		UI_Option option = go.GetComponent<UI_Option>();
		option.Init();
	}

	void PlayerGachaButton()
	{
		GameObject go = UI_Tools.Instance.ShowUI(eUIType.PF_UI_PLAYERGACHA);
		UI_PlayerGacha playerGacha = go.GetComponent<UI_PlayerGacha>();
		playerGacha.Init();
	}


	void ShowSellButton()
	{
		GameObject go = UI_Tools.Instance.ShowUI(eUIType.PF_UI_SellSelect);
		UI_SellSelect Sell = go.GetComponent<UI_SellSelect>();
		Sell.Init();
	}

	void ShowUseButton()
	{
		GameObject go = UI_Tools.Instance.ShowUI(eUIType.PF_UI_USEINVENTORY);
		UI_UseInventory UseInventory = go.GetComponent<UI_UseInventory>();
		UseInventory.Init();
		UseInventory.Reset();
	}
}
