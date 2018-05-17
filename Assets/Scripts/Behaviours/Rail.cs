using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rail : MonoBehaviour {

	[SerializeField]
	Transform[] waypoints;

	[SerializeField]
	float moveSpeed = 0.025f;

	int waypointIndex = 0;

	void Start () {
		transform.position = waypoints [waypointIndex].transform.position;
	}

	void Update () {
		Move ();
	}

	void Move()
	{
		transform.position = Vector2.MoveTowards (transform.position,
												waypoints[waypointIndex].transform.position,
												moveSpeed * Time.deltaTime);

		if (transform.position == waypoints [waypointIndex].transform.position) {
			waypointIndex += 1;
		}
				
		if (waypointIndex == waypoints.Length)
			waypointIndex = 0;
	}

}
