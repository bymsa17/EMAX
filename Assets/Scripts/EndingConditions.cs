using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingConditions : MonoBehaviour
{
    private LevelManager levelManager;
    public PlayerBehaviour player;
    public float timeCounter;
    int buildIndex;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>();
        timeCounter = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.life <= 0)
        {
            timeCounter--;
            if(timeCounter <= 0)
            {
                ReloadLevel(5);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("COLLISION");
            ReloadLevel(5);
        }
    }

    public void ReloadLevel(int buildIndex)
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelManager>().StartLoad(buildIndex);
        //player.Reset();
    }
}
