using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoTime : MonoBehaviour
{
    public SceneTransition transition;
    float currentTime;
    float timeDuration;

    void Start ()
    {
        timeDuration = 5;
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= timeDuration)
        {
            transition.LoadScene(2);
        }
    }
}
