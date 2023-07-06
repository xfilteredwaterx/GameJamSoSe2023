using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class NPCIdleState : BaseState
{
    public float MinWaitTime = 1;
    public float MaxWaitTime = 2;

    private float leaveTime;

    public override void OnEnterState(BaseStateMachine bsm)
    {
        leaveTime = Time.time + UnityEngine.Random.Range(MinWaitTime, MaxWaitTime);
    }

    public override void OnUpdateState(BaseStateMachine bsm)
    {
        NPCStateMachine npcController = bsm as NPCStateMachine;

        if(Time.time >= leaveTime)
        {
            npcController.SwitchToState(npcController.PatrolState);
        }

        if(npcController.CanSeePlayer ||npcController.CanHeraPlayer)
        {
            npcController.SwitchToState(npcController.FleeState);
        }
        Debug.Log("Idle");
    }
}
