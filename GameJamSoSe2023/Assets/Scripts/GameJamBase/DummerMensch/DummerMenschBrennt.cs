using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class DummerMenschBrennt : BaseState
{
    private Transform nextDestination;
    private Vector3 targetPosition;
    private float timer;

    public override void OnEnterState(BaseStateMachine bsm)
    {
        timer = Time.time + 2;
        Debug.Log("OnEnterState Dumm mensch Base State");
        DummerMenschStatemachine npcController = bsm as DummerMenschStatemachine;

        npcController.agent.speed = 6f;
        targetPosition = npcController.Randomposition();

        npcController.SetDestination(targetPosition);
        Debug.Log(targetPosition);
    }

    public override void OnUpdateState(BaseStateMachine bsm)
    {
        Debug.Log("OnUpdateState Dumm mensch Base State");
        DummerMenschStatemachine npcController = bsm as DummerMenschStatemachine;
        //distance between destination and npc
        float sqrtDistance = (npcController.transform.position - targetPosition).sqrMagnitude;

        Debug.Log(sqrtDistance <= 0.2f);

        // if the npc is close enough switch to next random position
        if (sqrtDistance <= 0.2f || timer < Time.time)
        {
            Debug.Log("Change Destination");
            targetPosition = npcController.Randomposition();

            npcController.SetDestination(targetPosition);
            Debug.Log(targetPosition);
            timer = Time.time + 2;
        }

    }

}
