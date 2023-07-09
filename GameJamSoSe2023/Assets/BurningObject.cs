using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurningObject : MonoBehaviour
{
    [SerializeField] private int hp = 100;
    public MMF_Player endFeedback;
    public MMF_Player damageFeedback;
    public ParticleSystem fire;
    private void Start()
    {
        fire.Play();
    }
    public int Hp { get => hp;
        set 
        {
            hp = value;
            damageFeedback.PlayFeedbacks();
            if (hp <= 0)
            {
                print("Test");
                endFeedback.PlayFeedbacks();
                fire.Stop();
            }

        } 
    }
}
