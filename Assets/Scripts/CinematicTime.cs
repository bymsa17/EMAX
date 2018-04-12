using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicTime : MonoBehaviour
{
    public SceneTransition transition;
    public GameObject text;
    float currentTime;
    float timeDuration;

    void Start()
    {
        timeDuration = 5;
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
            transition.LoadScene(4);
        }
    }
}
