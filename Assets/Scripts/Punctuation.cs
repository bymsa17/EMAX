using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Punctuation : MonoBehaviour
{
    public PlayerBehaviour player;

    public float scoreTime;
    public int scoreAbility;
    public int scoreLife;
    public int scorePiece;

    public float score;
    public float maxScore;

    public Text scoreText;

    void Start ()
    {
        GameData.LoadGame(1);
        scoreTime = GameData.gameState.scoreTime;
        scoreAbility = GameData.gameState.scoreAbility;
        scoreLife = GameData.gameState.scoreLife;
        scorePiece = GameData.gameState.scorePiece;

        maxScore = 1000;
	}
	

	void Update ()
    {
        
        if(Mathf.RoundToInt(scoreTime) < 10) scoreText.text = "00" + Mathf.RoundToInt(scoreTime).ToString();
        else if(Mathf.RoundToInt(scoreTime) < 100) scoreText.text = "0" + Mathf.RoundToInt(scoreTime).ToString();
        else scoreText.text = Mathf.RoundToInt(scoreTime).ToString();
	}
}
