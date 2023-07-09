using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrigger : MonoBehaviour
{
    public Transform soruce;
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

        if (other.GetComponent<NPCStateMachine>() != null)
        {
            print(other.gameObject.name);
            other.GetComponent<NPCStateMachine>().ApplyKnockback((soruce.forward).normalized, 0.2f);
        }
    }
}
