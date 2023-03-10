using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstantiateDestroy : MonoBehaviour
{
    [SerializeField]

    public GameObject AniCanvas;//the canvas of animation -- for being parent

    public GameObject CookAnimationPrefab;
    public float CookTime;
    public GameObject PinpleAnimationPrefab;
    public int PinpleTime;
    public GameObject YummyAnimationPrefab;
    public int YummyTime;
    public GameObject DisgustAnimationPrefab;
    public int DisgustTime;
    public GameObject WinAnimationPrefab;
    public int WinTime;
    public GameObject OkayAnimationPrefab;
    public int OkayTime;

    public GameObject kitchenBG;
    public GameObject villageBG;

    public GameObject cookafterCanvas;

    public Text textObj;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreatePrefab()
    {


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
        Destroy(PinpleAnimationPrefab, PinpleTime);
    }

    public void YummyAnimationPlay()
    {
        Instantiate(YummyAnimationPrefab, AniCanvas.transform);
        //Destroy(YummyAnimationPrefab, YummyTime);
        textObj.text = "太好吃了吧！！！";
    }
    public void YummyDestroy()
    {
        Destroy(YummyAnimationPrefab, YummyTime);
    }

    public void DisgustAnimationPlay()
    {
        Instantiate(DisgustAnimationPrefab, AniCanvas.transform);
        Destroy(DisgustAnimationPrefab, DisgustTime);
    }

    public void WinAnimationPlay()
    {
        Instantiate(WinAnimationPrefab, AniCanvas.transform);
        Destroy(WinAnimationPrefab, WinTime);
    }


    IEnumerator waiter()
    {
        yield return new WaitForSeconds(3f);
        //my code here after 3 seconds
        cookafterCanvas.SetActive(true);

    }
}
