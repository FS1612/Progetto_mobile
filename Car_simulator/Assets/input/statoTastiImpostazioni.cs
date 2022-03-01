using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class statoTastiImpostazioni : MonoBehaviour
{
    [SerializeField] Text StatoJoistick;
    [SerializeField] Text StatoTastiera;
    [SerializeField] Text StatoAccelerometro;
    [SerializeField] Text StatoVolante;
    [SerializeField] Text StatoCounterFps;

    private const string Abilitato = "Abilitato";
    private const string Disabilitato = "Disabilitato";
    private bool TastieraAttiva;
    private bool JoistickAttivo;
    private bool SterzoAttivo;
    private bool AccelerometroAttivo;
    private bool FpsAttivo;
    private void Awake()
    {
        FpsAttivo = GameManager.instance.GetContatoreFpsAttivo();
        SterzoAttivo = GameManager.instance.GetSterzoAttivo();
        JoistickAttivo = GameManager.instance.getJoistick();
        TastieraAttiva = GameManager.instance.SoloTastieraGetter();
        AccelerometroAttivo = GameManager.instance.GetAccelerometroAttivo();
    }
    void Start()
    {
        StatoAccelerometro.enabled = true;
        StatoCounterFps.enabled = true;
        StatoJoistick.enabled = true;
        StatoTastiera.enabled = true;
        StatoVolante.enabled = true;
    }

    // Update is called once per frame
    public void GetStato()
    {
        FpsAttivo = GameManager.instance.GetContatoreFpsAttivo();
        SterzoAttivo = GameManager.instance.GetSterzoAttivo();
        JoistickAttivo = GameManager.instance.getJoistick();
        TastieraAttiva = GameManager.instance.SoloTastieraGetter();
        AccelerometroAttivo = GameManager.instance.GetAccelerometroAttivo();
        StatoAccelerometro.enabled = true;
        StatoCounterFps.enabled = true;
        StatoJoistick.enabled = true;
        StatoTastiera.enabled = true;
        StatoVolante.enabled = true;
        //FpsAttivo = GameManager.instance.GetContatoreFpsAttivo();
        //SterzoAttivo = GameManager.instance.GetSterzoAttivo();
        //JoistickAttivo = GameManager.instance.getJoistick();
        //TastieraAttiva = GameManager.instance.SoloTastieraGetter();
        AccelerometroAttivo = GameManager.instance.GetAccelerometroAttivo();
        controlloAccelerometro();
        controlloTastiera();
        controllojoistick();
        controllosterzo();
        controlloFps();
    }
    private void controlloAccelerometro() {
        if (AccelerometroAttivo )
        {
            StatoAccelerometro.enabled = true;
            StatoAccelerometro.text = Abilitato;
        }
        
        else if (!AccelerometroAttivo)
        {
            StatoAccelerometro.text = Disabilitato;
        }
            }
    private void controlloTastiera() {
        if (GameManager.instance.SoloTastieraGetter())
        {
            StatoTastiera.text = Abilitato;
        }
        else if (!GameManager.instance.SoloTastieraGetter())
        {
            StatoTastiera.text = Disabilitato;
        }
    }
    private void controllojoistick() {
        if (GameManager.instance.getJoistick())
        {
            StatoJoistick.text = Abilitato;
        }
        else if (!GameManager.instance.getJoistick())
        {
            StatoJoistick.text = Disabilitato;
        }
    }
    private void controllosterzo() {
        if (GameManager.instance.GetSterzoAttivo())
        {
            StatoVolante.text = Abilitato;
        }
        else if (!GameManager.instance.GetSterzoAttivo())
        {
            StatoVolante.text = Disabilitato;
        }
    }
    private void controlloFps() {
        if (GameManager.instance.GetContatoreFpsAttivo())
        {
            StatoCounterFps.text = Abilitato;
        }
        else if (!GameManager.instance.GetContatoreFpsAttivo())
        {
            StatoCounterFps.text = Disabilitato;
        }
    }


}
