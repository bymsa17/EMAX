using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseDetection : MonoBehaviour
{
    public GameObject canvasGameplay;

    public void LoadScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
            canvasGameplay.SetActive(true);
        }
        else canvasGameplay.SetActive(true);
    }
}
