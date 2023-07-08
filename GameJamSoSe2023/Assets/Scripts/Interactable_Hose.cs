using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Hose : Interactable
{
    public override void AlternateInteract(InteractionManager interactor)
    {
        transform.parent = null;
        currentInteractor.isInteracting = false;
        currentInteractor = null;
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
    }
}
