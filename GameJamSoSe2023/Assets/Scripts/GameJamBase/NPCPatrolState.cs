using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class NPCPatrolState : BaseState
{
    public Transform[] Waypoints;
    private int currentwaypointlndex;
    private Vector3 targetPosition;

    public override void OnEnterState(BaseStateMachine controller)
    {
        NPCStateMachine npcController = controller as NPCStateMachine;

        if (targetPosition == Vector3.zero)
        {
            currentwaypointlndex = 0;
            targetPosition = Waypoints[0].position;
        }
        npcController.SetDestination(targetPosition);

    }

    public override void OnUpdateState(BaseStateMachine controller)
    {
        NPCStateMachine npcController = controller as NPCStateMachine;

        float sqrtDistance = (npcController.transform.position - targetPosition).sqrMagnitude;

        if(sqrtDistance <= 0.1f)
        {
            targetPosition = GetNextWaypoint();
            npcController.SwitchToState(npcController.IdleState);
        }
    }

    private Vector3 GetNextWaypoint()
    {
        currentwaypointlndex = ++currentwaypointlndex % Waypoints.Length;
        return Waypoints[currentwaypointlndex].position;
    }


}
