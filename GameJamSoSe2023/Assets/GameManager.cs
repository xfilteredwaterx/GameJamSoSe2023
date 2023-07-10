using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score;
    public float gameTimer = 120;
    private float maxGameTime = 120;

    public Image timeImg;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreText;
    public MMF_Player scoreFeedback;
    public MMF_Player timerFeedback;
    public MMF_Player pauseFeedback;
    public MMF_Player startFeedback;
    public bool hasStarted = false;
    private int gameTimeInt = 1000000;

    public GameObject gameOverMenu;
    public TextMeshProUGUI scoreTextEnd;

    public static GameManager instance;
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            gameTimer = maxGameTime;
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void Update()
    {
        if(hasStarted)
        {
            GameTimer -= Time.deltaTime;
        }

    }

    public int Score { get => score; set
        {
            scoreFeedback.PlayFeedbacks();
            scoreText.text = ""+value;
            scoreTextEnd.text = "" + value;
            score = value;
        }
    }
    public float GameTimer
    {
        get => gameTimer; set
        {
            print((int)Mathf.Ceil(value));
            if ((int)Mathf.Ceil(value) != gameTimeInt)
            {
                timerFeedback.PlayFeedbacks();
                gameTimeInt = (int)Mathf.Ceil(value);
                timerText.text = "" + gameTimeInt;
                timeImg.fillAmount = gameTimer / maxGameTime;
                if(gameTimeInt <= 0)
                {
                    hasStarted = false;
                    gameOverMenu.SetActive(true);
                    pauseFeedback.PlayFeedbacks();
                }
            }
            gameTimer = value;


        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

}
