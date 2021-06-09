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
    public GameObject uiTroca; 

    public static Animator azulAnim;
    public static Animator amareloAnim;
    public static Animator vermelhoAnim;
    public static Animator verdeAnim;

    public Button botao1;
    public Button botao2;
    public Button botao3;
    public Button botao4;

    public Button botao5;
    public Button botao6;
    public Button botao7;
    public Button botao8;

    public static GameObject[] azul;
    public static GameObject[] amarelo;
    public static GameObject[] vermelho;
    public static GameObject[] verde;

    public Material mtAzul;
    public Material mtAmarelo;
    public Material mtVermelho;
    public Material mtVerde;

    private int index;

    void Start() {
        azul = new GameObject[6];
        amarelo = new GameObject[6];
        vermelho = new GameObject[6];
        verde = new GameObject[6];

        ArTapToPlaceObject = this.GetComponent<ARTapToPlaceObject>();
        arMode = false;
        dnaInterface = false;
        index = 0;
        botao1.enabled = true;
        botao2.enabled = true;
        botao3.enabled = true;
        botao4.enabled = true;

        
        botao1.onClick.AddListener(delegate {SelecionarDna(1); });
        botao2.onClick.AddListener(delegate {SelecionarDna(2); });
        botao3.onClick.AddListener(delegate {SelecionarDna(3); });
        botao4.onClick.AddListener(delegate {SelecionarDna(4); });

        
    }

    public void SelecionarDna(int Id) {
        botao5.onClick.AddListener(delegate {; });
        botao6.onClick.AddListener(delegate {; });
        botao7.onClick.AddListener(delegate {; });
        botao8.onClick.AddListener(delegate {; });
        if(Id == 1) {
            index++;
            switch (index) {
                case 1:
                    uiTroca.GetComponent<Animator>().SetBool("on", true); 
                    uiTroca.GetComponent<Animator>().SetBool("off", false);          
                    azulAnim.SetBool("sai", true);
                    azulAnim.SetBool("entra", false);
                    botao2.interactable = false;
                    botao3.interactable = false;
                    botao4.interactable = false;

                    botao5.onClick.AddListener(delegate {MudarDnaAzul(1); });
                    botao6.onClick.AddListener(delegate {MudarDnaAzul(2); });
                    botao7.onClick.AddListener(delegate {MudarDnaAzul(3); });
                    botao8.onClick.AddListener(delegate {MudarDnaAzul(4); });
                    break;
                case 2:
                    uiTroca.GetComponent<Animator>().SetBool("off", true);
                    uiTroca.GetComponent<Animator>().SetBool("on", false);
                    azulAnim.SetBool("entra", true);
                    azulAnim.SetBool("sai", false);
                    botao2.interactable = true;
                    botao3.interactable = true;
                    botao4.interactable = true;
                    index = 0;
                    break;
            }
            
        }else if (Id == 2) {
            index++;
            switch (index) {
                case 1:
                    uiTroca.GetComponent<Animator>().SetBool("on", true);
                    uiTroca.GetComponent<Animator>().SetBool("off", false);
                    print("Azul");
                    amareloAnim.SetBool("sai", true);
                    amareloAnim.SetBool("entra", false);
                    botao1.interactable = false;
                    botao3.interactable = false;
                    botao4.interactable = false; 

                    botao5.onClick.AddListener(delegate {MudarDnaAmarelo(1); });
                    botao6.onClick.AddListener(delegate {MudarDnaAmarelo(2); });
                    botao7.onClick.AddListener(delegate {MudarDnaAmarelo(3); });
                    botao8.onClick.AddListener(delegate {MudarDnaAmarelo(4); });
                    break;
                case 2:
                    uiTroca.GetComponent<Animator>().SetBool("off", true);
                    uiTroca.GetComponent<Animator>().SetBool("on", false);
                    amareloAnim.SetBool("entra", true);
                    amareloAnim.SetBool("sai", false);
                    botao1.interactable = true;
                    botao3.interactable = true;
                    botao4.interactable = true;
                    index = 0;
                    break;
            }
            
        }else if(Id == 3) {
            index++;
            switch (index)
            {
                case 1:
                    uiTroca.GetComponent<Animator>().SetBool("on", true);
                    uiTroca.GetComponent<Animator>().SetBool("off", false);
                    vermelhoAnim.SetBool("sai", true);
                    vermelhoAnim.SetBool("entra", false);
                    botao1.interactable = false;
                    botao2.interactable = false;
                    botao4.interactable = false;

                    botao5.onClick.AddListener(delegate {MudarDnaVermelho(1); });
                    botao6.onClick.AddListener(delegate {MudarDnaVermelho(2); });
                    botao7.onClick.AddListener(delegate {MudarDnaVermelho(3); });
                    botao8.onClick.AddListener(delegate {MudarDnaVermelho(4); });
                    break;
                case 2:
                    uiTroca.GetComponent<Animator>().SetBool("off", true);
                    uiTroca.GetComponent<Animator>().SetBool("on", false);
                    vermelhoAnim.SetBool("entra", true);
                    vermelhoAnim.SetBool("sai", false);
                    botao1.interactable = true;
                    botao2.interactable = true;
                    botao4.interactable = true;
                    index = 0;
                    break;
            }
        
        }else {
            index++;
            switch (index)
            {
                case 1:
                    uiTroca.GetComponent<Animator>().SetBool("on", true);
                    uiTroca.GetComponent<Animator>().SetBool("off", false);
                    verdeAnim.SetBool("sai", true);
                    verdeAnim.SetBool("entra", false);
                    botao1.interactable = false;
                    botao2.interactable = false;
                    botao3.interactable = false;

                    botao5.onClick.AddListener(delegate {MudarDnaVerde(1); });
                    botao6.onClick.AddListener(delegate {MudarDnaVerde(2); });
                    botao7.onClick.AddListener(delegate {MudarDnaVerde(3); });
                    botao8.onClick.AddListener(delegate {MudarDnaVerde(4); });
                    break;
                case 2:
                    uiTroca.GetComponent<Animator>().SetBool("off", true);
                    uiTroca.GetComponent<Animator>().SetBool("on", false);
                    verdeAnim.SetBool("entra", true);
                    verdeAnim.SetBool("sai", false);
                    botao1.interactable = true;
                    botao2.interactable = true;
                    botao3.interactable = true;
                    index = 0;
                    break;
            }


        }
    }

    public void MudarDnaAzul(int index) {

            switch (index) {
                case 1:
                for (int i = 0; i < azul.Length; i++) {
                    azul[i].GetComponent<Renderer>().material = mtAzul;
                }
                    break;
                case 2:
                for (int i = 0; i < azul.Length; i++) {
                    azul[i].GetComponent<Renderer>().material = mtAmarelo;
                }
                    break;
                case 3:
                for (int i = 0; i < azul.Length; i++) {
                    azul[i].GetComponent<Renderer>().material = mtVermelho;
                }
                    break;
                case 4:
                for (int i = 0; i < azul.Length; i++) {
                    azul[i].GetComponent<Renderer>().material = mtVerde;
                }
                    break;
                
            }
    } 
    public void MudarDnaAmarelo(int index) {

            switch (index) {
                case 1:
                for (int i = 0; i < amarelo.Length; i++) {
                    amarelo[i].GetComponent<Renderer>().material = mtAzul;
                }
                    break;
                case 2:
                for (int i = 0; i < amarelo.Length; i++) {
                    amarelo[i].GetComponent<Renderer>().material = mtAmarelo;
                }
                    break;
                case 3:
                for (int i = 0; i < amarelo.Length; i++) {
                    amarelo[i].GetComponent<Renderer>().material = mtVermelho;
                }
                    break;
                case 4:
                for (int i = 0; i < amarelo.Length; i++) {
                    amarelo[i].GetComponent<Renderer>().material = mtVerde;
                }
                    break;
                
            }
    } 
    public void MudarDnaVermelho(int index) {

            switch (index) {
                case 1:
                for (int i = 0; i < vermelho.Length; i++) {
                    vermelho[i].GetComponent<Renderer>().material = mtAzul;
                }
                    break;
                case 2:
                for (int i = 0; i < vermelho.Length; i++) {
                    vermelho[i].GetComponent<Renderer>().material = mtAmarelo;
                }
                    break;
                case 3:
                for (int i = 0; i < vermelho.Length; i++) {
                    vermelho[i].GetComponent<Renderer>().material = mtVermelho;
                }
                    break;
                case 4:
                for (int i = 0; i < vermelho.Length; i++) {
                    vermelho[i].GetComponent<Renderer>().material = mtVerde;
                }
                    break;
                
            }
    } 
    public void MudarDnaVerde(int index) {

            switch (index) {
                case 1:
                for (int i = 0; i < verde.Length; i++) {
                    verde[i].GetComponent<Renderer>().material = mtAzul;
                }
                    break;
                case 2:
                for (int i = 0; i < verde.Length; i++) {
                    verde[i].GetComponent<Renderer>().material = mtAmarelo;
                }
                    break;
                case 3:
                for (int i = 0; i < verde.Length; i++) {
                    verde[i].GetComponent<Renderer>().material = mtVermelho;
                }
                    break;
                case 4:
                for (int i = 0; i < verde.Length; i++) {
                    verde[i].GetComponent<Renderer>().material = mtVerde;
                }
                    break;
                
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
        SceneManager.LoadScene("DnaScene");
    }

}
