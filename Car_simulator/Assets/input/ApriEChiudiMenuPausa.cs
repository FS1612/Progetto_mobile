using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApriEChiudiMenuPausa : MonoBehaviour
{
    [SerializeField] GameObject auto;
    [SerializeField] GameObject Menupausa;
    private bool IsPaused;
    GestioneMovimentoAuto Gestioneauto;
    private bool avviato;
    public bool ModificaAttiva;
    private int StelleAttuali;
    private float VitaAttuale;

    private void Awake()
    {
        Gestioneauto = auto.GetComponent < GestioneMovimentoAuto >();
        IsPaused = GameManager.instance.GetPaused();
       
    }
  
    
    void Start()
    {
        ModificaAttiva = GUIManager.instance.GetModificaAttiva();
        Menupausa.SetActive(false);
       
        if (ModificaAttiva&&IsPaused){ GestioneModifica();}
       
         if (IsPaused&&!ModificaAttiva)
        {

            Menupausa.SetActive(true);
            Time.timeScale = 0f;
            //if (Gestioneauto.GetAvviato()) { Time.timeScale = 0f; }
            //print(Gestioneauto.GetAvviato());
        }

    }
    private void Update()
    {
        StelleAttuali = GameManager.instance.GetStelleAttive();
        VitaAttuale = GameManager.instance.GetVitaAttualeAuto();
        verificaVita();
    }
    public void AttivaPausa(){
        if (!ModificaAttiva)
        {
            Menupausa.SetActive(true);
            //* fermo immagine
            Time.timeScale = 0f;
            GameManager.instance.setPaused(true);
        }

    }
    public void RimuoviPausa() 
    {
        Menupausa.SetActive(false);
        //* rimuovo fermo immagine
        Time.timeScale = 1f;
       GameManager.instance.setPaused(false);
       
    }
    public void MenuIniziale()
    {
        SceneManager.LoadScene(1);

    }
    public void AttivaImpostazioni()
    {//* le scene sono indicizzate nella build il gioco ha indice 0, il menu ha indice 1
        Menupausa.SetActive(false);
        //cambioScene();
        SceneManager.LoadScene(3);

    }
    private void GestioneModifica()
    {
        Menupausa.SetActive(false);
       
        Time.timeScale = 1f;
    }
    private void verificaVita()
    {
        if (VitaAttuale == 0 || StelleAttuali == 3)
        {
            Time.timeScale = 0;
            print("riprova la prossima Volta");
            Menupausa.SetActive(true);
        }
    }
}
