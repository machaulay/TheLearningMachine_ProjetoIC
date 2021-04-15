using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


[RequireComponent(typeof(ARRaycastManager))]

public class SpawnManager : MonoBehaviour
{
    
    public GameObject spawnablePrefab;

    
    private GameObject spawnedObject;
    private ARRaycastManager m_RaycastManager;
    private Vector2 touchPosition;

    List<ARRaycastHit> m_Hits = new List<ARRaycastHit>();

    private void Awake() {
        m_RaycastManager = GetComponent<ARRaycastManager>();
    }

    bool TryGetTouchPosition(out Vector2 touchPosition) {

        if (Input.touchCount > 0) {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }

        touchPosition = default;
        return false;
    }

    

    void Update() {

        if (!TryGetTouchPosition(out Vector2 touchPosition)) {
            return;
        }

        if (m_RaycastManager.Raycast(touchPosition, m_Hits, TrackableType.PlaneWithinPolygon)) {

            var hitPose = m_Hits[0].pose;

            if (spawnedObject == null) {
                spawnedObject = Instantiate(spawnablePrefab, hitPose.position, hitPose.rotation);
            }else{
                spawnedObject.transform.position = hitPose.position;
            }
        }

    }

  


    
}
