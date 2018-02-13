using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    float currentTime;
    float timeDuration = 5;
    float fadeTime = 2.0f;

    public Image blackScreen;

    void Start ()
    {
        blackScreen.color = Color.black;
        FadeIn();
    }
	
	void Update ()
    {
        currentTime += Time.deltaTime;

        if(currentTime >= timeDuration)
        {
            FadeOut();
            SceneManager.LoadScene(2);
        }

    }

    public void LoadScene(string title)
    {
        SceneManager.LoadScene(title);
    }

    void FadeIn()
    {
        blackScreen.CrossFadeAlpha(0, fadeTime, true);
    }
    void FadeOut()
    {
        blackScreen.CrossFadeAlpha(1, fadeTime, true);
        //StartCoroutine(WaitForFade());
    }
}
