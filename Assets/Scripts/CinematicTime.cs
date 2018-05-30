using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicTime : MonoBehaviour
{
    private LevelManager levelManager;
    public GameObject text;
    float currentTime;
    float timeDuration;
    int buildIndex;

    void Start()
    {
        timeDuration = 5;
        buildIndex = 3;
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime >= timeDuration)
        {
            text.SetActive(true);
        }

        if((Input.GetKeyDown(KeyCode.Return)) && (currentTime >= timeDuration))
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelManager>().StartLoad(buildIndex);
        }
    }
}
