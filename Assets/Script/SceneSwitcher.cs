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




}


