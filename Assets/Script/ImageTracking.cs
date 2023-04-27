using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

[RequireComponent(typeof(ARTrackedImageManager))]
public class ImageTracking : MonoBehaviour
{
    //cook botton code - cook or pass cook
    public Button cookBtn;
    public Button passCookBtn;
    private int CookCases = 0;
    public GameObject TestObj;

    //for detect matching status
    public Text MatchStatus;


    // Reference to AR tracked image manager component
    private ARTrackedImageManager _trackedImagesManager;

    // List of prefabs to instantiate - these should be named the same
    // as their corresponding 2D images in the reference image library 
    public GameObject[] ArPrefabs;

  

    private readonly Dictionary<string, GameObject> _instantiatedPrefabs = new Dictionary<string, GameObject>();
    //  foreach(var trackedImage in eventArgs.added){
    // Get the name of the reference image
    //   var imageName = trackedImage.referenceImage.name;
    //   foreach (var curPrefab in ArPrefabs) {
    // Check whether this prefab matches the tracked image name, and that
    // the prefab hasn't already been created
    //  if (string.Compare(curPrefab.name, imageName, StringComparison.OrdinalIgnoreCase) == 0
    //   && !_instantiatedPrefabs.ContainsKey(imageName)){
    // Instantiate the prefab, parenting it to the ARTrackedImage
    //  var newPrefab = Instantiate(curPrefab, trackedImage.transform);
    private void Start()
    { 
        //cook or not btn
        cookBtn.onClick.AddListener(Cookable);
        passCookBtn.onClick.AddListener(DontCook);
    }
    void Awake()
    {
        _trackedImagesManager = GetComponent<ARTrackedImageManager>();
    }
    private void Update()
    {
        MatchStatus.text = CookCases.ToString();
    }

    //btn listener
    void Cookable()
    {
        switch (CookCases)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
           
            default://error matching - show trash

                break;

        }
    }
    void DontCook()
    {
        //this function is for pass the cook state
        Debug.Log("pass this cook");
    }


    private void OnEnable()
    {
        _trackedImagesManager.trackedImagesChanged += OnTrackedImagesChanged;
        Debug.Log("On able call");
    }
    private void OnDisable()
    {
        _trackedImagesManager.trackedImagesChanged -= OnTrackedImagesChanged;
        Debug.Log("ondisable call");
    }
    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var trackedImage in eventArgs.added/*updated*/)
        {
            var imageName = trackedImage.referenceImage.name;
            foreach (var curPrefab in ArPrefabs)
            {
                if (string.Compare(curPrefab.name, imageName, StringComparison.OrdinalIgnoreCase) == 0
                 && !_instantiatedPrefabs.ContainsKey(imageName))
                {
                    var newPrefab = Instantiate(curPrefab, trackedImage.transform);
                    _instantiatedPrefabs[imageName] = newPrefab;
                    Debug.Log("is instantiated");
                }
            }
        }
        //_instantiatedPrefabs[trackedImage.referenceImage.name].SetActive(trackedImage.trackingState == TrackingState.Tracking);

        
        foreach (var trackedImage in eventArgs.updated)
        {
            Debug.Log("is updated");
            _instantiatedPrefabs[trackedImage.referenceImage.name].SetActive(trackedImage.trackingState == TrackingState.Tracking);

            
        }

        foreach (var trackedImage in eventArgs.removed)
        {
            Debug.Log("is removed");
            // Destroy its prefab
            Destroy(_instantiatedPrefabs[trackedImage.referenceImage.name]);
            // Also remove the instance from our array
            _instantiatedPrefabs.Remove(trackedImage.referenceImage.name);
            // Or, simply set the prefab instance to inactive
            //_instantiatedPrefabs[trackedImage.referenceImage.name].SetActive(false);
        }

        

        // 檢查trackedImages列表中是否包含要處理的兩個物件
        ARTrackedImage object1 = null;
        ARTrackedImage object2 = null;
        ARTrackedImage object3 = null;
        ARTrackedImage object4 = null;
        ARTrackedImage object5 = null;
        ARTrackedImage object6 = null;
        ARTrackedImage object7 = null;
        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
            if (trackedImage.referenceImage.name == "egg")
            {
                object1 = trackedImage;
                Debug.Log(object1.name + "-obj1");
            }
            else if (trackedImage.referenceImage.name == "tomato")
            {
                object2 = trackedImage;
                Debug.Log(object2.name + "-obj2");
            }
            else if (trackedImage.referenceImage.name == "carrot")
            {
                object3 = trackedImage;

            }
            else if (trackedImage.referenceImage.name == "advocoda")
            {
                object4 = trackedImage;


            }
            else if (trackedImage.referenceImage.name == "milk")
            {
                object5 = trackedImage;


            }
            else if (trackedImage.referenceImage.name == "tofu")
            {
                object6 = trackedImage;


            }
            else if (trackedImage.referenceImage.name == "potato")
            {
                object7 = trackedImage;


            }
            else
            {
                Debug.Log("Nothing detected");
            }
        }

            // 如果trackedImages列表中包含您要處理的兩個物件，則執行相應的操作
        if (object1 != null && object2 != null)
        {
            Debug.Log("add tomatoeggs");
            CookCases = 1;
        }else if (object3 != null && object7 != null)
        {
            Debug.Log("add potatoCarrot");
            CookCases = 2;
        }
        else if (object4 != null && object5 != null)
        {
            Debug.Log("add fruitMilk");
            CookCases = 3;
        }
        else if (object1 != null && object6 != null)
        {
            Debug.Log("add tomatoSoup");
            CookCases = 4;
        }
        else
        {
            Debug.Log("not matched");
            CookCases = 0;
        }
        

    }
    


}
