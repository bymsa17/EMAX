using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    float currentTime;
    float fadeTime = 2.0f;
    int sceneToLoad = 0;
    public Image blackScreen;

    bool fadeOut = false;

    void Start ()
    {
        blackScreen.color = Color.black;
        FadeIn();
    }
	
	void Update ()
    {
        if(!fadeOut) return;

        currentTime += Time.deltaTime;

        if(currentTime >= fadeTime)
        {
            SceneManager.LoadScene(sceneToLoad);
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
        fadeOut = true;
        //StartCoroutine(WaitForFade());
    }

    public void LoadScene(int n)
    {
        sceneToLoad = n;
        FadeOut();
    }
}
