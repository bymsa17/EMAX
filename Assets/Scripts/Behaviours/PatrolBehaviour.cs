using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehaviour : MonoBehaviour {

    public Vector2 direction;
    public float speed;
    public float timePatrol;
    public float timeCounter;

    // Use this for initialization
    void Start()
    {
        timeCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        if(timeCounter >= timePatrol)
        {
            speed *= -1;
            timeCounter = 0;
        }
        else timeCounter += Time.deltaTime;
    }
}
