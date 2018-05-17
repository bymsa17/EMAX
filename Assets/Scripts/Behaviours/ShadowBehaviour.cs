using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowBehaviour : MonoBehaviour
{
    public RectTransform shadowTrans;
    public Vector2 shadowPos;
    public Animator anim;

    void Start()
    {
        shadowPos = shadowTrans.position;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Time.timeScale == 1)
        {
            shadowPos.x += 0.025f;
            shadowPos.y += 0.0025f;
            shadowTrans.position = shadowPos;
            anim.SetBool("loseAnim", true);
        }
    }
}
    
