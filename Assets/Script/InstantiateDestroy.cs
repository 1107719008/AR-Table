using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InstantiateDestroy : MonoBehaviour
{
    

    public GameObject AniCanvas;//the canvas of animation -- for being parent

    public GameObject CookAnimationPrefab;
    public float CookTime;
    public GameObject PinpleAnimationPrefab;
    public int PinpleTime;
    public GameObject YummyAnimationPrefab;
    public int YummyTime;
    public GameObject DisgustAnimationPrefab;
    public int DisgustTime;

    
    
    public int WinTime;
    public GameObject OkayAnimationPrefab;
    public int OkayTime;

    public GameObject kitchenBG;
    public GameObject villageBG;

    //mission complete text
    public Text completeText;

    public Text textObj;

    
    public GameObject Canvas1;//tomatoegg
    public GameObject Canvas2;//potatocarrot
    public GameObject Canvas3;//avocodaMilk
    public GameObject Canvas4;//tomatoTofu
    public GameObject CanvasTrash;
    public bool yummyMeal;
    private string sceneName;

    public GameObject forDestroyAnimation = null;

    public Text CanvasState;
    public Text ifyum;

    public int countCall=0;

    void Start()
    {
        //get scene info
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

        

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(yummyMeal);
        Debug.Log("cookcase-imagetracking: "+ImageTracking.CookCasesToCanvas);
        checkCompleteOrNot();
        CanvasState.text = ImageTracking.CookCasesToCanvas.ToString();
        ifyum.text = yummyMeal.ToString();
        Debug.Log(sceneName);
    }

    public void DeleteAllAnimationChildren()
    {
        foreach (Transform child in AniCanvas.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void checkCompleteOrNot()
    {
        string textforwin;
        if (yummyMeal) {
            textforwin = "任務達成！";
            completeText.text = textforwin.ToString();
        } else
        {
            textforwin = "任務失敗！";
            completeText.text = textforwin.ToString();
        }
    }

    public void CheckSceneStateAndMeal()
    {
        countCall++;
        Debug.Log("checkscenestate and meal is called"+countCall);
        switch (sceneName)
        {
            case "BlankAR":
                if (ImageTracking.CookCasesToCanvas == 1)
                {
                    yummyMeal = true;
                    Debug.Log("yummy true 1");
                }
                else
                {
                    yummyMeal = false;

                    Debug.Log("yummy false 1");
                }
                break;
            case "ATwo":
                if (ImageTracking.CookCasesToCanvas == 3)
                {
                    yummyMeal = true;
                    Debug.Log("yummy true 3");
                }
                else
                {
                    yummyMeal = false;
                    Debug.Log("yummy false 3");
                }
                break;
            case "BOne":
                if (ImageTracking.CookCasesToCanvas == 2)
                {
                    yummyMeal = true;
                    Debug.Log("yummy true 2");
                }
                else
                {
                    yummyMeal = false;
                    Debug.Log("yummy false 2");
                }
                break;
            case "BTwo":
                if (ImageTracking.CookCasesToCanvas == 4)
                {
                    yummyMeal = true;
                    Debug.Log("yummy true 4");
                }
                else
                {
                    yummyMeal = false;
                    Debug.Log("yummy false 4");
                }
                break;
            default:
                Debug.Log("cook trash");
                yummyMeal = false;
                break;

        }
            

    }

    public void CheckYummyOrNot()
    {
        if (yummyMeal) {
            YummyAnimationPlay();
            //YummyDestroy();
        }
        else//not yummy-- yummyMeal==false
        {
            DisgustAnimationPlay();
            
        }
    }
    public void CheckYummythenDestroy()
    {
        if(yummyMeal) {
            YummyDestroy();
        }
        else//not yummy-- yummyMeal==false
        {
            DisgustDestroy();
        }
    }

    public void CheckOkayOrNot()
    {
        if (yummyMeal)
        {
            OkayAnimationPlay();
            
        }
        else
        {
            DisgustAnimationPlay();
            textObj.text = "難吃又沒有效...";
        }
    }
    public void CheckOkaythenDestroy()
    {
        if (yummyMeal)
        {
            OkayDestroy();
        }
        else//not yummy-- yummyMeal==false
        {
            DisgustDestroy();
        }
    }


    public void DestroyPinple()
    {
        Destroy(PinpleAnimationPrefab);
    }

    public void CookAnimationPlay()
    {
        GameObject NewCook = Instantiate(CookAnimationPrefab, AniCanvas.transform);
        Destroy(NewCook, CookTime);
        kitchenBG.SetActive(true);
        villageBG.SetActive(false);
        StartCoroutine(waiter());
    }

    public void PinpleAnimationPlay()
    {
        Instantiate(PinpleAnimationPrefab, AniCanvas.transform);
        //Destroy(PinpleAnimationPrefab, PinpleTime);
    }

    //heal Animation
    public void OkayAnimationPlay()
    {
        forDestroyAnimation = Instantiate(OkayAnimationPrefab, AniCanvas.transform);
        
        textObj.text = "太好了！痘痘的情況改善了！";
    }
    public void OkayDestroy()
    {
        Destroy(forDestroyAnimation);
    }

    //yummy animation
    public void YummyAnimationPlay()
    {
        forDestroyAnimation=Instantiate(YummyAnimationPrefab, AniCanvas.transform);
        //Destroy(YummyAnimationPrefab, YummyTime);
        textObj.text = "太好吃了吧！！！";
    }
    public void YummyDestroy()
    {
        GameObject toDel = GameObject.Find("yummyA(Clone)");
        Destroy(toDel);
    }

    public void DisgustAnimationPlay()
    {
        forDestroyAnimation = Instantiate(DisgustAnimationPrefab, AniCanvas.transform);
        //Destroy(DisgustAnimationPrefab, DisgustTime);
        textObj.text = "好難吃！我好想吐...";
    }
    public void DisgustDestroy()
    {
        GameObject toDel = GameObject.Find("disgustA(Clone)");
        Destroy(toDel);
    }

    //check style cases for image tracking
    


    IEnumerator waiter()
    {
        yield return new WaitForSeconds(3f);
        //my code here after 3 seconds
        //cookafterCanvas.SetActive(true);
        switch (ImageTracking.CookCasesToCanvas)
        {//control the meal
            case 1:
                Canvas1.SetActive(true);
                break;
            case 2:
                Canvas2.SetActive(true);
                break;
            case 3:
                Canvas3.SetActive(true);
                break;
            case 4:
                Canvas4.SetActive(true);
                break;

            default://error matching - show trash - cases 0
                CanvasTrash.SetActive(true);
                break;

        }

    }
}
