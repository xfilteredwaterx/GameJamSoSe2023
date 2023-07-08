using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public InteractionManager currentInteractor;
    public abstract void Interact(InteractionManager interactor);

    public abstract void AlternateInteract(InteractionManager interactor);

    public abstract void Use(InteractionManager interactor);
}
