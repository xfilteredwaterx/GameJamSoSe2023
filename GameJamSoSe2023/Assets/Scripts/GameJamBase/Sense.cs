using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// It ain't sensing
/// </summary>
public abstract class Sense : MonoBehaviour
{
    public bool IsDetecting { get; protected set; }
    public SimplePlayerController Target { get => target; set => target = value; }

    // = Player
    private SimplePlayerController target;

    public SimplePlayerController[] targets;

    public float range = 3;

    protected Vector3 directionToPlayer;

    private void Awake()
    {
        targets = GameObject.FindObjectsOfType<SimplePlayerController>();
    }

    public void SetTarget()
    {
        Target = targets.OrderBy(obj => Vector3.Distance(obj.transform.position, transform.position)).First();
    }
    public bool IsInRange()
    {
        return directionToPlayer.sqrMagnitude <= range * range;
    }
}
