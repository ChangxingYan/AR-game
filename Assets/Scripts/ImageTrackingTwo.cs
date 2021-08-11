
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARTrackedImageManager))]
public class ImageTrackingTwo : MonoBehaviour
{
    public List<GameObject> ObjectsToPlace;
    public static Dictionary<string, GameObject> allObjects;
    public Particles particles;

    private int refImageCount;
    private ARTrackedImageManager arTrackedImageManager;
    private IReferenceImageLibrary refLibrary;



    void Awake()
    {
        arTrackedImageManager = GetComponent<ARTrackedImageManager>();
    }

    private void OnEnable()
    {
        arTrackedImageManager.trackedImagesChanged += OnImageChanged;
    }

    private void OnDisable()
    {
        arTrackedImageManager.trackedImagesChanged -= OnImageChanged;
    }

    private void OnLevelWasLoaded()
    {
        refLibrary = arTrackedImageManager.referenceLibrary;
        refImageCount = refLibrary.count;
        LoadObjectDictionary();
    }

    void LoadObjectDictionary()
    {
        allObjects = new Dictionary<string, GameObject>();
        for (int i = 0; i < refImageCount; i++)
        {
            allObjects.Add(refLibrary[i].name, ObjectsToPlace[i]);
            ObjectsToPlace[i].SetActive(false);
        }
    }

    void ActivateTrackedObject(string _imageName)
    {
        allObjects[_imageName].SetActive(true);
      
    }
    void ParticlePos(string _imageName)
    {
        particles.PlayParticle(allObjects[_imageName].transform.position);
    }
   public void DeactivateTrackedObject(string _imageName)
    {
        allObjects[_imageName].SetActive(false);
    }

    public void OnImageChanged(ARTrackedImagesChangedEventArgs _args)
    {
        foreach (var addedImage in _args.added)
        {
            ActivateTrackedObject(addedImage.referenceImage.name);
            ParticlePos(addedImage.referenceImage.name);
        }

        foreach (var updated in _args.updated)
        {
            allObjects[updated.referenceImage.name].transform.position = updated.transform.position;
        }
        foreach (var addedImage in _args.removed)
        {
            allObjects[addedImage.name].SetActive(false);
        }
    }




}
