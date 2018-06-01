using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [Header("Scene state")]
    public int backScene;
    public int currentScene;
    public int nextScene;
    public int logoScene = 0;
    public int titleScene = 1;
    public int sceneCountInBuildSettings;
    [Header("Load parameters")]
    AsyncOperation loadAsync = null;
    AsyncOperation unloadAsync = null;
    int loadingSceneIndex;
    bool isLoading = false;
    [Header("UI")]
    public Image blackScreen;
    float fadeTime = 2.0f;
    public Animator anim;
    public AudioSource audioSource;

    private void Awake()
    {   
        if(GameObject.FindGameObjectsWithTag("GameController").Length > 1)
        {
            Destroy(this.gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);

        AudioManager.Initialize();
        TextData.Initialize();

        blackScreen.color = Color.black;
        FadeIn();

        if(SceneManager.sceneCount >= 2) SceneManager.SetActiveScene(SceneManager.GetSceneAt(1));

        UpdateSceneState();
    }
    void UpdateSceneState()
    {
        sceneCountInBuildSettings = SceneManager.sceneCountInBuildSettings;

        currentScene = SceneManager.GetActiveScene().buildIndex;
        
        if(currentScene - 1 <= logoScene) backScene = sceneCountInBuildSettings - 1;
        else backScene = currentScene - 1;

        if(currentScene + 1 >= sceneCountInBuildSettings) nextScene = logoScene + 1;
        else nextScene = currentScene + 1;
        
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.AltGr))
        {
            if(Input.GetKeyDown(KeyCode.N)) LoadNext();
            if(Input.GetKeyDown(KeyCode.B)) StartLoad(backScene);
            if(Input.GetKeyDown(KeyCode.L)) StartLoad(logoScene);
            if(Input.GetKeyDown(KeyCode.M)) StartLoad(titleScene);
            if(Input.GetKeyDown(KeyCode.R)) StartLoad(currentScene);
        }
    }

    public void LoadNext() { StartLoad(nextScene); }

    public void StartLoad(int index)
    {
        if(isLoading)
        {
            Debug.LogError("No se puede cargar mas de una escena al mismo tiempo");
            return;
        }

        isLoading = true;
        loadingSceneIndex = index;

        FadeOut();
    }
    void LoadLevel()
    {
        //unloadAsync = SceneManager.UnloadSceneAsync(currentScene);
        loadAsync = SceneManager.LoadSceneAsync(loadingSceneIndex, LoadSceneMode.Single);

        StartCoroutine(Loading());
    }

    IEnumerator WaitForFade()
    {
        yield return new WaitForSeconds(fadeTime);
        if(Time.timeScale == 0) Time.timeScale = 1;
        LoadLevel();
    }
    IEnumerator Loading()
    {
        while(true)
        {
            if(loadAsync.isDone && (unloadAsync == null || unloadAsync.isDone))
            {
                SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(loadingSceneIndex));
                UpdateSceneState();

                loadAsync = null;
                unloadAsync = null;

                FadeIn();

                isLoading = false;
               
                break;
            }

            yield return null;
        }
    }

    void FadeIn()
    {
        //blackScreen.CrossFadeAlpha(0, fadeTime, true);
        anim.Play("fadeIn");
        audioSource.Play();
        fadeTime = 1.0f;

    }
    void FadeOut()
    {
        //blackScreen.CrossFadeAlpha(1, fadeTime, true);

        anim.Play("fadeOut");
        audioSource.Play();
        fadeTime = 1.0f;
        StartCoroutine(WaitForFade());
    }
}
