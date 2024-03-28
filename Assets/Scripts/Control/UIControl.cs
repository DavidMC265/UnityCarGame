using System.Collections;
using System.Collections.Generic;
using Score.Manager;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIControl : MonoBehaviour
{   
    public void ResetTheGame()
    {
        ReloadScene();
        print("The button is working");
        ScoreManager.ScoreCount = 0;
    }

    private static void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        ScoreManager.ScoreCount = 0;

    }

    public void ResetScene()
    {
        ReloadScene();
        print("Scene reloaded");
        ScoreManager.ScoreCount = 0;

    }
}
