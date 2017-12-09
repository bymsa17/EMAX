using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingButtons : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void ReloadLevel(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
        //player.Reset();
    }
    public void NextLevel(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }
}
