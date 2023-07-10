using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackEventHandler : MonoBehaviour
{
    public MMF_Player feedback;

    public void PlayFeedback(int i)
    {
        feedback.PlayFeedbacks();
    }
}
