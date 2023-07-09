using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Cart : Interactable
{

    // Defines how fast the GO can turn
    public float turnSpeed = 90;

    public Transform driverPosition;
    private Rigidbody rb;
    public float force = 30;
    private ControllScheme spc;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public override void AlternateInteract(InteractionManager interactor)
    {
        transform.parent = null;
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
        throw new System.NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentInteractor == null)
            return;
        // Stores inputs
        float horizontalInput = spc.Horizontal();
        float verticalInput = spc.Vertical();

        // Translate along z-axis
        rb.velocity = (-transform.forward * verticalInput * force );

        // Are we moving
        if (verticalInput != 0)
        {
            // calculate the angle around y-axis
            float turnAngle = turnSpeed * horizontalInput * verticalInput * Time.deltaTime;
            transform.Rotate(Vector3.up, turnAngle);
        }
    }
}
