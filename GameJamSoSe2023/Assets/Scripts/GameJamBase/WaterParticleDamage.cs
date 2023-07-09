using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WaterParticleDamage : MonoBehaviour
{
    public ParticleSystem part;
    public List<ParticleCollisionEvent> collisionEvents = new List<ParticleCollisionEvent>();

    public int damagePerParticle = 2;


    private void OnParticleCollision(GameObject other)
    {
        print("hit");
        if(other.tag.Equals("Burning"))
        {
            int numCollisionEvents = 1;
            // If a particlesystem exists, count the numbers of collision on that frame
            if (part != null)
            {
                numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);
            }
            // Apply damage for each collisonevent
            for (int i = 0; i < numCollisionEvents; i++)
            {
                ApplyDamage(other);
            }
        }

    }

    public void ApplyDamage(GameObject other)
    {
        if(other.GetComponent<BurningObject>() != null)
        {
            other.GetComponent<BurningObject>().Hp -= damagePerParticle;
        }
    }
}
