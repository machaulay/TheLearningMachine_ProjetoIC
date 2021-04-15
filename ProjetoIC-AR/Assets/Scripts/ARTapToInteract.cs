using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARTapToInteract : MonoBehaviour
{
    public float rotateSpeed = 1000f;
    private float _startingPosition;

    GameObject interfaceScript;

    void Update() {
        if(Input.touchCount > 0) {

            

            Touch touch = Input.GetTouch(0);
            switch (touch.phase) {

                case TouchPhase.Began:
                    _startingPosition = touch.position.x;
                    break;
                case TouchPhase.Moved:
                    if(_startingPosition > touch.position.x) {

                        transform.Rotate(Vector3.up, -rotateSpeed * Time.deltaTime);                 
                    }else if(_startingPosition < touch.position.x) {

                        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
                    }
                    break;
                case TouchPhase.Ended:
                    Debug.Log("Tirou o dedo da tela.");
                    break;
            }

            if(Input.GetTouch(0).phase == TouchPhase.Began) {

                Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

                RaycastHit raycastHit;

                if (Physics.Raycast(raycast, out raycastHit)) {

                    if(raycastHit.collider.CompareTag("dna")) {
                        
                        ARUserInterface.dnaInterface = true;
                    }
                }
            }
        }


    }
}
