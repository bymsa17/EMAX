using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowBehaviour : MonoBehaviour
{
    public Transform shadowTrans;
    public Vector2 shadowPos;

	void Start ()
    {
        shadowPos = shadowTrans.position;
	}
	
	void Update ()
    {
        shadowPos.x += 0.025f;
        shadowTrans.position = shadowPos;
    }
}
