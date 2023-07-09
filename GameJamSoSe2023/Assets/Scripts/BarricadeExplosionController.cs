using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// easy script to create a small explosion in at the barricade
/// </summary>
public class BarricadeExplosionController : MonoBehaviour
{
    public float explosionRadius = 7;
    public float explosionStrength = 20;
    public LayerMask barricadeLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            triggerExplosion();
        }
    }

    public void triggerExplosion()
    {
        Collider[] barricadeColliders = Physics.OverlapSphere(transform.position, explosionRadius, barricadeLayer);
        foreach (Collider hit in barricadeColliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(explosionStrength, transform.position, explosionRadius, 3.0F);
        }

    }
}
