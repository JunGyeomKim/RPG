using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_11Gacha : BaseObject
{
	
	const int GachaMax = 10;

	
	UITexture Texture = null;

	ItemInstance ItemInst = null;
	Transform ItemPrefabs = null;
	Transform go = null;

	List<Transform> GachaList = new List<Transform>();
	public ItemInstance ITEM_INSTANCE
	{
		get { return ItemInst; }
		set { ItemInst = value; }
	}


	public void Init(ItemInstance instance, Vector3 _pos)
	{
		Vector3 pos = _pos;
		ItemInst = instance;
		ItemPrefabs = FindInChild("PF_UI_GACHAITEM");
		

		go = (Transform)Instantiate(ItemPrefabs, pos, Quaternion.identity);
		go.name = "PF_UI_GACHAITEM";
		go.parent = this.transform;
		go.localScale = Vector3.one;
		GachaList.Add(go);
		Texture = FindInChild("Texture").GetComponent<UITexture>();
		Texture.mainTexture = Resources.Load<Texture>("Textures/" + ItemInst.ITEM_INFO.ITEM_IMAGE);

	}



	public void YesClick()
	{
		for (int i = 0; i < GachaList.Count; i++)
		{
			Destroy(GachaList[i].gameObject);
		}

		GachaList.Clear();
		UI_Tools.Instance.HideUI(eUIType.PF_UI_11GACHA);

	}
}
