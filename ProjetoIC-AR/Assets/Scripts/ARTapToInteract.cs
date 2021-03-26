using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARTapToInteract : MonoBehaviour
{
    private ARUserInterface m_ARUserInterface;

    [SerializeField]
    ARRaycastManager m_RaycastManager;
    List<ARRaycastHit> m_Hits = new List<ARRaycastHit>();

    [SerializeField]
    private Camera arCamera;


    void Start() {
        m_RaycastManager = FindObjectOfType<ARRaycastManager>();
        m_ARUserInterface = FindObjectOfType<ARUserInterface>();
    }

    void Update() {

    }

    

    

}
