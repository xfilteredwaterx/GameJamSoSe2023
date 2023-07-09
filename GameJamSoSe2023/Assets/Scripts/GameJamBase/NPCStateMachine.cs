using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCStateMachine : BaseStateMachine
{
    public NPCIdleState IdleState;
    public NPCChaseState ChaseState;
    public NPCPatrolState PatrolState;
    public NPCKnockBackState KnockBackState;
    private float initalAgentSpeed;
    private Animator anim;
    public DemonSpawner demonSpawner;

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


    /// <summary>
    /// KnockBackState
    /// </summary>
    public void ApplyKnockback(Vector3 normalized, float v)
    {
        KnockBackState.knockBackDirection = normalized;
        KnockBackState.timer = Time.time +v;
        CurrentState = KnockBackState;
    }

    public Vector3 PlayerPosition { get => eyes.Target.transform.position; }

    private void OnDestroy()
    {
        demonSpawner.enemyCount -= 1;
    }

}
