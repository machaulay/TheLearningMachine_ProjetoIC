using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.XR.ARFoundation;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    ARRaycastManager m_RaycastManager;
    List<ARRaycastHit> m_Hits = new List<ARRaycastHit>();

    [SerializeField]
    GameObject spawnablePrefab;

    GameObject spawnedObject;

    [SerializeField]
    private Button botaoTroca;
    private ARPlaneManager aRPlaneManager;
    

    private void Awake() {
        aRPlaneManager = GetComponent<ARPlaneManager>();
    }
    void Start() {
        spawnedObject = null;
    }

    void Update() {
        //Caso não haja toque returna para não gastar processamento
        if (Input.touchCount == 0)
            return;

        if (m_RaycastManager.Raycast(Input.GetTouch(0).position, m_Hits)) {
            
            if (Input.GetTouch(0).phase == TouchPhase.Began) {

                //passa a posição para o método spawnar o prefab
                SpawnPrefab(m_Hits[0].pose.position);
            }else if(Input.GetTouch(0).phase == TouchPhase.Moved && spawnedObject == null) {
                spawnedObject.transform.position = m_Hits[0].pose.position;
            }

            if(Input.GetTouch(0).phase == TouchPhase.Ended) {
                spawnedObject = null;
            }
        }

    }

    //Spawna o prefab
    void SpawnPrefab(Vector3 spawnPosition) {

        spawnedObject = Instantiate(spawnablePrefab, spawnPosition, Quaternion.identity);
    }


    
}
