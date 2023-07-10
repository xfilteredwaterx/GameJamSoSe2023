using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class DummerMenschStatemachine : BaseStateMachine
{
    public DummerMenschBaseState dMbaseState;
    public DummerMenschBrennt menschBrennt;

    public NavMeshAgent agent;
    private Animator animator;
    public float speed;

    public override void Initialize()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        speed = agent.speed;
        CurrentState = dMbaseState;
        CurrentState.OnEnterState(this);
        print("Dummer Mensch Initialize");
    }

    public override void Tick()
    {
        animator.SetFloat("speed", agent.velocity.magnitude);
    }

    public void SetDestination(Vector3 position) => agent.SetDestination(position);


    public Vector3 Randomposition()
    {
        float x = Random.Range(-7, 7);
        float y = Random.Range(-7, 7);
        float z = Random.Range(-7, 7);

        Vector3 direction= new Vector3(x, y, z);

        return transform.position + direction;
    }
    
}
