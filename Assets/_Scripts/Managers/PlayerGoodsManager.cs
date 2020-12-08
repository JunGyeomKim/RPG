using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGoodsManager : MonoSingleton<PlayerGoodsManager>
{

	//	1. 골드, 크리스탈, 고기, 사운드
	// 옵션 따로 빼놓을것.

	public void SetLocalData()
	{
		//	1. 골드, 크리스탈, 고기
		// GOLD _ CRYSTAL _ USE STAMINA |

		//ITEM_ID _ SlotType _ ITEM_NO | ITEM_ID _ SlotType _ ITEM_NO |
		// "1_-1_3 | 2_1_5 | 3_1_5

		string resultStr = string.Empty;


		string goodsStr = string.Empty;

		goodsStr += (GameManager.Instance.IS_GOLD.ToString()) + "_";
		goodsStr += (GameManager.Instance.IS_CRYSTAL.ToString()) + "_";
		goodsStr += (GameManager.Instance.IS_STAMINA.ToString()) + "_";
		goodsStr += (GameManager.Instance.IS_SOUND.ToString());

		resultStr = goodsStr;

		//   PlayerPrefs.SetString =>   /key/로 식별된 Preference의 값을 설정합니다.
		PlayerPrefs.SetString(ConstValue.LocalSave_PlayerGoodsInstance, resultStr);
		Debug.Log(resultStr);

	}


	public void GetLocalData()
	{
		//	1. 골드, 크리스탈, 고기
		// GOLD _ CRYSTAL _ USE STAMINA |
		string instanceStr = PlayerPrefs.GetString(ConstValue.LocalSave_PlayerGoodsInstance, string.Empty);

		if (instanceStr == null)
		{
			Debug.Log("저장된 플레이어 데이터가 없습니다");
			return;
		}

		string[] goodsArray = instanceStr.Split('_');

		for (int i = 0; i < goodsArray.Length; i++)
		{
			if (goodsArray[i].Length <= 0)
				continue;

			switch (i)
			{
				case 0:
					{
						GameManager.Instance.IS_GOLD = int.Parse(goodsArray[i]);
					}
					break;
				case 1:
					{
						GameManager.Instance.IS_CRYSTAL = int.Parse(goodsArray[i]);
					}
					break;
				case 2:
					{
						GameManager.Instance.IS_STAMINA = int.Parse(goodsArray[i]);
					}
					break;
				case 3:
					{
						GameManager.Instance.IS_SOUND = int.Parse(goodsArray[i]);
					}
					break;
			}
		}


	}





}
