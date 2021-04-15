using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


public class ARUserInterface : MonoBehaviour
{

    public ARPlaneManager planeManager;
    private ARTapToPlaceObject ArTapToPlaceObject;
    public bool arMode;
    public static bool dnaInterface;

    public GameObject uiCoaching; 
    public GameObject uiMain; 
    public GameObject uiDna; 

    
    public GameObject Panel;

    public Text txtPanel;

    public Button botao1;
    public Button botao2;
    public Button botao3;

    public GameObject dnaObjt01;
    public GameObject dnaObjt02;
    public GameObject dnaObjt03;


    void Start() {
        ArTapToPlaceObject = this.GetComponent<ARTapToPlaceObject>();
        arMode = false;
        dnaInterface = false;
        Panel.SetActive(false);

        botao1.onClick.AddListener(delegate {AddText(1); });
        botao2.onClick.AddListener(delegate {AddText(2); });
        botao3.onClick.AddListener(delegate {AddText(3); });
    }

    void AddText(int Id) {

        if(Id == 1) {
            ArTapToPlaceObject.TrocarObjetoAR(1);
            // txtPanel.text = "Teste do botão 1";
            // Panel.SetActive(true);
        }else if (Id == 2) {
            ArTapToPlaceObject.TrocarObjetoAR(2);
            // txtPanel.text = "Teste do botão 2";
            // Panel.SetActive(true);
        }else {
            ArTapToPlaceObject.TrocarObjetoAR(3);
            // txtPanel.text = "Teste do botão 3";
            // Panel.SetActive(true);
        }
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


        if(dnaInterface) {
            SetDnaInterfaceVisible(true);
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


    public void ResetaDna() {
        ArTapToPlaceObject.TrocarObjetoAR(4);
    }

}
