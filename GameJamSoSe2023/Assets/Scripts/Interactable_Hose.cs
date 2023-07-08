using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Hose : Interactable
{
    public MMF_Player feedback;
    private SimplePlayerController spc;
    public float knockBackStrength = 2;
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
        spc = currentInteractor.GetComponent<SimplePlayerController>();
    }

    public override void Use(InteractionManager interactor)
    {
        CancelInvoke();
        if(!feedback.IsPlaying)
        {
            feedback?.PlayFeedbacks();
        }
        PushBackTheUser();
        Invoke("StopFeedback",0.1f);
    }

    private void StopFeedback()
    {
        feedback?.StopFeedbacks();
    }

    public void PushBackTheUser()
    {
        
        spc.knockBack = -spc.transform.forward  * knockBackStrength * Time.deltaTime;
        Vector3 rndSphere = Random.onUnitSphere;
        rndSphere.y = 0;
        spc.knockBackRotation = rndSphere;
    }
}
