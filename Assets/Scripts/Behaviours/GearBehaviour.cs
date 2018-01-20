using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearBehaviour : MonoBehaviour
{
    public Transform gear;
    public float angularV;
    /*
    public float speed;
    public float timeCounter;
    public float timePatrol;
    */
	void Start ()
    {
        //timeCounter = timePatrol / 2;
        //gear = this.transform;
	}
	
	void Update ()
    {
        gear.Rotate(Vector3.forward, angularV * Time.deltaTime);
	}
}
