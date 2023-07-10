using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject InGameMenu;
    public MMF_Player pauseFeedback;
    public MMF_Player resumeFeedback;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        MenuLogic();
    }

    public void MenuLogic()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && GameManager.instance.gameTimer > 0)
        {

            if(InGameMenu.activeSelf == true)
            {
                CloseMenu();
            }
            else
            {
                OpenMenu();
            }

        }


    }

    public void CloseMenu()
    {
        InGameMenu.SetActive(false);
        resumeFeedback.PlayFeedbacks();
    }

    public void OpenMenu()
    {
        InGameMenu.SetActive(true);
        pauseFeedback.PlayFeedbacks();
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(0);
    }
}
