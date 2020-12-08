using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inventory : BaseObject {

    bool IsInit = false;
    GameObject ItemPrefab = null;

    UIGrid Grid;
    UIButton CloseButton = null;

	
    UILabel WeaponLabel = null;
    UILabel ArmorLabel = null;
    UILabel AccLabel = null;
    UILabel ShieldLabel= null;


	//UI Inventory Eqip Box Player Texture Label
	UILabel WeaponTextureLabel = null;
	UILabel ArmorTextureLabel = null;
	UILabel AccTextureLabel = null;
	UILabel ShieldletTextureLabel = null;

	//UI Inventory Equip Box  Player Texture
	UITexture WeaponTexture = null;
	UITexture ArmorTexture = null;
	UITexture AccTexture = null;
	UITexture ShieldTexture = null;

	//UI Player Load

	GameObject PlayerInventory = null;

	public void Init()
    {
        if (IsInit)
            return;

        ItemPrefab = Resources.Load("Prefabs/UI/PF_UI_ITEM") as GameObject;
        Grid = GetComponentInChildren<UIGrid>();

        CloseButton = FindInChild("CloseButton").GetComponent<UIButton>();
        EventDelegate.Add(CloseButton.onClick, new EventDelegate(this, "HideInventory"));

        WeaponLabel = FindInChild("Weapon").FindChild("ItemName").GetComponent<UILabel>();
        ArmorLabel = FindInChild("Armor").FindChild("ItemName").GetComponent<UILabel>();
		AccLabel = FindInChild("Acc").FindChild("ItemName").GetComponent<UILabel>();
		ShieldLabel = FindInChild("Shield").FindChild("ItemName").GetComponent<UILabel>();

		//UI Inventory Eqip Box Player Texture Label
		WeaponTextureLabel = FindInChild("EquipBox").FindChild("Weapon").FindChild("Text").GetComponent<UILabel>();
		ArmorTextureLabel = FindInChild("EquipBox").FindChild("Armor").FindChild("Text").GetComponent<UILabel>();
		AccTextureLabel = FindInChild("EquipBox").FindChild("Acc").FindChild("Text").GetComponent<UILabel>();
		ShieldletTextureLabel = FindInChild("EquipBox").FindChild("Shield").FindChild("Text").GetComponent<UILabel>();

		//UI Inventory Equip Box  Player Texture
		WeaponTexture = FindInChild("EquipBox").FindChild("Weapon").FindChild("Texture").GetComponent<UITexture>();
		ArmorTexture = FindInChild("EquipBox").FindChild("Armor").FindChild("Texture").GetComponent<UITexture>();
		AccTexture = FindInChild("EquipBox").FindChild("Acc").FindChild("Texture").GetComponent<UITexture>();
		ShieldTexture = FindInChild("EquipBox").FindChild("Shield").FindChild("Texture").GetComponent<UITexture>();

		if (WeaponTextureLabel == null || ArmorTextureLabel == null || AccTextureLabel == null || ShieldletTextureLabel == null)
		{
			Debug.Log("Weapon, Armor, Helmet, Guntlet Texture Label is NULL Check");
		}

		if (WeaponTexture == null || ArmorTexture == null || AccTexture == null || ShieldTexture == null)
		{
			Debug.Log("Weapon, Armor, Helmet, Guntlet Texture is NULL Check");
		}

		
		ShowPlayerModel();
		EquipItemReset();
        ItemManager.Instance.EquipE = EquipItemReset;

        IsInit = true;
    }

    public void Reset()
    {
        for(int i=0;i<Grid.transform.childCount; i++)
        {
            Destroy(Grid.transform.GetChild(i).gameObject);
        }

        AddItem();
    }

    void AddItem()
    {
        List<ItemInstance> list = ItemManager.Instance.LIST_ITEM;
        for(int i = 0; i < list.Count; i++)
        {
            GameObject go = Instantiate(ItemPrefab, Grid.transform) as GameObject;
            go.transform.localScale = Vector3.one;
            go.GetComponent<UI_Item>().Init(list[i]);
        }

        Grid.repositionNow = true;
    }

    public void EquipItemReset()
    {
        Dictionary<eSlotType, ItemInstance> dic = ItemManager.Instance.DIC_EQUIP;

        foreach(var pair in dic)
        {
            switch (pair.Key)
            {
                case eSlotType.SLOT_WEAPON:
                    WeaponLabel.text = pair.Value.ITEM_INFO.NAME;
					WeaponTexture.mainTexture = Resources.Load<Texture>("Textures/" + pair.Value.ITEM_INFO.ITEM_IMAGE);
					break;
                case eSlotType.SLOT_ARMOR:
                    ArmorLabel.text = pair.Value.ITEM_INFO.NAME;
					ArmorTexture.mainTexture = Resources.Load<Texture>("Textures/" + pair.Value.ITEM_INFO.ITEM_IMAGE);
					break;
                case eSlotType.SLOT_ACC:
					AccLabel.text = pair.Value.ITEM_INFO.NAME;
					AccTexture.mainTexture = Resources.Load<Texture>("Textures/" + pair.Value.ITEM_INFO.ITEM_IMAGE);
					break;
                case eSlotType.SLOT_SHIELD:
					ShieldLabel.text = pair.Value.ITEM_INFO.NAME;
					ShieldTexture.mainTexture = Resources.Load<Texture>("Textures/" + pair.Value.ITEM_INFO.ITEM_IMAGE);
					break;
            }
        }
    }

    void HideInventory()
    {
        UI_Tools.Instance.HideUI(eUIType.PF_UI_INVENTORY);
    }

	void ShowPlayerModel()
	{

		//Inventory Player Model
		PlayerInventory = ActorManager.Instance.PlayerInventoryLoad();

		GameObject go = GameObject.Find("TextureCamera");
		//Transform go = this.transform.Find("TextureCamera");
		if (go == null)
		{
			Debug.Log("go is NULL");
		}

		//PlayerModel 초기화

		PlayerInventory.transform.parent = go.transform;

		PlayerInventory.transform.position = (go.transform.position + new Vector3(0, -0.5f ,1.1f));
		PlayerInventory.transform.rotation = new Quaternion(0, 180, 0, 0);
		PlayerInventory.transform.localScale = Vector3.one;

	}


}
