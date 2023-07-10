using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class NPCChaseState : BaseState
{
    public float DistanceToFlee;
    private float ignitionTimer = 0;
    public override void OnEnterState(BaseStateMachine bsm)
    {
        NPCStateMachine statemachine = (NPCStateMachine)bsm;
        Vector3 fleeDestination = statemachine.PlayerPosition;
        statemachine.SetDestination(fleeDestination);
    }


    public override void OnUpdateState(BaseStateMachine bsm)
    {
        if(Vector3.Distance(bsm.transform.position, ((NPCStateMachine)bsm).PlayerPosition) > 2)
        {
            bsm.SwitchToState(((NPCStateMachine)bsm).ChaseState);
        }

        if(Vector3.Distance(bsm.transform.position, ((NPCStateMachine)bsm).PlayerPosition) <= 3)
        {

            bsm.SwitchToState(((NPCStateMachine)bsm).IdleState);

        }

    }
}
