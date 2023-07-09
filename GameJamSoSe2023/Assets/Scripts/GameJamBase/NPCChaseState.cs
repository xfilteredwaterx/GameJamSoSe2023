using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class NPCChaseState : BaseState
{
    public float DistanceToFlee;

    public override void OnEnterState(BaseStateMachine bsm)
    {
        NPCStateMachine statemachine = (NPCStateMachine)bsm;
        Vector3 fleeDestination = statemachine.PlayerPosition;
        statemachine.SetDestination(fleeDestination);
        Debug.Log(fleeDestination);
    }


    public override void OnUpdateState(BaseStateMachine bsm)
    {
        if(Vector3.Distance(bsm.transform.position, ((NPCStateMachine)bsm).PlayerPosition) > DistanceToFlee)
        {
            bsm.SwitchToState(((NPCStateMachine)bsm).ChaseState);
        }
    }
}
