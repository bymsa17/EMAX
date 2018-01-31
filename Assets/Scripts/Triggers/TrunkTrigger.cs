using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkTrigger : MonoBehaviour
{
    public TrunkBehaviour trunk;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("TrunkTrigger");
            trunk.active = true;
        }
    }
}
