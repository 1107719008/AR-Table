using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneSwitcher : MonoBehaviour
{

    public Animator animator;
    public string sceneName;

    public void SwitchScene()
    {
        animator.SetTrigger("StartVideo");
        SceneManager.LoadScene(sceneName);
    }
}
