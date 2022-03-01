using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    public static GUIManager instance;
    [SerializeField] GameObject Canvas;
    public bool primoCambiamento = true;//* ho gia modificato le posizioni della gui almeno 1 volta;
    //private Vector3 VettoreVelocita;
    public bool ModificaAttiva = false;
    public bool testoAttivo = true;
    public bool Modificato = false;
    public Vector3 acceleratoreAttuale;
    public Vector3 frenoAttuale;
    public Vector3 frenoamanoAttuale;
    public Vector3 inverterAttuale;
    public Vector3 joystickAttuale;
    public Vector3 volanteAttuale;
    public Vector3 opzioniAttuale;
    public Vector3 barravitaAttuale;
    public Vector3 fpsAttuale;
    public Vector3 tachimetroAttuale;
    public Vector3 acceleratoreDefault;
    public Vector3 frenoDefault;
    public Vector3 frenoamanoDefault;
    public Vector3 inverterDefault;
    public Vector3 joystickDefault;
    public Vector3 volanteDefault;
    public Vector3 opzioniDefault;
    public Vector3 barravitaDefault;
    public Vector3 fpsDefault;
    public Vector3 tachimetroDefault;
    
    public Vector3 ScaleFrenoDefault;
    public Vector3 ScaleFrenoAManoDefault;
    public Vector3 ScaleAcceleratoreDefault;
    public Vector3 ScaleInverterDefault;
    public Vector3 ScaleVolanteDefault;
    public Vector3 ScaleJoistickDefault;
    public Vector3 ScaleOpzioniDefault;
    public Vector3 ScaleBarraVitaDefault;
    public Vector3 ScaleFpsDefault;
    public Vector3 ScaleTachimetroDefault;
    public Vector3 ScaleFrenoAggiornata;
    public Vector3 ScaleFrenoAManoAggiornata;
    public Vector3 ScaleAcceleratoreAggiornata;
    public Vector3 ScaleInverterAggiornata;
    public Vector3 ScaleVolanteAggiornata;
    public Vector3 ScaleJoistickAggiornata;
    public Vector3 ScaleOpzioniAggiornata;
    public Vector3 ScaleBarraVitaAggiornata;
    public Vector3 ScaleFpsAggiornata;
    public Vector3 ScaleTachimetroAggiornata;
    public Color ColoreHandleDefault;
    public Color ColoreHandleAggiornato;
    public Color ColoreCoronaDefault;
    public Color ColoreCoronaAggiornato;

    public Sprite SpriteHandleDefault;
    public Sprite SpriteHandleAggiornato;
    public Sprite SpriteCoronaDefault;
    public Sprite SpriteCoronaAggiornato;
    public bool joistickModificato=false;
  public bool impostazioniAttive=false;
  //  public int StelleAttive = 0;//* da aggiornare

    //MenuImpostazioniPrefab menu;
    RayCast ray;
    public string oggetto;
    //[SerializeField] GameObject Handle;
    //[SerializeField] GameObject joystick;
    [SerializeField] Sprite Sprite1Corona;
    [SerializeField] Sprite Sprite2Corona;
    [SerializeField] Sprite Sprite3Corona;
    [SerializeField] Sprite Sprite4Corona;
    [SerializeField] Sprite Sprite5Corona;
    [SerializeField] Sprite Sprite6Corona;
    [SerializeField] Sprite Sprite1Handle;
    [SerializeField] Sprite Sprite2Handle;
    [SerializeField] Sprite Sprite3Handle;
    [SerializeField] Sprite Sprite4Handle;
    [SerializeField] Sprite Sprite5Handle;
    [SerializeField] Sprite Sprite6Handle;
   



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
    // Start is called before the first frame update
    void Start()
    {
        
        ray = Canvas.GetComponent<RayCast>();
        SpriteCoronaDefault = Sprite1Corona;
        SpriteHandleDefault = Sprite1Handle;
        ColoreHandleDefault = Color.white;
        ColoreCoronaDefault = Color.white;
           ScaleFrenoDefault = new Vector3(1, 1, 1);
        ScaleFrenoAManoDefault = new Vector3(1, 1, 1);
        ScaleAcceleratoreDefault = new Vector3(1, 1, 1);
        ScaleInverterDefault = new Vector3(1, 1, 1);
        ScaleVolanteDefault = new Vector3(1, 1, 1);
        ScaleJoistickDefault = new Vector3(1, 1, 1);
        ScaleOpzioniDefault = new Vector3(1, 1, 1);
        ScaleBarraVitaDefault = new Vector3(1, 1, 1);
        ScaleFpsDefault = new Vector3(1, 1, 1);
        ScaleTachimetroDefault = new Vector3(1, 1, 1);
        acceleratoreDefault = new Vector3(-489.19f, -217f, 0f);
        //frenoDefault = new Vector3(321f, -222.0f, 50f); //* localpos
        //frenoDefault=new Vector3(261f, -317f, 0f);
        //frenoamanoDefault = new Vector3(92.9f, -326f, 0f);
        //inverterDefault = new Vector3(-489.19f, -35.137f, 0f);
        //joystickDefault = new Vector3(-489.19f, -273.8f, 0f); ;
        //volanteDefault = new Vector3(322f, -196.64f, 0f);
        //opzioniDefault = new Vector3(352f, 421.1879f, 0f);
        //barravitaDefault = new Vector3(-456.1751f, 144f, 0f);
        //fpsDefault = new Vector3(200.0693f, 295f, 0f);
        //tachimetroDefault = new Vector3(97.321f, -118.19f, 0f);
       
    }

    // Update is called once per frame
    void Update()
    {
        
        GestioneColori();
        GestioneSprite();
    }
    private void GestioneColori()
    {
        ColoriHandle();
        ColoriCorona();
    }
    private void ColoriHandle()
    {
        if (string.Compare(oggetto, "nero.handle") == 0)
        {
            if (!joistickModificato) { joistickModificato=true; }
            ColoreHandleAggiornato = Color.black;
        }

        if (string.Compare(oggetto, "blu.handle") == 0)
        {
            if (!joistickModificato) { joistickModificato = true; }
            ColoreHandleAggiornato = Color.blue;
        }
        if (string.Compare(oggetto, "ciano.handle ") == 0)
        {
            if (!joistickModificato) { joistickModificato = true; }
            ColoreHandleAggiornato = Color.cyan;
        }
        if (string.Compare(oggetto, "grigio.handle   ") == 0)
        {
            if (!joistickModificato) { joistickModificato = true; }
            ColoreHandleAggiornato = Color.grey;
        }
        if (string.Compare(oggetto, "verde.handle") == 0)
        {
            if (!joistickModificato) { joistickModificato = true; }
            ColoreHandleAggiornato = Color.green;
        }
        if (string.Compare(oggetto, "magenta.handle    ") == 0)
        {
            if (!joistickModificato) { joistickModificato = true; }
            ColoreHandleAggiornato = Color.magenta;
        }

        if (string.Compare(oggetto, "rosso.handle ") == 0)
        {
            if (!joistickModificato) { joistickModificato = true; }
            ColoreHandleAggiornato = Color.red;
        }
        if (string.Compare(oggetto, "bianco.handle      ") == 0)
        {
            if (!joistickModificato) { joistickModificato = true; }
            ColoreHandleAggiornato = Color.white;
        }
        if (string.Compare(oggetto, "giallo.handle  ") == 0)
        {
            if (!joistickModificato) { joistickModificato = true; }
            ColoreHandleAggiornato = Color.yellow;
        }
    }
    private void ColoriCorona()
    {
        if (string.Compare(oggetto, "nero.corona") == 0)
        {
            if (!joistickModificato) { joistickModificato = true; }
            ColoreCoronaAggiornato = Color.black;
        }
        if (string.Compare(oggetto, "blu.corona ") == 0)
        {
            if (!joistickModificato) { joistickModificato = true; }
            ColoreCoronaAggiornato = Color.blue;
        }
        if (string.Compare(oggetto, "ciano.corona  ") == 0)
        {
            if (!joistickModificato) { joistickModificato = true; }
            ColoreCoronaAggiornato = Color.cyan;
        }

        if (string.Compare(oggetto, "grigio.corona   ") == 0)
        {
            if (!joistickModificato) { joistickModificato = true; }
            ColoreCoronaAggiornato = Color.grey;
        }
        if (string.Compare(oggetto, "verde.corona") == 0)
        {
            if (!joistickModificato) { joistickModificato = true; }
            { ColoreCoronaAggiornato = Color.green; }
        }
        if (string.Compare(oggetto, "magenta.corona    ") == 0)
        {
            if (!joistickModificato) { joistickModificato = true; }
            ColoreCoronaAggiornato = Color.magenta;
        }
        if (string.Compare(oggetto, "rosso.corona     ") == 0)
        {
            if (!joistickModificato) { joistickModificato = true; }
            ColoreCoronaAggiornato = Color.red;
        }
        if (string.Compare(oggetto, "bianco.corona      ") == 0)
        {
            if (!joistickModificato) { joistickModificato = true; }
            ColoreCoronaAggiornato = Color.white;
        }
        if (string.Compare(oggetto, "giallo.corona       ") == 0)
        {
            if (!joistickModificato) { joistickModificato = true; }
            ColoreCoronaAggiornato = Color.yellow;
        }

    }
    private void GestioneSprite()
    {
        SpriteHandle();
        SpriteCorona();
    }
    private void SpriteHandle()
    {
        if (string.Compare(oggetto, "Sprite1.handle") == 0) { SpriteHandleAggiornato = Sprite1Handle; if (!joistickModificato) { joistickModificato = true; } }
        if (string.Compare(oggetto, "Sprite2.handle ") == 0) { SpriteHandleAggiornato = Sprite2Handle; if (!joistickModificato) { joistickModificato = true;  } }
        if (string.Compare(oggetto, "Sprite3.handle   ") == 0) { SpriteHandleAggiornato = Sprite3Handle; if (!joistickModificato) { joistickModificato = true; } }
        if (string.Compare(oggetto, "Sprite4.handle    ") == 0) { SpriteHandleAggiornato = Sprite4Handle; if (!joistickModificato) { joistickModificato = true; } }
        if (string.Compare(oggetto, "Sprite5.handle ") == 0) { SpriteHandleAggiornato = Sprite5Handle; if (!joistickModificato) { joistickModificato = true; } }
        if (string.Compare(oggetto, "Sprite6.handle      ") == 0) { SpriteHandleAggiornato = Sprite6Handle; if (!joistickModificato) { joistickModificato = true; } }
    
}
    private void SpriteCorona()
    {
        if (string.Compare(oggetto, "Sprite1.corona") == 0) { SpriteCoronaAggiornato= Sprite1Corona; if (!joistickModificato) { joistickModificato=true; } }
        if (string.Compare(oggetto, "Sprite2.corona  ") == 0) { SpriteCoronaAggiornato = Sprite2Corona; if (!joistickModificato) { joistickModificato = true; } }
        if (string.Compare(oggetto, "Sprite3.corona   ") == 0) { SpriteCoronaAggiornato = Sprite3Corona; if (!joistickModificato) { joistickModificato = true; } }
        if (string.Compare(oggetto, "Sprite4.corona    ") == 0) { SpriteCoronaAggiornato = Sprite4Corona; if (!joistickModificato) { joistickModificato = true; } }
        if (string.Compare(oggetto, "Sprite5.corona     ") == 0) { SpriteCoronaAggiornato = Sprite5Corona; if (!joistickModificato) { joistickModificato = true; } }
        if (string.Compare(oggetto, "Sprite6.corona      ") == 0) { SpriteCoronaAggiornato = Sprite6Corona; if (!joistickModificato) { joistickModificato = true; } }
    }
    public Vector3 GetAcceleratoreAttuale() { return acceleratoreAttuale; }
    public Vector3 GetFrenoAttuale() { return frenoAttuale; }
    public Vector3 GetFrenoAManoAttuale() { return frenoamanoAttuale; }
    public Vector3 GetJoistyckAttuale() { return joystickAttuale; }
    public Vector3 GetVolanteAttuale() { return volanteAttuale; }
    public Vector3 GetInverterAttuale() { return inverterAttuale; }
    public Vector3 GetFpsAttuale() { return fpsAttuale; }
    public Vector3 GetOpzioniAttuale() { return opzioniAttuale; }
    public Vector3 GetBarraVitaAttuale() { return barravitaAttuale; }
    public Vector3 GetTachimetroAttuale() { return tachimetroAttuale; }

    public void SetAcceleratoreAttuale(Vector3 actual) { acceleratoreAttuale = actual; }
    public void SetFrenoAttuale(Vector3 actual) { frenoAttuale = actual; }
    public void SetFrenoAManoAttuale(Vector3 actual) { frenoamanoAttuale = actual; }
    public void SetInverterAttuale(Vector3 actual) { inverterAttuale = actual; }
    public void SetFpsAttuale(Vector3 actual) { fpsAttuale = actual; }
    public void SetOpzioniAttuale(Vector3 actual) { opzioniAttuale = actual; }
    public void SetVolanteAttuale(Vector3 actual) { volanteAttuale = actual; }
    public void SetJoystickAttuale(Vector3 actual) { acceleratoreAttuale = actual; }
    public void SetBarraVitaAttuale(Vector3 actual) { barravitaAttuale = actual; }
    public void SetTachimetroAttuale(Vector3 actual) { tachimetroAttuale = actual; }
    public Vector3 GetAcceleratoreDefault() { return acceleratoreDefault; }
    public Vector3 GetFrenoDefault() { return frenoDefault; }
    public Vector3 GetFrenoAManoDefault() { return frenoamanoDefault; }
    public Vector3 GetJoistyckDefault() { return joystickDefault; }
    public Vector3 GetVolanteDefault() { return volanteDefault; }
    public Vector3 GetInverterDefault() { return inverterDefault; }
    public Vector3 GetFpsDefault() { return fpsDefault; }
    public Vector3 GetOpzioniDefault() { return opzioniDefault; }
    public Vector3 GetBarraVitaDefault() { return barravitaDefault; }
    public Vector3 GetTachimetroDefault() { return tachimetroDefault; }
    public void SetAcceleratoreDefault(Vector3 a) { acceleratoreDefault = a; }
    public void SetFrenoDefault(Vector3 a) { frenoDefault = a; }
    public void SetFrenoAManoDefault(Vector3 a) { frenoamanoDefault = a; }
    public void SetJoistyckDefault(Vector3 a) { joystickDefault = a; }
    public void SetVolanteDefault(Vector3 a) { volanteDefault = a; }
    public void SetInverterDefault(Vector3 a) { inverterDefault = a; }
    public void SetFpsDefault(Vector3 a) { fpsDefault = a; }
    public void SetOpzioniDefault(Vector3 a) { opzioniDefault = a; }
    public void SetBarraVitaDefault(Vector3 a) { barravitaDefault = a; }
    public void SetTachimetroDefault(Vector3 a) { tachimetroDefault = a; }
    public bool GetPrimoCambiamento() { return primoCambiamento; }
    public void SetPrimoCambiamento(bool a) { primoCambiamento = a; }
    public void SetModificaAttiva(bool a){ ModificaAttiva = a; }
    public bool GetModificaAttiva() { return ModificaAttiva; }
    public void SetModificato(bool m) { Modificato = m; }
    public bool GetModificato() { return Modificato; }
    public void SetScaleFrenoAggiornata(Vector3 v) { ScaleFrenoAggiornata = v; }
    public void SetScaleFrenoAManoAggiornata(Vector3 v) { ScaleFrenoAManoAggiornata = v; }
    public void SetScaleAcceleratoreAggiornata(Vector3 v) { ScaleAcceleratoreAggiornata = v; }
    public void SetScaleInverterAggiornata(Vector3 v) { ScaleInverterAggiornata = v; }
    public void SetScaleVolanteAggiornata(Vector3 v) { ScaleVolanteAggiornata = v; }
    public void SetScaleJoistickAggiornata(Vector3 v) { ScaleJoistickAggiornata = v; }
    public void SetScaleOpzioniAggiornata(Vector3 v) { ScaleOpzioniAggiornata = v; }
    public void SetScaleBarraVitaAggiornata(Vector3 v) { ScaleBarraVitaAggiornata = v; }
    public void SetScaleFpsAggiornata(Vector3 v) { ScaleFpsAggiornata = v; }
    public void SetScaleTachimetroAggiornata(Vector3 v) { ScaleTachimetroAggiornata = v; }
    public Vector3 GetScaleFrenoAggiornata() { return ScaleFrenoAggiornata; }
    public Vector3 GetScaleFrenoAManoAggiornata() { return ScaleFrenoAManoAggiornata; }
    public Vector3 GetScaleAcceleratoreAggiornata() { return ScaleAcceleratoreAggiornata; }
    public Vector3 GetScaleInverterAggiornata() { return ScaleInverterAggiornata; }
    public Vector3 GetScaleVolanteAggiornata() { return ScaleVolanteAggiornata; }
    public Vector3 GetScaleJoistickAggiornata() { return ScaleJoistickAggiornata; }
    public Vector3 GetScaleOpzioniAggiornata() { return ScaleOpzioniAggiornata; }
    public Vector3 GetScaleBarraVitaAggiornata() { return ScaleBarraVitaAggiornata; }
    public Vector3 GetScaleFpsAggiornata() { return ScaleFpsAggiornata; }
    public Vector3 GetScaleTachimetroAggiornata() { return ScaleTachimetroDefault; }
    public Vector3 GetScaleFrenoDefault() { return ScaleFrenoDefault; }
    public Vector3 GetScaleFrenoAManoDefault() { return ScaleFrenoAManoDefault; }
    public Vector3 GetScaleAcceleratoreDefault() { return ScaleAcceleratoreDefault; }
    public Vector3 GetScaleInverterDefault() { return ScaleInverterDefault; }
    public Vector3 GetScaleVolanteDefault() { return ScaleVolanteDefault; }
    public Vector3 GetScaleJoistickDefault() { return ScaleJoistickDefault; }
    public Vector3 GetScaleOpzioniDefault() { return ScaleOpzioniDefault; }
    public Vector3 GetScaleBarraVitaDefault() { return ScaleBarraVitaDefault; }
    public Vector3 GetScaleFpsDefault() { return ScaleFpsDefault; }
    public Vector3 GetScaleTachimetroDefault() { return ScaleTachimetroDefault; }
    public bool GetTestoAttivo() { return testoAttivo; }
    public void SetTestoAttivo(bool n) { testoAttivo = n; }
    public void SetColoreHandleAggiornato(Color aggiornato) { ColoreHandleAggiornato = aggiornato; }
    public void SetColoreCoronaAggiornato(Color aggiornato) { ColoreCoronaAggiornato = aggiornato; }
    public Color GetColoreCoronaAggiornato() { return ColoreCoronaAggiornato; }
    public Color GetColoreHandleAggiornato() { return ColoreHandleAggiornato; }

    public void SetSpriteHandleAggiornato(Sprite aggiornato) { SpriteHandleAggiornato = aggiornato; }
    public void SetSpriteCoronaAggiornato(Sprite aggiornato) { SpriteCoronaAggiornato = aggiornato; }
    public Sprite GetSpriteCoronaAggiornato() { return SpriteCoronaAggiornato; }
    public Sprite GetSpriteHandleAggiornato() { return SpriteHandleAggiornato; }
    public Color GetColoreHandleDefault() { return ColoreHandleDefault; }
    public Color GetColoreCoronaDefault() { return ColoreCoronaDefault; }
    public Sprite GetSpriteCoronaDefault() { return SpriteCoronaDefault; }
    public Sprite GetSpriteHandleDefault() { return SpriteHandleDefault; }
    public void SetJoistickModificato(bool m) { joistickModificato = m; }
    public bool GetJoistickModificato() { return joistickModificato ; }
    public void setOggetto(string o) { oggetto = o; }
    public bool GetImpostazioniAttive() { return impostazioniAttive; }
    public void setImpostazioniAttive(bool i) { impostazioniAttive = i; }
    //public int GetStelleAttive() { return StelleAttive; }
    //public void SetStelleAttive(int a) { StelleAttive = a; }
}
