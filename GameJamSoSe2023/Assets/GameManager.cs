using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score;
    private float gameTimer = 120;
    private float maxGameTime = 120;

    public Image timeImg;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreText;
    public bool hasStarted = false;
    private int gameTimeInt = 1000000;

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
            scoreText.text = ""+value;
            score = value;
        }
    }
    public float GameTimer
    {
        get => gameTimer; set
        {
            if(value < gameTimeInt)
            {
                gameTimeInt = (int)Mathf.Ceil(value);
                timerText.text = "" + gameTimeInt;
                timeImg.fillAmount = gameTimer / maxGameTime;
                gameTimer = value;
            }


        }
    }

}
