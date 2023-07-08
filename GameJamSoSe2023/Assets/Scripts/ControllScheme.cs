using System;
using System.Collections;
using UnityEngine;


[Serializable]
public class ControllScheme
{
    public string horizontal;
    public string vertical;
    public string jump;
    public string interact;
    public string use;

    public bool interactPressed = false;

    public float Horizontal()
    {
        return Input.GetAxis(horizontal);
    }

    public float Vertical()
    {
        return Input.GetAxis(vertical);
    }

    public bool Jump()
    {
        return Input.GetAxis(jump) >0;
    }

    public bool Use()
    {
        return Input.GetAxis(use) > 0;
    }
    public bool Interact()
    {
        if(!interactPressed && Input.GetAxis(interact) > 0)
        {
            interactPressed = true;
            return true;
        }
        if (interactPressed && Input.GetAxis(interact) <= 0)
        {
            interactPressed = false;
        }
        return false;
    }

}
