using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorBehaviour : MonoBehaviour
{
    public bool activeDown;
    public bool activeUp;
    public float startDelay;
    public Vector3 iniPos;
    public Vector3 finalPos;
    public float currentTime;
    public float timeDuration;

    void Start ()
    {
        activeDown = false;
        activeUp = false;
    }
	
	void Update ()
    {
		if(activeDown)
        {
            DownElevator();
        }
        if(activeUp)
        {
            UpElevator();
        }
	}

    public static float BackEaseOut(float t, float b, float c, float d)
    {
        return c * ((t = t / d - 1) * t * ((1.70158f + 1) * t + 1.70158f) + 1) + b;
    }

    public void DownElevator()
    {
        if(currentTime <= timeDuration)
        {
            float value = BackEaseOut(currentTime, iniPos.y, finalPos.y - iniPos.y, timeDuration);

            currentTime += Time.deltaTime;

            transform.localPosition = new Vector3(transform.localPosition.x, value, transform.localPosition.z);

            if(currentTime >= timeDuration)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, finalPos.y, transform.localPosition.z);
            }
        }
    }

    public void UpElevator()
    {
        if(transform.localPosition.y == finalPos.y)
        {
            startDelay -= Time.deltaTime;

            if(startDelay < 0)
            {
                startDelay = 0;
                currentTime = 0;
                Vector3 ini = iniPos;
                iniPos = finalPos;
                finalPos = ini;
                activeUp = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("PlayerOnElevator");
            activeUp = true;
        }
    }
}
