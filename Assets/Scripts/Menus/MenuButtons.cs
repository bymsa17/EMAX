using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public GameObject canvasGameplay;

    public void LoadScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
        if(Time.timeScale == 0) Time.timeScale = 1;
        GameData.NewGame(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}