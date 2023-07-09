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
    public bool usePressed = false;

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
        if (usePressed && Input.GetAxis(use) <= 0)
        {
            usePressed = false;
        }
        return Input.GetAxis(use) > 0;

    }

    public bool UseButtonDown()
    {
        if (!usePressed && Input.GetAxis(use) > 0)
        {
            usePressed = true;
            return true;
        }
        if (usePressed && Input.GetAxis(use) <= 0)
        {
            usePressed = false;
        }
        return false;
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
