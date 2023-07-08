using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Hose : Interactable
{
    public Transform hoseOrigin;
    public MMF_Player feedback;
    private SimplePlayerController spc;
    public float knockBackStrength = 2;
    private Rigidbody rb;

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
        spc = currentInteractor.GetComponent<SimplePlayerController>();
        rb.isKinematic = true;
    }

    private void Update()
    {
        if (Vector3.Distance(hoseOrigin.position, transform.position) > 10 && currentInteractor == null)
        {
            Vector3 movementDirection = (hoseOrigin.position - transform.position).normalized;
            movementDirection.y = 0;
            if(transform.position.y < -5) // Make sure you cant lose the hose cuz it glitches out
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
