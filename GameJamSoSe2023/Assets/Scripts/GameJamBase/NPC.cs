using UnityEngine;
using UnityEngine.AI;

public enum NPCState { Idle, Flee }

public class NPC : MonoBehaviour
{
    // In which state the npc should start
    public NPCState startState;       

    // Min distance to player before start fleeing
    public float fleeDistance;

    // Safe distance to player to switch back to idle
    public float runAwayDistance;

    // In which state the npc is at the moment
    public NPCState CurrentState { get; private set; }

    // Reference to the player
    private Transform player;

    // Animation
    private Animator animator;
    private int speedParameterHash;

    // NavMesh Agent for moving
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        CurrentState = startState;

        player = GameObject.FindGameObjectWithTag("Player").transform;

        animator = GetComponent<Animator>();
        speedParameterHash = Animator.StringToHash("speed");

        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (CurrentState) 
        {
            case NPCState.Idle:
                Idle();
                if (Vector3.Distance(transform.position, player.position) < fleeDistance)
                {
                    CurrentState = NPCState.Flee;
                }
                break;
            case NPCState.Flee:
                Flee();
                if (Vector3.Distance(transform.position, player.position) >= runAwayDistance)
                {
                    CurrentState = NPCState.Idle;
                }
                break;
        }
    }

    /// <summary>
    /// Logic called every frame if the NPC is in idle state
    /// </summary>
    private void Idle()
    {
        animator.SetFloat(speedParameterHash, 0);
        agent.destination = transform.position;
    }

    /// <summary>
    /// Logic called every frame if the NPC is in flee state
    /// </summary>
    private void Flee() 
    {
        animator.SetFloat(speedParameterHash, agent.velocity.magnitude);
        agent.destination = (transform.position - player.position).normalized * runAwayDistance;
    }
}
