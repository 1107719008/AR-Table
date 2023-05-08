using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneSwitcher : MonoBehaviour
{

    public Animator animator;
    public string sceneName;

    //animation playing time
    public float transitionTime = 3f;


    //not used
    public void SwitchScene()
    {
        animator.SetTrigger("StartVideo");
        SceneManager.LoadScene(sceneName);
    }

    private void Start()
    {
        
    }


   
    
    //we use this below
    public void ChangeScene(string sceneName)
    {
        StartCoroutine(LoadScene(sceneName));
    }

    IEnumerator LoadScene(string sceneName)
    {
        animator.SetTrigger("StartVideo");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneName);
    }

    public void SwitchToBOne()
    {
        SceneManager.LoadScene("BOne");
    }
    public void SwitchToATwo()
    {
        SceneManager.LoadScene("ATwo");
    }
    public void SwitchToBTwo()
    {
        SceneManager.LoadScene("BTwo");
    }
    public void SwitchToFinish()
    {
        SceneManager.LoadScene("FinishScene");
    }
    public void SwitchToStart()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void RestartGame()
    {
        // 释放当前场景所有未释放资源
        Resources.UnloadUnusedAssets();

        // 加载第一个场景，释放当前场景的所有对象和资源
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void SwitchToNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        

    }


}


