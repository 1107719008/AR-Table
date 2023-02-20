using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;


[RequireComponent(typeof(ARTrackedImageManager))]
public class ImageRecogonition : MonoBehaviour
{
    
    [SerializeField]
    private GameObject[] placeablePrefabs;

    private Dictionary<string, GameObject> spawnedPrefabs = new Dictionary<string, GameObject>();
    private ARTrackedImageManager trackedImageManger;


  

    private void Awake()
    {
        trackedImageManger = FindObjectOfType<ARTrackedImageManager>();

        foreach(GameObject prefab in placeablePrefabs)
        {
            GameObject newPrefab = Instantiate(prefab, Vector3.zero, Quaternion.identity);
            newPrefab.name = prefab.name;
            spawnedPrefabs.Add(prefab.name, newPrefab);
        }

    }

    private void OnEnable()
    {
        trackedImageManger.trackedImagesChanged += OnImageChanged;
    }


    private void OnDisable()
    {

        trackedImageManger.trackedImagesChanged -= OnImageChanged;
    }

    //public void OnImage(ARTrackedImagesChangedEventArgs eventArgs)
    //{
    //    foreach (var trackImage in eventArgs.added)
    //    {
    //        var imageName = trackImage.referenceImage.name;
    //        foreach (var curPrefab in placeablePrefabs)
    //        {
    //            if (string.Compare(curPrefab.name, imageName, System.StringComparison.OrdinalIgnoreCase) == 0
    //                && !spawnedPrefabs.ContainsKey(imageName))
    //            {
    //                var newPrefab = Instantiate(curPrefab, trackImage.transform);
    //                spawnedPrefabs[imageName] = newPrefab;
    //            }
    //        }
    //    }
    //}

    public void OnImageChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach(ARTrackedImage trackedImage in args.added)
        {
            Debug.Log(trackedImage.name);
            UpdateImage(trackedImage);
        }
        foreach (ARTrackedImage trackedImage in args.updated)
        {
            UpdateImage(trackedImage);
        }
        foreach (ARTrackedImage trackedImage in args.removed)
        {
            spawnedPrefabs[trackedImage.name].SetActive(false);
        }
    }

    private void UpdateImage(ARTrackedImage trackedImage)
    {
        string name = trackedImage.referenceImage.name;
        Vector3 position = trackedImage.transform.position;

        GameObject prefab = spawnedPrefabs[name];
        prefab.transform.position = position;
        prefab.SetActive(true);

        foreach(GameObject go in spawnedPrefabs.Values)
        {
            if(go.name != name)
            {
                go.SetActive(false);
            }
        }
    }

}
