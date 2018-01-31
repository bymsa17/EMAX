using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalancePlateBehaviour : MonoBehaviour
{
    public int weight = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "MetalBox")
        {
            weight += 2;
        }
        if(other.tag == "WoodBox")
        {
            weight += 1;
        }
        if(other.tag == "Player")
        {
            weight += 1;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "MetalBox")
        {
            weight -= 2;
        }
        if(other.tag == "WoodBox")
        {
            weight -= 1;
        }
        if(other.tag == "Player")
        {
            weight -= 1;
        }
    }
}
