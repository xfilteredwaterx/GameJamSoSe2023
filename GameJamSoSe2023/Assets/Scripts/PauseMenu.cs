using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject InGameMenu;
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
        if (Input.GetKeyDown(KeyCode.Escape))
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
        Time.timeScale = 1;
    }

    public void OpenMenu()
    {
        InGameMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
