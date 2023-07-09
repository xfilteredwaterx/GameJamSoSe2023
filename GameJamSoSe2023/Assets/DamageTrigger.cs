using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Enemy"))
        {
            other.GetComponent<Destuctible>().Hp -= 1;
        }
        if(other.GetComponent<NPC>() != null)
        {
            other.GetComponent<NPCStateMachine>().ApplyKnockback((transform.position - other.transform.position).normalized, 0.7f);
        }
    }
}
