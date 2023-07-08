using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public Transform pickUpHand;
    public List<Interactable> interactables = new List<Interactable>();

    public bool canInteract;
    public Interactable interactionTarget;
    public GameObject interactionText;
    private Camera mainCamera;

    public bool isInteracting = false;

    private void Start()
    {
        interactables = GameObject.FindObjectsOfType<Interactable>().ToList();
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if(isInteracting)
        {
            return;
        }
        if(interactables.Count > 0)
        {
            foreach(Interactable interactable in interactables)
            {
                if(Vector3.Distance(transform.position,interactable.transform.position) < 2)
                {
                    canInteract = true;
                    interactionTarget = interactable;
                    interactionText.transform.position = mainCamera.WorldToScreenPoint(interactable.transform.position);
                    return;
                }
                else
                {
                    canInteract = false;
                    interactionText.transform.position = new Vector3(0, 10000, 0);
                    interactionTarget = null;
                }
            }
        }
    }

    public void Use()
    {
        interactionTarget.Use(this);
    }
}