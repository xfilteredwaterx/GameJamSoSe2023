using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCStateMachine : BaseStateMachine
{
    public NPCIdleState IdleState;
    public NPCFleeState FleeState;
    public NPCPatrolState PatrolState;

    private float initalAgentSpeed;
    private Animator anim;

    private Eyes eyes;
    private Ears ears;
    private NavMeshAgent agent;

    public bool CanSeePlayer { get => eyes.IsDetecting; }
    public bool CanHeraPlayer { get => ears.IsDetecting; }


    public void SetDestination(Vector3 position) => agent.SetDestination(position);
    public void SetSpeedMultiplier(float multiplier) => agent.speed = initalAgentSpeed * multiplier;

    public override void Initialize()
    {
        agent = GetComponent<NavMeshAgent>();
        eyes = GetComponentInChildren<Eyes>();
        ears = GetComponentInChildren<Ears>();
        anim = GetComponent<Animator>();
        initalAgentSpeed = agent.speed;

        CurrentState = PatrolState;
        CurrentState.OnEnterState(this);


    }

    public override void Tick()
    {
        anim.SetFloat("speed", agent.velocity.magnitude);
    }

    public Vector3 PlayerPosition { get => eyes.target.transform.position; }

}
