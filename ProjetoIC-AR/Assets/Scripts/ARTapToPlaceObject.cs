using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System;

[RequireComponent(typeof(ARRaycastManager))]
[RequireComponent(typeof(ARUserInterface))]
public class ARTapToPlaceObject : MonoBehaviour
{
    
    private ARRaycastManager aRRaycastManager;
    
    
    private ARUserInterface aRUserInterface;

    [SerializeField]
    private GameObject placementIndicator;

    [SerializeField]
    private GameObject arObjectToSpawn;
    
    GameObject spawnedObject;
    private Pose PlacementPose;
    private bool placementPoseIsValid = false;

    private void Awake() {
        aRRaycastManager = GetComponent<ARRaycastManager>();
        aRUserInterface = GetComponent<ARUserInterface>();
    }


    void Update() {
        if (spawnedObject == null && placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
            ARPlaceObject(arObjectToSpawn);
            
        }

        // if (spawnedObject != null && placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
        //     UpdateObjectPosition();
        // }

        
        UpdatePlacementPose();
        UpdatePlacementIndicator();
        
        
        
    }

    private void UpdatePlacementIndicator()
    {
        if (placementPoseIsValid) {
            aRUserInterface.arMode = true;
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(PlacementPose.position, PlacementPose.rotation);
        }else{
            placementIndicator.SetActive(false);
		}
	}

    private void UpdatePlacementPose()
	{
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        aRRaycastManager.Raycast(screenCenter, hits, TrackableType.Planes);
        placementPoseIsValid = hits.Count > 0;

        if (placementPoseIsValid) {
            PlacementPose = hits[0].pose;
            
		}
	}

    public void ARPlaceObject(GameObject ARObjt ) {
        
        if(spawnedObject == null) {
            spawnedObject = Instantiate(ARObjt, PlacementPose.position, PlacementPose.rotation);
            placementPoseIsValid = false;
        } //else {
        //     Destroy(spawnedObject);
        //     spawnedObject = null;
        //      spawnedObject = Instantiate(ARObjt, PlacementPose.position, PlacementPose.rotation);
        // }

    }

    public void TrocarObjetoAR(int num) {
        if (num == 1) {
            spawnedObject.transform.GetChild(0).gameObject.SetActive(false);
            spawnedObject.transform.GetChild(2).gameObject.SetActive(false);
            spawnedObject.transform.GetChild(3).gameObject.SetActive(false);
            spawnedObject.transform.GetChild(num).gameObject.SetActive(true);    
        }else if (num == 2) {
            spawnedObject.transform.GetChild(0).gameObject.SetActive(false);
            spawnedObject.transform.GetChild(1).gameObject.SetActive(false);
            spawnedObject.transform.GetChild(3).gameObject.SetActive(false);
            spawnedObject.transform.GetChild(num).gameObject.SetActive(true);    
            
        }else if (num == 3) {
            spawnedObject.transform.GetChild(0).gameObject.SetActive(false);
            spawnedObject.transform.GetChild(1).gameObject.SetActive(false);
            spawnedObject.transform.GetChild(2).gameObject.SetActive(false);
            spawnedObject.transform.GetChild(num).gameObject.SetActive(true);    
        }else{
            spawnedObject.transform.GetChild(1).gameObject.SetActive(false);
            spawnedObject.transform.GetChild(2).gameObject.SetActive(false);
            spawnedObject.transform.GetChild(3).gameObject.SetActive(false);  
            spawnedObject.transform.GetChild(0).gameObject.SetActive(true);
            
        }
    }

    // public void TrocaDeObjeto(GameObject Troca) {
    //     Destroy(spawnedObject);
    //     spawnedObject = Instantiate(Troca, PlacementPose.position, PlacementPose.rotation);
    // }


    void UpdateObjectPosition() {
        
        spawnedObject.transform.position = new Vector3(PlacementPose.position.x, PlacementPose.position.y, PlacementPose.position.z);
        
    }

    
}