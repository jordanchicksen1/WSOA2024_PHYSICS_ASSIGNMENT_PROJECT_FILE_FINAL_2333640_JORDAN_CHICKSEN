using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene("timer");
    }

    public void controlsMenu()
    {
        SceneManager.LoadScene("controls");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
