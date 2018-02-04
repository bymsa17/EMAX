using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkBehaviour : MonoBehaviour
{
    public Transform trunk;

    public float maxDistance;
    public bool active;
    public float startDelay;

    public Vector3 iniPos;
    public Vector3 finalPos;
    public float currentTime;
    public float timeDuration;

    void Start ()
    {
        active = false;
        //maxDistance = this.transform.localPosition.y + maxDistance;

        iniPos = transform.localPosition;
        finalPos = new Vector3 (transform.localPosition.x, iniPos.y + maxDistance, transform.localPosition.z);
    }
	
	void Update ()
    {
        if (active)
        {
            UpTrunk();
        }
	}

    public static float BackEaseOut(float t, float b, float c, float d)
    {
        return c * ((t = t / d - 1) * t * ((1.70158f + 1) * t + 1.70158f) + 1) + b;
    }

    public void UpTrunk()
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
            }
        }
    }
}
