using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class StageManager : MonoSingleton<StageManager>
{

	//  Dictionary<int, StageInfo> dicStageInfo = new Dictionary<int, StageInfo>();
	//  public Dictionary<int, StageInfo> DIC_STAGEINFO { get { return dicStageInfo; } }

	//  public void StageInit()
	//  {
	////서브스테이지로드
	//      TextAsset stageInfo = Resources.Load<TextAsset>("JSON/STAGE_INFO");
	//      JSONNode rootNode = JSON.Parse(stageInfo.text);

	//      foreach(KeyValuePair<string, JSONNode> pair in rootNode["STAGE_INFO"] as JSONObject)
	//      {
	//          StageInfo info = new StageInfo(pair.Key, pair.Value);
	//          dicStageInfo.Add(int.Parse(info.KEY), info);
	//      }
	//  }

	//  public StageInfo LoadStage(int _index)
	//  {
	//      StageInfo info = null;
	//      dicStageInfo.TryGetValue(_index, out info);

	//      if(info == null)
	//      {
	//          Debug.LogError(" #1 JSON 정상 로드 확인 " + "#2 JSON KEY 값 확인");
	//          return null;
	//      }

	//      GameObject go = Resources.Load("Prefabs/Stages/" + info.MODEL) as GameObject;

	//      Debug.Assert(go != null, "스테이지 리소스 로드 실패");

	//      GameObject model = Instantiate(go);
	//      model.transform.localPosition = Vector3.zero;

	//      return info;
	//  }



	Dictionary<int, Dictionary<int, StageInfo>> dicStageInfo = new Dictionary<int, Dictionary<int, StageInfo>>();
	public Dictionary<int, Dictionary<int, StageInfo>> DIC_STAGEINFO { get { return dicStageInfo; } }

	public void StageInit()
	{
		//메인스테이지로드----------------------------------------------------------------------------------
		TextAsset stageInfo = Resources.Load<TextAsset>("JSON/STAGE_INFO");
		JSONNode rootNode = JSON.Parse(stageInfo.text);

		foreach (KeyValuePair<string, JSONNode> pair in rootNode["STAGE_INFO"] as JSONObject)
		{
			Dictionary<int, StageInfo> tempDictionary = null;
			int dicKey = int.Parse(pair.Value["STAGE_NUM"]);
			dicStageInfo.TryGetValue(dicKey, out tempDictionary);
			
			if (tempDictionary == null)
			{
				tempDictionary = new Dictionary<int, StageInfo>();
				dicStageInfo[dicKey] = tempDictionary;
				//dicStageInfo.Add(int.Parse(pair.Value["STAGE_NUM"]), new Dictionary<int, StageInfo>());
			}

			StageInfo tempStageInfo = null;
			int tempDicKey = int.Parse(pair.Key);
			tempDictionary.TryGetValue(tempDicKey, out tempStageInfo);

			if(tempStageInfo == null)
			{
				tempStageInfo = new StageInfo(tempDicKey, pair.Value);
				tempDictionary[tempDicKey] = tempStageInfo;
			}
		}
	}

	public StageInfo LoadStage(int _stageNum, int _stageKey)
	{
		Dictionary<int, StageInfo> tempDictionary = null;

		dicStageInfo.TryGetValue(_stageNum, out tempDictionary);

		if (tempDictionary == null)
		{
			Debug.LogError(" 없는 스테이지를 불러오려고 시도하였습니다.");
			return null;
		}

		StageInfo tempStageInfo = null;
		tempDictionary.TryGetValue(_stageKey, out tempStageInfo);

		if(tempStageInfo == null)
		{
			Debug.LogError(" 없는 스테이지 키 값을 불러오려고 시도하였습니다");
		}

		GameObject go = Resources.Load("Prefabs/Stages/" + tempStageInfo.MODEL) as GameObject;

		Debug.Assert(go != null, "스테이지 키값 모델명에 맞는 프리팹 경로를 찾을 수 없습니다.");

		GameObject model = Instantiate(go);
		model.transform.localPosition = Vector3.zero;

		return tempStageInfo;
	}

	public StageInfo GetReward(int _stageNum, int _stageKey)
	{

		return null;
	}

}
