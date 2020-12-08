using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecterAI : BaseAI {

    float DistanceOffset = 2.0f;
    Transform PlayerTrans = null;

    private void Start()
    {
        
        Actor player = GameManager.Instance.PlayerActor;
        if(player == null)
        {
            Debug.LogError(this.name + "에서 가져오려는 PlayerActor가 존재하지 않습니다.");
            return;
        }
        PlayerTrans = player.transform;
    }

    protected override IEnumerator Idle()
    {

        if (PlayerTrans != null) 
        {
            float distance = Vector3.Distance(transform.position, PlayerTrans.position);
            //이미 다 따라왔다고 확인하면
            if (distance < DistanceOffset)
            {
                Stop();
                AddNextAI(eStateType.STATE_IDLE);
            }
            else
                AddNextAI(eStateType.STATE_WALK); 
        }
        yield return StartCoroutine(base.Idle());
    }

    protected override IEnumerator Move()
    {
        if (PlayerTrans != null) 
        {
            float distance = Vector3.Distance(transform.position, PlayerTrans.position);
            //이미 다 따라왔다고 확인하면
            if (distance < DistanceOffset)
            {
                Stop();
                AddNextAI(eStateType.STATE_IDLE);
            }
            else
                SetMove(PlayerTrans.position); 
        }
        yield return StartCoroutine(base.Move());
    }

    protected override IEnumerator Attack()
    {
        yield return new WaitForEndOfFrame();

        while (IS_ATTACK)
        {
            if (OBJECT_STATE == eBaseObjectState.STATE_DIE)
                break;
            yield return new WaitForEndOfFrame();
        }

        AddNextAI(eStateType.STATE_IDLE);

        yield return StartCoroutine(base.Attack());
    }

    protected override IEnumerator Die()
    {
        END = true;
        yield return StartCoroutine(base.Die());
    }
}
