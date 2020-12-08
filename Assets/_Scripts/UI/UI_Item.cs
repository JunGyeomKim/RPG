using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Item : MonoBehaviour {

    ItemInstance ItemInst;
    public ItemInstance ITEM_INSTANCE
    {
        get { return ItemInst; }
        set { ItemInst = value; }
    }

    UILabel Label = null;
    UITexture Texture = null;

	UITexture HelmetInventoryTextrue = null;
		

    public void Init(ItemInstance instance)
    {
        ItemInst = instance;

        Label = GetComponentInChildren<UILabel>();
        Texture = GetComponentInChildren<UITexture>();

        Label.text = ItemInst.ITEM_INFO.NAME;
        Texture.mainTexture = Resources.Load<Texture>("Textures/" + ItemInst.ITEM_INFO.ITEM_IMAGE);
		
    }

    void OnClick()
    {
        GameObject go = UI_Tools.Instance.ShowUI(eUIType.PF_UI_POPUP);
        UI_Popup popup = go.GetComponent<UI_Popup>();

		if (ItemManager.Instance.curUIState == eUIType.PF_UI_ITEMSALE)
		{
			popup.Set(() =>
			{

				//판매하기
				ItemManager.Instance.SellItem(ItemInst);

				GameObject.Find("PF_UI_ITEMSALE").GetComponent<UI_ITEMSALE>().Reset();  //0701, Reset()을 통해 Grid의 리스트를 업데이트 한다.


				UI_Tools.Instance.HideUI(eUIType.PF_UI_POPUP);
			},
		() =>
		{
			UI_Tools.Instance.HideUI(eUIType.PF_UI_POPUP);
		},
		"아이템 판매"
		,
		"이 아이템을 판매하시겠습니까??"
		);

		}

		if (ItemManager.Instance.curUIState == eUIType.PF_UI_INVENTORY)
		{
			popup.Set(() =>
			{

				ItemManager.Instance.EquipItem(ItemInst); //장착하기

				UI_Tools.Instance.HideUI(eUIType.PF_UI_POPUP);
			},
		() =>
		{
			UI_Tools.Instance.HideUI(eUIType.PF_UI_POPUP);
		},
		"장비 장착"
		,
		"이 장비를 착용하시겠습니까??"
		);
		}

	}


}
