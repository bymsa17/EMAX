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

    public float totalScore;

    public Text scoreTimeText;
    public Text scoreAbilityText;
    public Text scoreLifeText;
    public Text scorePieceText;

    void Start ()
    {
        GameData.LoadGame(1);
        scoreTime = GameData.gameState.scoreTime;
        scoreAbility = GameData.gameState.scoreAbility;
        scoreLife = GameData.gameState.scoreLife;
        scorePiece = GameData.gameState.scorePiece;
	}
	

	void Update ()
    {
        if(Mathf.RoundToInt(scoreTime) < 10) scoreTimeText.text = "+00" + Mathf.RoundToInt(scoreTime).ToString();
        else if(Mathf.RoundToInt(scoreTime) < 100) scoreTimeText.text = "+0" + Mathf.RoundToInt(scoreTime).ToString();
        else scoreTimeText.text = scoreTimeText.text = "+" + Mathf.RoundToInt(scoreTime).ToString();

        if(Mathf.RoundToInt(scoreAbility) < 10) scoreAbilityText.text = "+00" + Mathf.RoundToInt(scoreAbility).ToString();
        else if(Mathf.RoundToInt(scoreAbility) < 100) scoreAbilityText.text = "+0" + Mathf.RoundToInt(scoreAbility).ToString();
        else scoreAbilityText.text = scoreAbilityText.text = "+" + Mathf.RoundToInt(scoreAbility).ToString();

        if(Mathf.RoundToInt(scoreLife) < 10) scoreLifeText.text = "+00" + Mathf.RoundToInt(scoreLife).ToString();
        else if(Mathf.RoundToInt(scoreLife) < 100) scoreLifeText.text = "+0" + Mathf.RoundToInt(scoreLife).ToString();
        else scoreLifeText.text = scoreLifeText.text = "+" + Mathf.RoundToInt(scoreLife).ToString();

        if(Mathf.RoundToInt(scorePiece) < 10) scorePieceText.text = "+00" + Mathf.RoundToInt(scorePiece).ToString();
        else if(Mathf.RoundToInt(scorePiece) < 100) scorePieceText.text = "+0" + Mathf.RoundToInt(scorePiece).ToString();
        else scorePieceText.text = scorePieceText.text = "+" + Mathf.RoundToInt(scorePiece).ToString();

        totalScore = scoreTime + scoreAbility + scoreLife + scorePiece;

        scoreTimeText.text = Mathf.RoundToInt(totalScore).ToString();
    }
}
