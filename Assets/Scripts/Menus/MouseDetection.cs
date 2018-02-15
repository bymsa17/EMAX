﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDetection : MonoBehaviour
{
    public EasingScale easing;

    public void OnMouseDetection()
    {
        Debug.Log("OnMouseEnter");
        easing.isActive = true;
        easing.Update();
    }

    public void MouseExit()
    {
        Debug.Log("MouseExit");
        easing.repeat = 2; 
    }
}
