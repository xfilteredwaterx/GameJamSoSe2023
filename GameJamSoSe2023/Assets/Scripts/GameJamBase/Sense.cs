using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// It ain't sensing
/// </summary>
public abstract class Sense : MonoBehaviour
{
    public bool IsDetecting { get; protected set; }

    // = Player
    public GameObject target;

    public float range = 3;

    protected Vector3 directionToPlayer;

    public bool IsInRange()
    {
        return directionToPlayer.sqrMagnitude <= range * range;
    }
}
