using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.SceneManagement;


public class UICon : MonoBehaviour
{

    public GameObject UIlist;
    public GameObject test;

    private string objName = "";
    private Vector2 touchPosition = default;


    void Update()
    {
        if(Input.touchCount > 0)
        {

            Touch touch = Input.GetTouch(0);
            touchPosition = touch.position;
          if(Input.touches[0].phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    objName = hit.transform.name;

                    foreach (GameObject go in ImageTrackingTwo.allObjects.Values)
                    {
                        if (go.name == objName)
                        {
                            UIlist.SetActive(true);
                            UIlist.transform.parent.Find(objName).gameObject.SetActive(true);
                        }
                    }
                }
            }
            
            
                
            
        }
    }
   


    public void Rescan()
    {
        UIlist.transform.parent.Find(objName).gameObject.SetActive(false);
    }


    public void ChangeModel()
    {

        foreach (GameObject go in ImageTrackingTwo.allObjects.Values)
        {
            
                if (go.name == objName)
                {
                   go.SetActive(false);
                    ImageTrackingTwo.allObjects[go.name] = test;
                test.SetActive(true);


                }      
        }    
    }
}   
