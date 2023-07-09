using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class NPCKnockBackState : BaseState
{
    public Vector3 knockBackDirection;
    public float knockbackTime = 10;
    private float knockBackStrength = 24;
    public float timer;

    public override void OnEnterState(BaseStateMachine bsm)
    {

    }

    public override void OnUpdateState(BaseStateMachine bsm)
    {
        NPCStateMachine npcController = bsm as NPCStateMachine;

        bsm.transform.Translate(knockBackDirection * knockBackStrength * Time.deltaTime,Space.World);
        Debug.Log(timer);
        if(timer < Time.time)
        {
           npcController.SwitchToState(npcController.IdleState);
        }
    }
}
