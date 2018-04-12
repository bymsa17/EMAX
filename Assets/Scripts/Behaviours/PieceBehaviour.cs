using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceBehaviour : MonoBehaviour
{
    public Transform piece;
    public float angularV;

    private void Start()
    {
        piece = this.transform;
    }

    private void Update()
    {
        piece.Rotate(Vector3.forward, angularV * Time.deltaTime);
    }
}
