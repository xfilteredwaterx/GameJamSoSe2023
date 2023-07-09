using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Pump : Interactable
{

    // Defines how fast the GO can turn
    public float turnSpeed = 90;
    public Transform driverPosition;
    public float force = 30;
    private ControllScheme spc;
    public Interactable_Hose hoseEnd;

    private float cooldown = 0.2f;
    private float timer = 0;

    public override void AlternateInteract(InteractionManager interactor)
    {
        currentInteractor.isInteracting = false;
        currentInteractor.GetComponent<CharacterController>().center = new Vector3(0, 0.5f, 0);
        currentInteractor = null;
        interactor.transform.parent = null;

    }

    public override void Interact(InteractionManager interactor)
    {
        if (currentInteractor != null)
        {
            currentInteractor.isInteracting = false;
            currentInteractor.transform.parent = null;
            currentInteractor.GetComponent<CharacterController>().center = new Vector3(0,0.5f,0);
        }
        currentInteractor = interactor;
        currentInteractor.isInteracting = true;
        spc = currentInteractor.GetComponent<SimplePlayerController>().controllScheme;
        interactor.transform.parent = driverPosition;
        interactor.transform.rotation = driverPosition.transform.rotation;
        interactor.transform.position = driverPosition.position;
        currentInteractor.GetComponent<CharacterController>().center = new Vector3(0, 6.5f, 0);
    }

    public override void Use(InteractionManager interactor)
    {
        if(spc.UseButtonDown() && timer < Time.time)
        {
            hoseEnd.HosePressure += 17;
            timer = Time.time + cooldown;
        }

    }

    // Update is called once per frame
    void Update()
    {
    }
}
