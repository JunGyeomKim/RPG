using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class GachaManager : MonoSingleton<GachaManager>
{

	//현재 갖고있는 몬스터(플레이어)
	List<UseInstance> ListUse = new List<UseInstance>();
	Dictionary<int, UseInfo> dicUseInfo = new Dictionary<int, UseInfo>();


	public List<UseInstance> LIST_USE { get { return ListUse; } }
	public Dictionary<int, UseInfo> DIC_USEINFO { get { return dicUseInfo; } }
	
	
	public void UseInit()
	{
		//Use Load
		TextAsset useInfo = Resources.Load<TextAsset>("JSON/USE_INFO");
		JSONNode rootNode = JSON.Parse(useInfo.text);

		foreach(KeyValuePair<string,JSONNode>pair in rootNode["USE_INFO"] as JSONObject)
		{
			UseInfo info = new UseInfo(int.Parse(pair.Key), pair.Value);
			dicUseInfo.Add(info.KEY, info);
		}
		GetLocalData();
	}
	
	public void GetLocalData()
	{
		//ITEM_ID _ SlotType _ ITEM_NO | ITEM_ID _ SlotType _ ITEM_NO |
		//	 PlayerPrefs.GetString =>	Preference 파일에 존재하는 /key/에 대응하는 값을 반환합니다.
		string instanceStr = PlayerPrefs.GetString(ConstValue.LocalSave_UseUInstance, string.Empty);

		string[] array = instanceStr.Split('|');

		for (int i = 0; i < array.Length; i++)
		{
			if (array[i].Length <= 0)
				continue;

			string[] detail = array[i].Split('_');

			if (detail.Length < 3)
				continue;

			int useId = int.Parse(detail[0]);
			
			UseInfo info = null;

			dicUseInfo.TryGetValue(int.Parse(detail[2]), out info);
			if (info == null)
			{
				Debug.LogError("ID :" + useId + " ItemNo :" + detail[2] + "is not valid");
				continue;
			}

			//UseInstance
			UseInstance instance = new UseInstance(useId, info);
			ListUse.Add(instance);

		}
	}

	public void SetLocalData()
	{
		//ITEM_ID _ SlotType _ ITEM_NO | ITEM_ID _ SlotType _ ITEM_NO |
		// "1_-1_3 | 2_1_5 | 3_1_5

		string resultStr = string.Empty;

		for (int i = 0; i < ListUse.Count; i++)
		{
			string useStr = string.Empty;
			useStr += (i + 1) + "_";

			useStr += ListUse[i].USE_NO;

			if (i != ListUse.Count - 1)
				useStr += "|";

			resultStr += useStr;

		}
		//   PlayerPrefs.SetString =>   /key/로 식별된 Preference의 값을 설정합니다.
		PlayerPrefs.SetString(ConstValue.LocalSave_UseUInstance, resultStr);
		Debug.Log(resultStr);

	}




	public void Gacha()
	{
		int no = Random.Range(1, 100);
		UseInfo info = null;

		if (no == 1)
		dicUseInfo.TryGetValue(1, out info);

		else if(no !=1 && no <9)
		dicUseInfo.TryGetValue(2, out info);

		else if(no >9 && no <40)
		dicUseInfo.TryGetValue(3, out info);

		else if(no >40 && no <70)
		dicUseInfo.TryGetValue(4, out info);

		else if(no>70 && no<=100)
		dicUseInfo.TryGetValue(5, out info);

		if (info == null)
		{
			Debug.LogError(no + " is not valid key!");
			return;
		}

		UseInstance instance = new UseInstance(ListUse.Count + 1, info);
		ListUse.Add(instance);

		SetLocalData();

		Debug.Log(no);
		Debug.Log(info.NAME);


	}

	//public void ContinuityGacha()
	//{

	//}
}
