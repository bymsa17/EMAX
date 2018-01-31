using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTrigger : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if((other.tag == "Player") || (other.tag == "MetalBox") || (other.tag == "WoodBox"))
        {
            other.transform.SetParent(this.transform);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if((other.tag == "Player") || (other.tag == "MetalBox") || (other.tag == "WoodBox"))
        {
            other.transform.SetParent(null);
        }
    }
}
