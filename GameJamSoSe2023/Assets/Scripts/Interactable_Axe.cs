using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Axe : Interactable
{
    public Transform hoseOrigin;
    private Rigidbody rb;
    private InteractionManager lastUser;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public override void AlternateInteract(InteractionManager interactor)
    {
        transform.parent = null;
        currentInteractor.isInteracting = false;
        currentInteractor = null;
        rb.isKinematic = false;
    }

    public override void Interact(InteractionManager interactor)
    {
        if(currentInteractor != null)
        {
            currentInteractor.isInteracting = false;
        }
        transform.parent = interactor.pickUpHand;
        transform.localEulerAngles = Vector3.zero;
        transform.localPosition = Vector3.zero;
        currentInteractor = interactor;
        currentInteractor.isInteracting = true;
        rb.isKinematic = true;
    }

    public override void Use(InteractionManager interactor)
    {
        print("test");
        CancelInvoke();
        lastUser = interactor;
        interactor.GetComponent<SimplePlayerController>().anim.SetBool("isAttacking", true);
        Invoke("SetAnimationBack", 0.1f);
    }

    private void SetAnimationBack()
    {
        lastUser.GetComponent<SimplePlayerController>().anim.SetBool("isAttacking", false);
    }

    private void Update()
    {
        if (Vector3.Distance(hoseOrigin.position, transform.position) > 10 && currentInteractor == null)
        {
            Vector3 movementDirection = (hoseOrigin.position - transform.position).normalized;
            movementDirection.y = 0;
            if (transform.position.y < -5) // Make sure you cant lose the hose cuz it glitches out
            {
                transform.position = new Vector3(transform.position.x, 5, transform.position.z);
            }
            rb.velocity = movementDirection * 10;
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }
}
