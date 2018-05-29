using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceTrigger : MonoBehaviour
{
    public CameraBehaviour mainCamera;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("BalanceTrigger");
            mainCamera.balanceInActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("BalanceTrigger");
            mainCamera.balanceOutActive = true;
        }
    }
}
