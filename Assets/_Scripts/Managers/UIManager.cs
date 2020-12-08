using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoSingleton<UIManager>
{
    UILabel Label;


    //Dont Destroy를 하지 않기 위함
    public override void Init()
    {
        Transform trans = transform.FindChild("GameOverLabel");
        if (trans == null)
        {
            Debug.LogError("GameOverLabel이 UIManager한테 없음");
            return;
        }
        Label = trans.GetComponent<UILabel>();
		//Inventory에서 오류. 오류시 확인할것.
    }

    public void SetText(bool isKill, float data)
    {
        if(isKill)
        {
            Label.text = "Kill Count : " + ((int)data).ToString();
        }
        else
        {
            Label.text = string.Format("Time {0} : {1}", (int)data / 60, (int)data % 60);
        }
    }


}
