using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public Transform pickUpHand;
    private List<Interactable> interactables = new List<Interactable>();

    public bool canInteract;
    public Interactable interactionTarget;
    private void Start()
    {
        interactables = GameObject.FindObjectsOfType<Interactable>().ToList();
    }

    private void Update()
    {
        if(interactables.Count > 0)
        {
            foreach(Interactable interactable in interactables)
            {
                if(Vector3.Distance(transform.position,interactable.transform.position) < 1)
                {
                    canInteract = true;
                    interactionTarget = interactable;
                    return;
                }
                else
                {
                    canInteract = false;
                    interactionTarget = interactable;
                }
            }
        }
    }
}