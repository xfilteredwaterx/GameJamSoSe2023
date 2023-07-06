using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshAgentController : MonoBehaviour
{

    private NavMeshAgent agent;
    public Transform target;

    private Camera mainCamera;
    [SerializeField]
    public NavMeshHit nvm;
    private Animator anim;
    private int speedHash;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        mainCamera = Camera.main;
        anim = GetComponent<Animator>();
        speedHash = Animator.StringToHash("speed");
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = target.position;
        anim.SetFloat(speedHash, agent.velocity.magnitude);
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit rc;
            if(Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition),out rc))
            {
                target.position = rc.point;
                if (agent.pathStatus == NavMeshPathStatus.PathComplete)
                {
                    target.position = rc.point;
                }
            }
            
        }
        
        
    }
}
