using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ears : Sense
{
    
    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        SetTarget();
        directionToPlayer = Target.transform.position - transform.position;
        IsDetecting = IsInRange() && Target.GetComponent<Audible>() != null;
    }

    private void OnDrawGizmos()
    {
        //directionToPlayer = Target.transform.position - transform.position;
#if Unity_Editor
        SenseGizmos.DrawRangeDisc(transform.position, transform.up, range);
#endif
    }
}
