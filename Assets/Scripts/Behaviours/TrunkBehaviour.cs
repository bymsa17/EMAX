using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkBehaviour : MonoBehaviour
{
    public Transform trunk;
    public float speed;
    public float maxDistance;
    public bool active;
    public float startDelay;

    // Use this for initialization
    void Start ()
    {
        active = false;
        maxDistance = this.transform.localPosition.y + maxDistance;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (active)
        {
            UpTrunk();
            /*
            if (startDelay > 0)
            {
                startDelay -= Time.deltaTime;
                return;
            }*/
        }
	}

    public void UpTrunk()
    {
        transform.localPosition += new Vector3(0, speed, 0) * Time.deltaTime;

        if(transform.localPosition.y >= maxDistance)
        {
            speed = 0;
        }
    }
}
