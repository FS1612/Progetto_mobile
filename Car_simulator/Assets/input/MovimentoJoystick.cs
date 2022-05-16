using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoJoystick : MonoBehaviour
{
    SterzoASchermo sterzo;
    InputRotazione rot;
    InputTastiera tastiera;
    [SerializeField] private GameObject controller;
    private float Horizontal = 0;
    private float Vertical = 0;
    public Joystick joystick;
    private bool attivo ;
    private bool uso=false;
    private float rotazione;
    //private float rotazioneJoystik;
    //private float rotazioneTastiera;
    //private float rotazioneAccelerometro;
    private bool Retro;
    private void Awake()
    {
        attivo = GameManager.instance.getJoistick();
        sterzo = controller.GetComponent<SterzoASchermo>();
        rot = controller.GetComponent<InputRotazione>();
        tastiera = controller.GetComponent<InputTastiera>();
    }
    

    void Update()
    {
        Horizontal = joystick.Horizontal;

        //if (Vertical < 0) { GameManager.instance.SetRetromarcia(true); }
        //else { GameManager.instance.SetRetromarcia(false); }
        Vertical = joystick.Vertical;
        //print(Vertical);
        Movimento();
        VerificaRetro();
    }
    
   private void Movimento() {
        if (GameManager.instance.getJoistick()) { rotazione = Horizontal; }
        if (GameManager.instance.GetSterzoAttivo()) { rotazione = sterzo.GetClampedValue(); }
        if (GameManager.instance.GetAccelerometroAttivo()) { rotazione = rot.GetRotazione(); }
        else if ((!GameManager.instance.getJoistick())&&(!GameManager.instance.GetSterzoAttivo())&&(!GameManager.instance.GetAccelerometroAttivo()))
            { rotazione = tastiera.MovimentoOrizzontaleGetter(); }
        GameManager.instance.SetRotazione(rotazione);
    }
    public float HorizontalJoystickGetter()
        {
        return Horizontal; 
        }
    public float VerticalJoystickGetter()
    {
        return Vertical;
    }
    
    private void VerificaRetro()
    {
        if (Vertical < 0) { Retro=true; }
        else { Retro=false; }
    }
    public bool GetRetro()
    {
        return Retro;
    }
}
