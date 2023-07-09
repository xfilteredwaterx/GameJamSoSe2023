using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class NPCKnockBackState : BaseState
{
    public Vector3 knockBackDirection;
    public float knockbackTime;
    private float knockBackStrength = 0;
    private float timer;

    public override void OnEnterState(BaseStateMachine bsm)
    {
        timer = Time.time + knockbackTime;
    }

    public override void OnUpdateState(BaseStateMachine bsm)
    {
        NPCStateMachine npcController = bsm as NPCStateMachine;

        bsm.transform.Translate(knockBackDirection * knockBackStrength * Time.deltaTime);

        if(timer < Time.time)
        {
            npcController.SwitchToState(npcController.IdleState);
        }
    }
}
