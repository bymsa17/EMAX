using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDistance : MonoBehaviour
{
    public GameObject levelStart;
    public GameObject levelEnd;
    public GameObject player;
    public float resta;
    public float canvasSize;
    public float playerPosition;
    public RectTransform rectTransform;

    void Start ()
    {
        resta = levelEnd.transform.position.x - levelStart.transform.position.x;
	}
	
	// Update is called once per frame
	void Update ()
    {
        playerPosition = ((player.transform.position.x - levelStart.transform.position.x) / resta * canvasSize);
        if(playerPosition < 0)
        {
            playerPosition = 0;
        }
        if(playerPosition > resta)
        {
            playerPosition = resta;
        }

        rectTransform.offsetMax = new Vector2(playerPosition +10, 10);
        rectTransform.offsetMin = new Vector2(playerPosition +10, -10);

    }
}
