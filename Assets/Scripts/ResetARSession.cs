using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;


[RequireComponent(typeof(ARSession))]
public class ResetARSession : MonoBehaviour
{
    public GameObject OriginPrefab;
    public GameObject UIPanel;
    public GameObject test;

    public void SessionReset()
    {
        foreach (string imageName in ImageTrackingTwo.allObjects.Keys)
        {
            OriginPrefab.GetComponent<ImageTrackingTwo>().DeactivateTrackedObject(imageName);
            UIPanel.transform.Find(imageName).gameObject.SetActive(false);
            UIPanel.transform.Find("List").gameObject.SetActive(false);
            test.SetActive(false);
        }

       

    }
}
