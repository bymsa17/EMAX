using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkTrigger : MonoBehaviour
{
    public TrunkBehaviour trunk01;
    public TrunkBehaviour trunk02;

    public Animator anim;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("TrunkTrigger");
            trunk01.active = true;
            trunk02.active = true;
            //anim.SetTrigger("LightTrigger");
        }
    }
}
