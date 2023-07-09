using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int score;
    private int gameTimer = 120;
    public int Score { get => score; set => score = value; }
    public int GameTimer { get => gameTimer; set => gameTimer = value; }



    public static GameManager instance;
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

}
