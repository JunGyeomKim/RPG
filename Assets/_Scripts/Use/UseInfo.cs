using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;


public class UseInfo
{
	int Key = 0;
	string Grade = string.Empty;
	string Name = string.Empty;

	public int KEY { get { return Key; } }
	public string GRADE { get { return Grade; } }
	public string NAME { get { return Name; } }

	public UseInfo(int _key, JSONNode nodeData)
	{
		Key = _key;
		Grade = nodeData["GRADE"];
		Name = nodeData["NAME"];
	}
}
