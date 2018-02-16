using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowHUD : MonoBehaviour
{
    public GameObject levelStart;
    public GameObject levelEnd;
    public GameObject shadow;
    public float resta;
    public float canvasSize;
    public float shadowPosition;
    public RectTransform rectTransform;

    void Start()
    {
        resta = levelEnd.transform.position.x - levelStart.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        shadowPosition = ((shadow.transform.position.x - levelStart.transform.position.x) / resta * canvasSize);
        if(shadowPosition < 0)
        {
            shadowPosition = 0;
        }
        if(shadowPosition > resta)
        {
            shadowPosition = resta;
        }

        rectTransform.offsetMax = new Vector2(shadowPosition + 10, 10);
        rectTransform.offsetMin = new Vector2(shadowPosition + 10, -10);

    }
}
