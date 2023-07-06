using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class NPCFleeState : BaseState
{
    public float DistanceToFlee;

    public override void OnEnterState(BaseStateMachine bsm)
    {
        NPCStateMachine statemachine = (NPCStateMachine)bsm;
        Vector3 fleeDestination = bsm.transform.position + (bsm.transform.position - statemachine.PlayerPosition).normalized * DistanceToFlee;
        statemachine.SetDestination(fleeDestination);
        Debug.Log(fleeDestination);
    }


    public override void OnUpdateState(BaseStateMachine bsm)
    {
        Debug.Log(Vector3.Distance(bsm.transform.position, ((NPCStateMachine)bsm).PlayerPosition));
        if(Vector3.Distance(bsm.transform.position, ((NPCStateMachine)bsm).PlayerPosition) > DistanceToFlee)
        {
            bsm.SwitchToState(((NPCStateMachine)bsm).FleeState);
        }
    }
}
