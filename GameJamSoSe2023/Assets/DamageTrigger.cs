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
            other.GetComponent<Animator>()?.SetTrigger("hit");
            other.transform.Find("Feedback_Damage").GetComponent<MMF_Player>().PlayFeedbacks();
        }
    }
}
