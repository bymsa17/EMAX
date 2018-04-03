using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDbehaviour : MonoBehaviour {

    public bool portal = false;

    void Portal()
    {
        if (portal == true) anim.SetBool("portalGet", true);
        else anim.SetBool("portalNull", true);
    }
}
