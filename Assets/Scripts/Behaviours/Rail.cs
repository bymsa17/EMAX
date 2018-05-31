using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rail : MonoBehaviour
{
	public Transform[] waypoints;

	public float moveSpeed = 2f;

	int waypointIndex = 0;

	void Start ()
    {
		transform.localPosition = waypoints [waypointIndex].transform.localPosition;
    }

	void Update ()
    {
		Move();
	}

	void Move()
	{
		transform.localPosition = Vector2.MoveTowards (transform.localPosition, waypoints[waypointIndex].transform.localPosition, moveSpeed * Time.deltaTime);

		if (transform.localPosition == waypoints [waypointIndex].transform.localPosition)
        {
			waypointIndex += 1;
		}
				
		if (waypointIndex == waypoints.Length) waypointIndex = 0;
	}

    public void PauseShadow()
    {
        moveSpeed = 0;
    }

}
