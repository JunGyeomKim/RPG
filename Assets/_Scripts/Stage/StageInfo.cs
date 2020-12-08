using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class StageInfo {
    int Key = 0;
    string Name = string.Empty;
    string MapModel = string.Empty;
    eClearType ClearType = eClearType.CLEAR_KILLCOUNT;
    double ClearFinish = 0.0f;
	string UseStamina = string.Empty;
	float GetGold = 0;
	string GetActor = string.Empty;
	string GetItem = string.Empty;



    public int KEY { get { return Key; } }
    public string NAME { get { return Name; } }
    public string MODEL { get { return MapModel; } }
    public eClearType CLEAR_TYPE { get { return ClearType; } }
    public double CLEAR_FINISH { get { return ClearFinish; } }
	public string USE_STAMINA { get { return UseStamina; } }
	public float GET_GOLD { get { return GetGold; } }
	public string GET_ACTOR { get { return GetActor; } }
	public string GET_ITEM { get { return GetItem; } }

	public StageInfo(int _Key, JSONNode nodeData)
    {
        Key = _Key;
        Name = nodeData["NAME"];
        MapModel = nodeData["MAP_MODEL"];
        ClearType = (eClearType)int.Parse(nodeData["CLEAR_TYPE"]);
        ClearFinish = nodeData["CLEAR_FINISH"].AsDouble;
		UseStamina = nodeData["USE_STAMINA"];
		GetGold = nodeData["GET_GOLD"];
		GetActor = nodeData["GET_ACTOR"];
		GetItem = nodeData["GET_ITEM"];
    }
}
