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
    public bool isEnemy = false;
    private int maxHP = 0;

    private void Start()
    {
        fire.Play();
        maxHP = hp;
        if(!isEnemy && Random.value < 0.5f)
        {
            fire.Stop();
            hp = 0;
        }
    }
    public int Hp { get => hp;
        set 
        {
            damageFeedback.PlayFeedbacks();
            if (value <= 0 && hp > 0)
            {
                print("Test");
                endFeedback.PlayFeedbacks();
                fire.Stop();
                if(isEnemy)
                {
                    GameManager.instance.Score += maxHP * 3;
                }
                else
                {
                    GameManager.instance.Score += maxHP;
                }

            }
            hp = value;

        } 
    }

    public void Ignite()
    {
        hp = maxHP;
        fire.Play();
    }
}
