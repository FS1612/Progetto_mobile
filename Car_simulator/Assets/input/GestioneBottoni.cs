using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GestioneBottoni : MonoBehaviour
{
    //[SerializeField] private TextMeshProUGUI FpsASchermo;
    [SerializeField] private GameObject ControlloJoystick;
    //[SerializeField] private GameObject BottoneJoysticAttivo;
    [SerializeField] private GameObject BottoneAcceleratore;
    [SerializeField] private GameObject BottoneFreno;
    [SerializeField] private GameObject BottoneFrenoAmano;
    [SerializeField] private GameObject BottoneCambio;
    [SerializeField] private GameObject Controller;
    //[SerializeField] private GameObject BottoneAccelerometro;
    //[SerializeField] private WheelCollider ruota;
    //[SerializeField] private GameObject BottonePausa;
    [SerializeField] private GameObject SterzoASchermo;
    [SerializeField] private GameObject TastoIndietro;
    [SerializeField] private GameObject Avvertenze;
    [SerializeField] private GameObject Handle;

    //[SerializeField] Sprite Sprite1Corona;
    //[SerializeField] Sprite Sprite2Corona;
    //[SerializeField] Sprite Sprite3Corona;
    //[SerializeField] Sprite Sprite4Corona;
    //[SerializeField] Sprite Sprite5Corona;
    //[SerializeField] Sprite Sprite6Corona;
    //[SerializeField] Sprite Sprite1Handle;
    //[SerializeField] Sprite Sprite2Handle;
    //[SerializeField] Sprite Sprite3Handle;
    //[SerializeField] Sprite Sprite4Handle;
    //[SerializeField] Sprite Sprite5Handle;
    //[SerializeField] Sprite Sprite6Handle;

    InputFreno freno;
    InputAcceleratore acceleratore;
    MovimentoJoystick joystick;
    vERIFICAMOVIMENTO mov;
    //private bool fpsattivi;
    public bool ModificaAttiva;
    public bool sterzoAttivo;
    public bool tastiera;
    public bool stato;
    public bool Joistickattivo;
    private bool TestoAttivo;
    private bool modificatoJoistick;
    
    private void Awake()
    {
        
        //Joistickattivo = GameManager.instance.getJoistick();
        //tastiera = GameManager.instance.SoloTastieraGetter();
        //sterzoAttivo = GameManager.instance.GetSterzoAttivo();
    }
    private void Start()
    {
        modificatoJoistick = GUIManager.instance.GetJoistickModificato();
        TestoAttivo = GUIManager.instance.GetTestoAttivo();
        Avvertenze.SetActive(false);
        TastoIndietro.SetActive(false);
        ModificaAttiva = GUIManager.instance.GetModificaAttiva();
        //FpsASchermo.enabled=false;
        ControlloJoystick.SetActive(false);
        joystick = Controller.GetComponent<MovimentoJoystick>();
        freno = Controller.GetComponent<InputFreno>();
       acceleratore = Controller.GetComponent<InputAcceleratore>();
        mov = Controller.GetComponent<vERIFICAMOVIMENTO>();
        SterzoASchermo.SetActive(false);
        BottoneCambio.SetActive(true);
        if (ModificaAttiva) { TastoIndietro.SetActive(true); } 
        else { TastoIndietro.SetActive(false); }
    }

    void Update()
    {
        Joistickattivo = GameManager.instance.getJoistick();
        tastiera = GameManager.instance.SoloTastieraGetter();
        sterzoAttivo = GameManager.instance.GetSterzoAttivo();

        //fpsattivi = GameManager.instance.GetContatoreFpsAttivo();
        if (!TestoAttivo) { MostraTesti(); }
        VerificaStato();
        gestioneStato();
        //GestoreBottoni();
        gestioneSterzo();
        gestioneJoistick();
        if (tastiera) { GestioneTastiera(); }
        
        //gestioneFps();
        
    } 
    private void MostraTesti()
    {
        BottoneAcceleratore.GetComponent<Transform>().gameObject.GetComponentInChildren<Text>().enabled=false;
        BottoneFrenoAmano.GetComponent<Transform>().gameObject.GetComponentInChildren<Text>().enabled = false;
        BottoneFreno.GetComponent<Transform>().gameObject.GetComponentInChildren<Text>().enabled = false;
        BottoneCambio.GetComponent<Transform>().gameObject.GetComponentInChildren<Text>().enabled = false;
        

    }
    private void VerificaStato()
    {
        //if (mov.MovimentoGetter())
        //{
        //    stato = true;
        //}
        //else stato = false;
        if (GameManager.instance.GetVelocitaAttuale() != 0) { stato = true; }
        else if(GameManager.instance.GetVelocitaAttuale() == 0) stato = false;
        //if (stato) {
        //    BottoneFrenoAmano.SetActive(false);
        //     BottoneCambio.SetActive(false);

        //}
        //else 
        //{
        //    BottoneFrenoAmano.SetActive(true);
        //    BottoneCambio.SetActive(true);
        //}
    }

    private void gestioneStato()
    {
        if (stato)
        {
            BottoneFrenoAmano.SetActive(false);
            BottoneCambio.SetActive(false);

        }
        else if (!stato)
        {
            BottoneFrenoAmano.SetActive(true);
            BottoneCambio.SetActive(true);
        }
    }
        //private void GestoreBottoni()
        //{
        //    if (!Joistickattivo)

        //    {
        //        ControlloJoystick.SetActive(false);
        //        BottoneAcceleratore.SetActive(true);
        //        if (stato)
        //        {
        //            BottoneFrenoAmano.SetActive(false);
        //            BottoneCambio.SetActive(false);


        //        }

        //        else if (!stato)

        //        {
        //            BottoneFrenoAmano.SetActive(true);
        //            BottoneCambio.SetActive(true);

        //        }
        //    }

        //     else if (Joistickattivo)
        //     {
        //        BottoneFrenoAmano.SetActive(true);
        //        ControlloJoystick.SetActive(true);
        //        BottoneCambio.SetActive(false);

        //        BottoneAcceleratore.SetActive(false);

        //        if (stato)
        //        {
        //            BottoneFrenoAmano.SetActive(false);
        //        }


        //     }



        //}
        private void gestioneSterzo()
    {
        if (sterzoAttivo)
        {
            SterzoASchermo.SetActive(true);
        }
        else if (!sterzoAttivo) { SterzoASchermo.SetActive(false); }
    }
    private void gestioneJoistick()
    {
        if (Joistickattivo)
        {
            ControlloJoystick.SetActive(true);
            BottoneAcceleratore.SetActive(false);
            BottoneCambio.SetActive(false);
            verificaSpriteColori();
            if (ModificaAttiva) { ControlloJoystick.GetComponent<FixedJoystick>().enabled = false; }
            else { ControlloJoystick.GetComponent<FixedJoystick>().enabled = true; }
        }
        else if (!Joistickattivo)
        {
            ControlloJoystick.SetActive(false);
            BottoneAcceleratore.SetActive(true);

        }
    }
    private void verificaSpriteColori()
    {
        if (modificatoJoistick)
        {

            ControlloJoystick.GetComponentInChildren<Image>().color = GUIManager.instance.GetColoreCoronaAggiornato(); 
            ControlloJoystick.GetComponentInChildren<Image>().sprite = GUIManager.instance.GetSpriteCoronaAggiornato();
            Handle.GetComponentInChildren<Image>().color = GUIManager.instance.GetColoreHandleAggiornato();
            Handle.GetComponentInChildren<Image>().sprite = GUIManager.instance.GetSpriteHandleAggiornato();
            

        }
        else
        {
            ControlloJoystick.GetComponentInChildren<Image>().color = GUIManager.instance.GetColoreCoronaDefault();
            ControlloJoystick.GetComponentInChildren<Image>().sprite = GUIManager.instance.GetSpriteCoronaDefault();
            Handle.GetComponentInChildren<Image>().color = GUIManager.instance.GetColoreHandleDefault();
            Handle.GetComponentInChildren<Image>().sprite = GUIManager.instance.GetSpriteHandleDefault();
            
        }
    }
    
    private void GestioneTastiera()
    {
        BottoneAcceleratore.SetActive(false);
        BottoneFreno.SetActive(false);
        BottoneFrenoAmano.SetActive(false);
        BottoneCambio.SetActive(false);
    }

    //private void gestioneFps()
    //{
    //    if (fpsattivi)
    //    {
    //        FpsASchermo.enabled = true;
    //   }
    //    else { FpsASchermo.enabled = false; }
    //}
    public void esci()
    {
        Application.Quit();
    }
}
