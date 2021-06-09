using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TesteScript : MonoBehaviour
{
    private int index;

    public Button botao1;
    public Button botao2;
    public Button botao3;
    public Button botao4;
    
    public Button botao5;
    public Button botao6;
    public Button botao7;
    public Button botao8;

    public Animator azulAnim;
    public Animator amareloAnim;
    public Animator vermelhoAnim;
    public Animator verdeAnim;

    public GameObject[] azul;
    public GameObject[] amarelo;
    public GameObject[] vermelho;
    public GameObject[] verde;

    public Material mtAzul;
    public Material mtAmarelo;
    public Material mtVermelho;
    public Material mtVerde;


    public GameObject uiTroca; 


    void Start()
    {
        index = 0;
        botao1.enabled = true;
        botao2.enabled = true;
        botao3.enabled = true;
        botao4.enabled = true;

        botao1.onClick.AddListener(delegate {SelecionarDna(1); });
        botao2.onClick.AddListener(delegate {SelecionarDna(2); });
        botao3.onClick.AddListener(delegate {SelecionarDna(3); });
        botao4.onClick.AddListener(delegate {SelecionarDna(4); });

        botao5.onClick.AddListener(delegate {MudarDnaAzul(1); });
        botao6.onClick.AddListener(delegate {MudarDnaAzul(2); });
        botao7.onClick.AddListener(delegate {MudarDnaAzul(3); });
        botao8.onClick.AddListener(delegate {MudarDnaAzul(4); });
    }

    public void SelecionarDna(int Id) {

        if(Id == 1) {
            index++;
            switch (index)
            {
                case 1:
                    uiTroca.GetComponent<Animator>().SetBool("on", true); 
                    uiTroca.GetComponent<Animator>().SetBool("off", false);    
                    azulAnim.SetBool("sai", true);
                    azulAnim.SetBool("entra", false);
                    botao2.interactable = false;
                    botao3.interactable = false;
                    botao4.interactable = false;
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
            
            // ArTapToPlaceObject.TrocarObjetoAR(1);
            // txtPanel.text = "Teste do botão 1";
            // Panel.SetActive(true);
        }else if (Id == 2) {

            index++;
            switch (index)
            {
                case 1:
                    print("Azul");
                    amareloAnim.SetBool("sai", true);
                    amareloAnim.SetBool("entra", false);
                    botao1.interactable = false;
                    botao3.interactable = false;
                    botao4.interactable = false;
                    break;
                case 2:
                    amareloAnim.SetBool("entra", true);
                    amareloAnim.SetBool("sai", false);
                    botao1.interactable = true;
                    botao3.interactable = true;
                    botao4.interactable = true;
                    index = 0;
                    break;
            }
            // ArTapToPlaceObject.TrocarObjetoAR(2);
            // txtPanel.text = "Teste do botão 2";
            // Panel.SetActive(true);
        }else if(Id == 3){
            index++;
            switch (index)
            {
                case 1:
                    print("Azul");
                    vermelhoAnim.SetBool("sai", true);
                    vermelhoAnim.SetBool("entra", false);
                    botao1.interactable = false;
                    botao2.interactable = false;
                    botao4.interactable = false;
                    break;
                case 2:
                    vermelhoAnim.SetBool("entra", true);
                    vermelhoAnim.SetBool("sai", false);
                    botao1.interactable = true;
                    botao2.interactable = true;
                    botao4.interactable = true;
                    index = 0;
                    break;
            }
            // ArTapToPlaceObject.TrocarObjetoAR(3);
            // txtPanel.text = "Teste do botão 3";
            // Panel.SetActive(true);
        }else{
            index++;
            switch (index)
            {
                case 1:
                    print("Azul");
                    verdeAnim.SetBool("sai", true);
                    verdeAnim.SetBool("entra", false);
                    botao1.interactable = false;
                    botao2.interactable = false;
                    botao3.interactable = false;
                    break;
                case 2:
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
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
