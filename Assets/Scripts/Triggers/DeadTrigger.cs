using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadTrigger : MonoBehaviour
{
    private LevelManager levelManager;
    int buildIndex;

    void Start()
    {
        buildIndex = 5;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("KillPlayer");
            GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelManager>().StartLoad(buildIndex);
        }
    }
}
