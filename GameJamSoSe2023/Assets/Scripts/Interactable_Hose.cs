using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Hose : MonoBehaviour
{
    public void Interact(InteractionManager interactor)
    {
        transform.parent = interactor.pickUpHand;
    }
}
