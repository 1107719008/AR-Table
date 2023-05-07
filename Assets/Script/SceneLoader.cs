using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

public class SceneLoader : MonoBehaviour
{

    public GameObject ARCamera;

    private void OnDestroy()
    {
        LoaderUtility.Deinitialize();
    }

    private void Start()
    {
        LoaderUtility.Initialize();
        ARCamera.SetActive(true);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
