using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    public bool isActive;
    public Animator anim;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("ButtonTrigger");
            isActive = true;
            anim.SetTrigger("ButtonTrigger");
        }
    }
}
