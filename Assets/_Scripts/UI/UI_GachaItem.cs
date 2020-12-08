using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_GachaItem : BaseObject
{
	Transform textureTrans;
	UIButton ItemClick;
	// Use this for initialization
	void Start ()
	{
		
		textureTrans = FindInChild("Texture");
		textureTrans.rotation = Quaternion.Euler(0, 90, 0);

		ItemClick = FindInChild("BackGround").GetComponent<UIButton>();
		EventDelegate.Add(ItemClick.onClick, new EventDelegate(this, "CallCoroutine"));
		
	}

	private void Update()
	{
	}
	void CallCoroutine()
	{
		StartCoroutine("RotateItem");

	}

	IEnumerator RotateItem()
	{

		float time = 0;
		while(true)
		{
			if (time < 1)
			{
				time += Time.deltaTime;
				textureTrans.rotation = Quaternion.Lerp(textureTrans.rotation, Quaternion.Euler(0, 0, 0), 0.1f);
				yield return new WaitForEndOfFrame();
			}
			else
				break;

		}
		
	}
}
