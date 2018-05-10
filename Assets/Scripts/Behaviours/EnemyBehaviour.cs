using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public Transform enemy;
    public float angularV;

    void Start ()
    {
        enemy = this.transform;
    }

    void Update ()
    {

        enemy.Rotate(Vector3.forward, angularV * Time.deltaTime);
    }
}
