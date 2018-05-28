using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    float currentTime;
    float fadeTime = 2.0f;
    int sceneToLoad = 0;
    public Animator animScreen;

    bool fadeOut = false;

    void Start()
    {
        FadeIn();
    }

    void Update()
    {
        if(!fadeOut) return;

        currentTime += Time.deltaTime;

        if(currentTime >= fadeTime + .1f)
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
        animScreen.SetBool("Transition", true);
    }
    void FadeOut()
    {
        //animScreen.SetTrigger("Transition");
        fadeOut = true;
    }

    public void LoadScene(int n)
    {
        sceneToLoad = n;
        FadeOut();
    }
}
