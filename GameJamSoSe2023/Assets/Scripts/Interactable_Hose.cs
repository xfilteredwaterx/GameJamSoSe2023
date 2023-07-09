using MoreMountains.Feedbacks;
using MoreMountains.Tools;
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
    public float maxHosePressure = 100;
    private float hosePressure = 100;
    public float hoseCost = 10;
    public MMProgressBar waterBar;



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
        if(HosePressure <= 0)
        {
            return;
        }
        CancelInvoke();
        if(!feedback.IsPlaying)
        {
            feedback?.PlayFeedbacks();
        }
        HosePressure -= Time.deltaTime * hoseCost;
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

    public float HosePressure { get => hosePressure; set 
        {
            if(value <= maxHosePressure)
            {
                if (value > hosePressure)
                {
                    waterBar.SetBar01(hosePressure / 100);
                }
                else
                {
                    waterBar.UpdateBar01(hosePressure / 100);

                }
                hosePressure = value;

            }
            else
            {
                hosePressure = maxHosePressure;
                waterBar.SetBar01(hosePressure / 100);
            }

        } 
    }
}
