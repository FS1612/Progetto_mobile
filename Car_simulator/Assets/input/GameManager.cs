using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public string tastoToccato;
    public bool joistickattivo = false;
    public bool IsPaused = false;
    public bool SoloTastiera = false;
    public bool AccelerometroAttivo;
    public bool ContatoreFpsAttivo = false;
    public bool SterzoAttivo = false;
    public float VitaTotaleAuto = 100f;
    public float VitaAttualeAuto;
    public float VelocitaAttuale;
    public float VelocitaIniziale = 0;
    public Vector3 PosizioneAttuale;
    public Vector3 PosizioneIniziale;
    public bool primoavvio = true;
    public bool frenoamano = true;
    public bool freno;
    public float rotazione;
    public float acceleratore;
    public bool retromarcia;
   
    public int LimiterFps;
    public bool avviato;
    public bool impostazioniAttive = false;
    public int StelleAttive = 0;//* da aggiornare
    //public bool Vsync=false;
    //public int antialiassetting=2;
    private void Start()
    {//* valido per la mappa di prova : la posizione iniziale va stabilita in fase di avvio del gioco, in fase di precaricamento

        PosizioneIniziale.x = 0.2f / Time.deltaTime;
        PosizioneIniziale.y = 0.004f / Time.deltaTime;
        PosizioneIniziale.z = 0.09999999f / Time.deltaTime;
        AccelerometroAttivo = true;
        retromarcia = false;
     
}
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }


    }
    private void Update()
    {
        if (StelleAttive > 3)
        {
            StelleAttive = 3;
        }
        else if (StelleAttive < 0)
        {
            StelleAttive = 0;
        }
    }
    public bool SoloTastieraGetter()
    {
        return SoloTastiera;

    }
    public void SoloTastieraSetter(bool Tastiera)
    {
        SoloTastiera = Tastiera;
    }
    public bool getIsPaused()
    {
        return IsPaused;
    }
    public bool getJoistick()
    {
        return joistickattivo;
    }
    public void setPaused(bool p)
    {
        IsPaused = p;
    }
    public bool GetPaused()
    {
        return IsPaused;
    }
    public bool GetAccelerometroAttivo()
    {
        return AccelerometroAttivo;
    }
    public void SetAccelerometroAttivobool(bool a)
    {
        AccelerometroAttivo = a;
    }
    public void SetJoistickattivobool(bool att)
    {
        joistickattivo = att;
    }
    public void SetContatoreFpsAttivoBool(bool fps)
    {
        ContatoreFpsAttivo = fps;
    }
    public bool GetContatoreFpsAttivo()
    {
        return ContatoreFpsAttivo;
    }
    public float GetVitaTotaleAuto()
    {
        return VitaTotaleAuto;
    }
    public void SetVitaTotaleAuto(float vita)
    {
        VitaTotaleAuto = vita;
    }
    public float GetVitaAttualeAuto()
    {
        return VitaAttualeAuto;
    }
    public void SetVitaAttualeAuto(float vitaAttuale)
    {
        VitaAttualeAuto = vitaAttuale;
    }
    public void SetVelocitaAttuale(float v)
    {
        VelocitaAttuale = v;
    }
    public float GetVelocitaAttuale()
    {
        return VelocitaAttuale;
    }
    public bool GetSterzoAttivo()
    {
        return SterzoAttivo;
    }
    public void SetSterzoAttivo(bool attivo)
    {
        SterzoAttivo = attivo;
    }
    public float GetVelocitaIniziale()
    {
        return VelocitaIniziale;
    }
    public void SetVelocitaIniziale(float v)
    {
        VelocitaIniziale = v;
    }
    public Vector3 GetPosizioneIniziale()
    {
        return PosizioneIniziale;
    }
    public void SetPosizioneIniziale(Vector3 pos)
    {
        PosizioneIniziale = pos;
    }
    public Vector3 GetPosizioneAttuale()
    {
        return PosizioneAttuale;
    }
    public void SetPosizioneAttuale(Vector3 pos)
    {
        PosizioneAttuale = pos;
    }
    public bool GetPrimoAvvio()
    {
        return primoavvio;
    }
    public void SetPrimoAvvio(bool primo)
    {
        primoavvio = primo;
    }
    public void SetFrenoAMano(bool freno1)
    {
        frenoamano = freno1;
    }
    public bool GetFrenoAmano()
    {
        return frenoamano;
    }
    public void SetFreno(bool freno2)
    {
        freno = freno2;
    }
    public bool GetFreno()
    {
        return freno;
    }
    public float GetAcceleratore()
    {
        return acceleratore;
    }
    public void SetAcceleratore(float acc)
    {
        acceleratore = acc;
    }
    public void SetRetromarcia(bool retro)
    {
        retromarcia = retro;
    }
    public bool GetRetromarcia()
    {
        return retromarcia;
    }
    public float GetRotazione()
    {
        return rotazione;
    }
    public void SetRotazione(float rot)
    {
        rotazione = rot;
    }
    //public Vector3 GetVettoreVelocita() {
    //    return VettoreVelocita;
    //}
    //public void SetVettoreVelocita(Vector3 vel)
    //{
    //    VettoreVelocita = vel;
    //}
    public int GetLimiterFps() { return LimiterFps; }
    public void SetLimiterFps(int l) { LimiterFps = l; }
    public void SetAvviato(bool a) { avviato = a; }
    public bool GetAvviato() { return avviato; }
    public void setTastoToccato(string t) { tastoToccato = t; }
   public string GetTastoToccato() { return tastoToccato; }
    public int GetStelleAttive() { return StelleAttive; }
    public void SetStelleAttive(int a) { StelleAttive = a; }
}

