using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputAcceleratore : MonoBehaviour
{
    MovimentoJoystick joystick;
    InputTastiera tastiera;

    [SerializeField] private GameObject controller;
    private float VerticalInput;
    public bool retromarcia;
    public bool retromarciabottone;
    public bool retromarciatastiera;
    public bool retromarciajoistick;
    private float accelerazione;
    private bool PulsantePremuto = false;
    private bool accelero= false;
    private float valore;
    private float valoreFinale;
    private float Vertical;
    public void Retromarcia()
    {
        if (!retromarcia)
        {
            retromarciabottone = true;
            //GameManager.instance.SetRetromarcia(true);
            //print("retro");
        }
        else if (retromarcia)
        {
            retromarciabottone = false;
            //GameManager.instance.SetRetromarcia(false);
            //print("avanti");
        }
    }
    public void PremiAcceleratore()
    {
        
        //if (!retromarcia)
        //{
        //    //accelerazione = 1f;
        //    if(PulsantePremuto)
        //    GameManager.instance.SetAcceleratore(1f);
        //    //print("vado avanti");
           
        //}
        //if (retromarcia)
        //{
        //    //accelerazione = -1f;
        //    //print("vado indietro");
        //    if (PulsantePremuto)
        //        GameManager.instance.SetAcceleratore(-1f);
        //}

        PulsantePremuto = true;
        
    }
    public void RilasciaAcceleratore()
    {
 
        PulsantePremuto = false;
        
    }
    private void Start()
    {
        joystick = controller.GetComponent<MovimentoJoystick>();
        tastiera = controller.GetComponent<InputTastiera>();
    }
    private void FixedUpdate()
    {
        //retromarciaattiva = GameManager.instance.GetRetromarcia();
        Vertical = joystick.VerticalJoystickGetter();
        //print(retromarcia);
        GetInput();
        VerificaAccelerazione();
        Movimento();
        //if (PulsantePremuto) { valoreFinale = valore; }
        //if (!PulsantePremuto) { valoreFinale = VerticalInput; }
        //if (GameManager.instance.getJoistick()) { valoreFinale = joystick.VerticalJoystickGetter(); }
        //GameManager.instance.SetAcceleratore(valoreFinale);
        RetromarciaJoistick();
        RetromarciaTastiera();
        Aggiornamento();
        MovimentoVerticale();
        //GameManager.instance.SetRetromarcia(retromarcia);

    }
    private void GetInput()
    {
        VerticalInput = Input.GetAxis("Vertical");
        //GameManager.instance.SetAcceleratore(VerticalInput);
        
        
    }
    private void VerificaAccelerazione()
    {
        
        if ((VerticalInput == 0)||(accelerazione==0))
        {
            accelero = false;
        }
        else if ((VerticalInput == 1)||((accelerazione == 1)))
        {
            accelero = true;
        }
    }
    private void Movimento()
    {
        if (PulsantePremuto)
        {
            if (!retromarcia)
            {
                //GameManager.instance.SetAcceleratore(1f);
                valore = 1f;
            }
            else if (retromarcia)
            {
                //GameManager.instance.SetAcceleratore(-1f);
                valore = -1f;
            }
        }
        //else GameManager.instance.SetAcceleratore(0f);
        else valore = 0f;
    }
   
    //public float AccelerazioneGetter()
    //{
       
    //    return VerticalInput;
    //}
    //public float AccelerazionePulsanteGetter()
    //{
       
    //    return accelerazione;
    //}
    //public bool StatoPulsanteGetter()
    //{
    //    return PulsantePremuto;
    //}
    public bool StatoAcceleratoreGetter()
    {
        return accelero;
    }
    public bool retromarciaGetter()
    {
        return retromarcia;
    }
    private void RetromarciaJoistick()
    {
        if (joystick.GetRetro()) { retromarciajoistick = true; }
        else retromarciajoistick=false;

    }
    private void RetromarciaTastiera()
    {
        if (tastiera.MovimentoVerticaleGetter() < 0)
        {
            retromarciatastiera = true;
        }
        else retromarciatastiera = false;
        }
    private void Aggiornamento()
    {
        //if (retromarciatastiera || retromarciabottone || retromarciajoistick) { GameManager.instance.SetRetromarcia(true); }
        //else GameManager.instance.SetRetromarcia(false);
        if ( retromarciabottone||retromarciatastiera) { retromarcia = true; }
        else { retromarcia = false; }
        //if ( GameManager.instance.SoloTastieraGetter()) {
        //    if (retromarciatastiera) { retromarcia = true; }
        //    else retromarcia = false;
        //}
        if (GameManager.instance.getJoistick()) {
            if (retromarciajoistick) { retromarcia = true; }
            else retromarcia = false;
        }
        GameManager.instance.SetRetromarcia(retromarcia);
    }
    private void MovimentoVerticale()
    {
        if (PulsantePremuto) { valoreFinale = valore; }
        if (!PulsantePremuto) { valoreFinale = VerticalInput; }
        if (GameManager.instance.getJoistick()) { valoreFinale =Vertical ; }
        //print(Vertical);
        GameManager.instance.SetAcceleratore(valoreFinale);
    }
    }
