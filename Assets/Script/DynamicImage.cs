using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DynamicImage : MonoBehaviour
{
    public Image kitchenImage;
    public Sprite aImage;
    public Sprite bImage;
    // Start is called before the first frame update
    void Start()
    {
        SwitchImage();
    }

    public void SwitchImage()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 3 || currentSceneIndex == 5)
        {
            kitchenImage.sprite = bImage;

        }
        else
        {
            kitchenImage.sprite = aImage;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
