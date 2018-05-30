using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoTime : MonoBehaviour
{
    private LevelManager levelManager;
    float currentTime;
    float timeDuration;
    int buildIndex;

    void Start ()
    {
        timeDuration = 5;
        buildIndex = 1;
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= timeDuration)
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelManager>().StartLoad(buildIndex);
        }
    }
}
