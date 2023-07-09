using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnitionAura : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.GetComponent<BurningObject>() != null)
        {
            print(other.gameObject.name);
            BurningObject bo = other.GetComponent<BurningObject>();
            if(!bo.isEnemy)
            {
                bo.Ignite();
            }
        }
    }
}
