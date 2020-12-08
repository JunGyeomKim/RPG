using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAI : BaseAI {

    
    //public float SearchDis = 100.0f;

    protected override IEnumerator Idle()
    {
        BaseObject targetObject = ActorManager.Instance.GetSearchEnemy(Target);

        if(targetObject != null)
        {
            //0번 인덱스의 스킬을 사용하기 위함
            SkillData sData = Target.GetData(ConstValue.ActorData_SkillData, 0) as SkillData;
            float attackRange = 1f;

            if(sData != null)
                attackRange = sData.RANGE;

            float distance = Vector3.Distance( targetObject.SelfTransform.position, SelfTransform.position);

            if (distance < attackRange)
            {
                Stop();
                AddNextAI(eStateType.STATE_ATTACK, targetObject);
            }
            else
                AddNextAI(eStateType.STATE_WALK);
        }


        yield return StartCoroutine(base.Idle());
    }

    protected override IEnumerator Move()
    {
        yield return StartCoroutine(base.Move());
    }
    protected override IEnumerator Attack()
    {
        yield return StartCoroutine(base.Attack());
    }

    protected override IEnumerator Die()
    {
        yield return StartCoroutine(base.Die());
    }

}
