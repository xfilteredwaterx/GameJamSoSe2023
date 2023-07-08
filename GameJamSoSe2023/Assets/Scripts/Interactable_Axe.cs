using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Axe : Interactable
{
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
}
