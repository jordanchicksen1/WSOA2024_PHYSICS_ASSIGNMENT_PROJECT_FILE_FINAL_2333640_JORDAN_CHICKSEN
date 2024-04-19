using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{
    public int playerScore;
    public int comScore;
    public Text playerScoreText;
    public Text comScoreText;
    public GameObject youLoseScreen;
    public GameObject youWinScreen;

    
    [ContextMenu("Increase Player Score")]
    public void addPlayerScore()
    { 
    playerScore = playerScore + 1;
    playerScoreText.text = playerScore.ToString();

    if (playerScore > 4) 
        {
            youWin(); 
        }
    }

    [ContextMenu("Increase Com Score")]
    public void addComScore() 
    {
    comScore = comScore + 1;
    comScoreText.text = comScore.ToString();

    if (comScore > 4)
        {
            youLose();
        }
    }

    public void addComScoreDouble()
    {
        comScore = comScore + 2;
        comScoreText.text = comScore.ToString();

    }

    public void addPlayerScoreDouble()
    {
        playerScore = playerScore + 2;
        playerScoreText.text = playerScore.ToString();

    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void youLose()
    {
        youLoseScreen.SetActive(true);
        
    }

    public void youWin()
    {
       youWinScreen.SetActive(true);
    }

    public void quitGame()
    {
        Application.Quit();
    }

}
