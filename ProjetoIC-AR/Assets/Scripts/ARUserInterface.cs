using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


public class ARUserInterface : MonoBehaviour
{

    public ARPlaneManager planeManager;
    public bool arMode;

    public GameObject uiCoaching; 
    public GameObject uiMain; 
    public GameObject uiDna; 

    void Start() {
        arMode = false;
    }

    void Update() {
        if (arMode) {
            // 1
            SetCoachingUIVisible(false);
            SetMainUIVisible(true);

            // 2
            planeManager.planesChanged += PlanesChanged;
        }else {
            // 3
            SetCoachingUIVisible(true);
            SetMainUIVisible(false);
            SetDnaInterfaceVisible(false);
        }
    }

    private void PlanesChanged(ARPlanesChangedEventArgs planeEvent) {
        if (planeEvent.added.Count > 0 || planeEvent.updated.Count > 0)
        {
            SetMainUIVisible(true);
            SetCoachingUIVisible(false);

            planeManager.planesChanged -= PlanesChanged;
        }
    }


    void SetMainUIVisible(bool mostrar) {
        if (mostrar) {
            uiMain.SetActive(true);
        }else{
            uiMain.SetActive(false);
        }
        
    }
    void SetCoachingUIVisible(bool mostrar) {
        if (mostrar) {
            uiCoaching.SetActive(true);
        }else{
            uiCoaching.SetActive(false);
        }
        
    }

    public void SetDnaInterfaceVisible(bool mostrar) {
        
        if (mostrar) {
            uiDna.SetActive(true);
        }else{
            uiDna.SetActive(false);
        }
        
    }

    public void ResetaCena(string cena) {
        SceneManager.LoadScene(cena);
    }

}
