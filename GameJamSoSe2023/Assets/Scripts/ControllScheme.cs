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
    public bool Interact()
    {
        return Input.GetAxis(interact) > 0;
    }

}
