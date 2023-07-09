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
    public BurningObject Target { get => target; set => target = value; }

    // = Player
    public BurningObject target;

    public BurningObject[] targets;

    public float range = 3;

    protected Vector3 directionToPlayer;

    private void Awake()
    {
        List<BurningObject> bos = GameObject.FindObjectsOfType<BurningObject>().ToList();
        bos.RemoveAll(obj => obj.isEnemy);
        targets = bos.ToArray();
        
    }

    public bool SetTarget()
    {
        foreach(BurningObject bo in targets.OrderBy(obj => Vector3.Distance(obj.transform.position, transform.position)))
        {
            if (bo.Hp <= 0)
            {
                Debug.Log(bo.name);
                Target = bo;
                return true;
            }
        }


        return false;
    }
    public bool IsInRange()
    {
        return directionToPlayer.sqrMagnitude <= range * range;
    }
}
