using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Specter : Actor {

    float StayTime = 10.0f;
    float CurrTime = 0.0f;
    bool IsOver = false;
    public bool IS_OVER { get { return IsOver; } }

	// Use this for initialization
	void Start () {
        IS_PLAYER = false;
        IS_SPECTER = true;
    }

    protected override void Update()
    {
        if (!IsOver)
        {
            CurrTime += Time.deltaTime;

            //지속시간이 끝났다면
            if (CurrTime > StayTime)
            {
                IsOver = true;
                CurrTime = 0.0f;

                //ingameui에서 스킬 없애주기
                InGameUIManager.Instance.UI_ingame.SecondSkillBtn.gameObject.SetActive(false);

                //상태 DIE로 만들기
                SELF_CHARACTER.TargetComponenet.OBJECT_STATE = eBaseObjectState.STATE_DIE;

                //ActorManager에서 Specter null로 만들어주기
                ActorManager.Instance.SpecterScript = null;
            }

            if (InGameUIManager.Instance.UI_ingame.POSSESSION_LABEL != null)
                InGameUIManager.Instance.UI_ingame.POSSESSION_LABEL.text = ((int)(StayTime - CurrTime + 0.99f)).ToString();
            
        }

        base.Update();
    }

    public void SpecterAttack()
    {
        // 근거리 적 탐색
        BaseObject targetObject = ActorManager.Instance.GetSearchEnemy(AI.Target);

        if (targetObject != null)
        {
            AI.AddNextAI(eStateType.STATE_ATTACK, targetObject);
        }
        CurrTime += 2.0f;
    }
}
