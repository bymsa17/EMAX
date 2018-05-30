using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punctuation : MonoBehaviour
{
    public float time;
    public int ability;
    public int deaths;
    public bool piece;

    public float score;
    public float maxScore;

	void Start ()
    {
        GameData.LoadGame(1);
        score = GameData.gameState.score;
        maxScore = 100;
	}
	

	void Update ()
    {
        if(time <= 60)
        {
            score += 20;
        }

        if(ability <= 8)
        {
            score += 20;
        }
        else if ((ability > 8) || (ability <= 10))
        {
            score += 10;
        }
        else if(ability > 10)
        {
            score += 0;
        }

        if(deaths == 0)
        {
            score += 225;
        }
        else if(deaths == 1)
        {
            score += 150;
        }
        else if(deaths == 2)
        {
            score += 75;
        }
        
        if(piece == true)
        {
            score += 150;
        }
        else score += 0;

	}
}
