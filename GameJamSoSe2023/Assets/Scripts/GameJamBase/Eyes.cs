using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : Sense
{

    // Head transform in rig
    public Transform referenceTransform;

    public float fov = 90f;

    public LayerMask layermask;

    // Update is called once per frame
    void Update()
    {
        SetTarget();
        directionToPlayer = Target.transform.position - referenceTransform.position;
        IsDetecting = IsInRange() && IsInFoV() && HasLoS();
    }


    private bool IsInFoV()
    {
        Vector3 dir = directionToPlayer;
        dir.y = 0;

        Vector3 forward = referenceTransform.forward;
        forward.y = 0;

        float angleBetween = Vector3.Angle(forward, dir);

        return angleBetween < fov / 2;
    }


    private bool HasLoS()
    {
        RaycastHit rc;
        if(Physics.Raycast(referenceTransform.position, directionToPlayer, out rc, range, layermask))
        {
            return rc.collider.gameObject.Equals(Target);
        }
        else
        {
            return false;
        }
         
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        directionToPlayer = GameObject.Find("Player").transform.position - referenceTransform.position;
        SenseGizmos.DrawRangeCircle(referenceTransform.position, transform.up, range);
        SenseGizmos.DrawFOV(referenceTransform.position, referenceTransform.forward, transform.up, range, fov);
        if(IsInRange())
            SenseGizmos.DrawRay(referenceTransform.position, Target.transform.position, HasLoS());
    }
#endif
}

