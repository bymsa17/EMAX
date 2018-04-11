using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearBehaviour : MonoBehaviour
{
    //public Transform gear;
    public float angularV;
    Rigidbody2D rb;
    float angle;
    /*
    public float speed;
    public float timeCounter;
    public float timePatrol;
    */
	void Start ()
    {
        //timeCounter = timePatrol / 2;
        //gear = this.transform;
        rb = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate ()
    {
        angle += angularV * Time.deltaTime;
        rb.MoveRotation(angle);
        //gear.Rotate(Vector3.forward, angularV * Time.deltaTime);
	}
}
