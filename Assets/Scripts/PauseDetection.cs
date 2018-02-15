using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseDetection : MonoBehaviour
{
    //public GameObject canvasGameplay;

    public void LoadScene(int buildIndex)
    {
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
            //canvasGameplay.SetActive(false);
        }
        //else canvasGameplay.SetActive(true);
        SceneManager.LoadScene(buildIndex);
    }
}
