using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public GameObject canvasGameplay;
    private LevelManager levelManager;

    public void LoadScene(int buildIndex)
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelManager>().StartLoad(buildIndex);

        //SceneManager.LoadScene(buildIndex);
        GameData.NewGame(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}