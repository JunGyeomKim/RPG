using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUIManager : MonoSingleton<InGameUIManager> {

    public UI_InGame UI_ingame = null;

    public void GameUIInit()
    {
        GameObject ingameUI = UI_Tools.Instance.ShowUI(eUIType.PF_UI_INGAME);
        UI_ingame = ingameUI.GetComponent<UI_InGame>();

    }

    public void DisableUI()
    {
        UI_Tools.Instance.HideUI(eUIType.PF_UI_SKILLSTATE);
        UI_Tools.Instance.HideUI(eUIType.PF_UI_INGAME);
    }
    
}
