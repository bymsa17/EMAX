using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    public Transform door;
    public bool active;
    public Vector3 iniPos;
    public Vector3 finalPos;
    public float currentTime;
    public float timeDuration;

    void Start ()
    {
        active = false;
        iniPos = transform.localPosition;
        finalPos = new Vector3(transform.localPosition.x, finalPos.y, transform.localPosition.z);
    }
	
	void Update ()
    {
        if(active)
        {
            UpDoor();
        }
    }

    public static float ExpoEaseInOut(float t, float b, float c, float d)
    {
        if(t == 0)
            return b;

        if(t == d)
            return b + c;

        if((t /= d / 2) < 1)
            return (float)(c / 2 * Math.Pow(2, 10 * (t - 1)) + b);

        return (float)(c / 2 * (-Math.Pow(2, -10 * --t) + 2) + b);
    }

    public void UpDoor()
    {
        if(currentTime <= timeDuration)
        {
            float value = ExpoEaseInOut(currentTime, iniPos.y, finalPos.y - iniPos.y, timeDuration);

            currentTime += Time.deltaTime;

            transform.localPosition = new Vector3(transform.localPosition.x, value, transform.localPosition.z);

            if(currentTime >= timeDuration)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, finalPos.y, transform.localPosition.z);
            }
        }
    }
}
