using CarterGames.Assets.AudioManager;
using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destuctible : MonoBehaviour
{
    public int hp = 3;
    public MMF_Player feedback;
    public MMF_Player damageFeedback;
    public int Hp { get => hp; 
        set 
        {
            damageFeedback.PlayFeedbacks();
            hp = value; 
            if(hp <= 0)
            {
                AudioManager.instance.Play("MeleeSwingsPack_96khz_Mono_DesignedSwings12");
                feedback.PlayFeedbacks();
            }
        } 
    }

}
