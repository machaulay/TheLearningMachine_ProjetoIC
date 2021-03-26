using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System;

public class ARTapToPlaceObject : MonoBehaviour
{
    [SerializeField]
    private ARRaycastManager aRRaycastManager;
    
    [SerializeField]
    private ARUserInterface aRUserInterface;

    [SerializeField]
    private GameObject placementIndicator;

    [SerializeField]
    private GameObject arObjectToSpawn;
    
    

    private GameObject spawnedObject;
    private Pose PlacementPose;
    private bool placementPoseIsValid = false;

    void Start() {
    }

    void Update() {
        if (spawnedObject == null && placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
            ARPlaceObject();
            placementPoseIsValid = false;
            aRUserInterface.SetDnaInterfaceVisible(true);
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

    void ARPlaceObject() {
        
        spawnedObject = Instantiate(arObjectToSpawn, PlacementPose.position, PlacementPose.rotation);
        
    }

    void UpdateObjectPosition() {
        
        spawnedObject.transform.position = new Vector3(PlacementPose.position.x, PlacementPose.position.y, PlacementPose.position.z);
        
    }

    
}