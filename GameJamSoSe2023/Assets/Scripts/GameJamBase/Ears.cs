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
        directionToPlayer = target.transform.position - transform.position;
        IsDetecting = IsInRange() && target.GetComponent<Audible>() != null;
    }

    private void OnDrawGizmos()
    {
        directionToPlayer = target.transform.position - transform.position;
#if Unity_Editor
        SenseGizmos.DrawRangeDisc(transform.position, transform.up, range);
#endif
    }
}
