using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseInstance
{
	int UseId = -1;
	int UseNo = -1;

	UseInfo Info = null;
	public int USE_ID { get { return UseId; } }
	public int USE_NO { get { return UseNo; } }
	public UseInfo USE_INFO { get { return Info; } }

	public UseInstance(int _id, UseInfo _info)
	{
		UseId = _id;
		UseNo = _info.KEY;
		Info = _info;
	}
}
