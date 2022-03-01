using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuImpostazioniPrefab : MonoBehaviour
{
    //statoTastiImpostazioni stato;
    [SerializeField] GameObject pannelloColoriCorona;
    [SerializeField] GameObject pannelloSpriteCorona;
    [SerializeField] GameObject pannelloColoriHandle;
    [SerializeField] GameObject pannelloSpriteHandle;
    [SerializeField] Text testoSpiegazioni;
    
    [SerializeField] Slider Slider;
    //[SerializeField] Text TestoSlider;
    [SerializeField] Text TestoSlidereffettivo;
    [SerializeField] Dropdown DropdownRisoluzioni;
    [SerializeField] Dropdown DropdownAntialiasing;
    [SerializeField] Dropdown DropdownQualita;
    [SerializeField] Dropdown DropdownShadows;
    [SerializeField] Dropdown DropdownTexture;

    [SerializeField] GameObject PannelloAvvertenzaFps;
    

    [SerializeField] GameObject PannelloGestioneComandi;
    [SerializeField] GameObject PannelloGrafica;
    [SerializeField] GameObject PannelloGui;

    private const string Abilitato = "Abilitato";
    private const string Disabilitato = "Disabilitato";
    private const string FpsAllert = "Con questo slider potrai impostare i limite massimo degli fps. " +
        "potrai scegliere tra i valori compresi fra 0 e 60 dove 0 corrisponde a disabilitare il limitatore e 60 al massimo degli fps raggiungibili ";
    private bool sterzo;
    private bool attivaJoistick;
    private bool soloTastiera;
    private bool AccelerometroAttivo;
    private bool fpsCounter;
    private int fpsLimiter;
    private int RisoluzioneCorrente;
    private bool mostrataAvvertenza;
    private bool Vsyncattivo =false;
    private bool GestioneComandiAttiva = false;
    private bool GestioneGraficaAttiva = false;
    private bool GestioneGUIAttiva = false;
    private bool TestoAttivo ;
    //private bool impostazioniAttive ;
    //* voglio sapere che risoluzioni sono supportate, mi creo un array
    Resolution[] RisoluzioniDisponibili;
    //* toggle 
    [SerializeField] Toggle ToggleJoistick;

    [SerializeField] Toggle ToggleTastiera;

    [SerializeField] Toggle ToggleSterzo;

    [SerializeField] Toggle ToggleAccelerometro;

    [SerializeField] Toggle ToggleFps;
   
    [SerializeField] Toggle ToggleVsync;
    [SerializeField] Toggle ToggleTesto;

    //public ToggleGroup[] Comandi;
    //private Toggle Gruppo;
    private void Awake()
    {
        Slider.value = GameManager.instance.GetLimiterFps();
        
    }
    private void Start()
    {
         GUIManager.instance.setImpostazioniAttive(true);
        pannelloColoriCorona.SetActive(true);
        pannelloColoriHandle.SetActive(true);
        pannelloSpriteCorona.SetActive(false);
        pannelloSpriteHandle.SetActive(false);
        mostrataAvvertenza = GraphicManager.instance.GetAvvertenzaMostrata();
        DropdownTexture.SetValueWithoutNotify(GraphicManager.instance.GetTextureQuality());
        DropdownShadows.SetValueWithoutNotify(GraphicManager.instance.GetQualitaOmbre());
        DropdownAntialiasing.SetValueWithoutNotify(GraphicManager.instance.GetAntiAliasing());
        DropdownQualita.SetValueWithoutNotify(GraphicManager.instance.GetQualitaVideo());
        PannelloAvvertenzaFps.SetActive(false);
        PannelloGui.SetActive(false);
        //* ho un array di risoluzioni disponibili
        RisoluzioneCorrente = 0;
        RisoluzioniDisponibili = Screen.resolutions;
        //* ogni dispositivo ha risoluzioni differenti, quindi ad ogni avvio devo togliere le vecchie risoluzioni
        DropdownRisoluzioni.ClearOptions();
        List<string> OpzioniRisoluzione = new List<string>();
        //* devo copiare l'array nella lista 
        for(int i=0; i<RisoluzioniDisponibili.Length;i++)
        {
            // ad ogni iterazione creo una nuova stringa lunghezza x altezza
            string option = RisoluzioniDisponibili[i].width + "x" + RisoluzioniDisponibili[i].height;
            //* aggiungo alla lista
            OpzioniRisoluzione.Add(option);
            //* voglio sapere sempre qual'è la risoluzione corrente. per farlo devo comparare di volta in volta prima ampiezza poi altezza
            if (RisoluzioniDisponibili[i].height == Screen.currentResolution.height && RisoluzioniDisponibili[i].width == Screen.currentResolution.width)
            {
                RisoluzioneCorrente = i;
            }
        }
        //* voglio aggiungere le varie opzioni alla lista, ma la fz AddOptions richiede una lista di stringhe e non un arrey di valori
        DropdownRisoluzioni.AddOptions(OpzioniRisoluzione);
        //* mantengo sempre aggiornata la risoluzione corrente
        DropdownRisoluzioni.value = RisoluzioneCorrente;
        DropdownRisoluzioni.RefreshShownValue();
      
        GameManager.instance.SetPrimoAvvio(false);
        PannelloGestioneComandi.SetActive(false);
        PannelloGrafica.SetActive(false);
       
        ToggleAccelerometro.isOn = GameManager.instance.GetAccelerometroAttivo();
        ToggleJoistick.isOn = GameManager.instance.getJoistick();
        ToggleTastiera.isOn = GameManager.instance.SoloTastieraGetter();
        ToggleSterzo.isOn = GameManager.instance.GetSterzoAttivo();
        ToggleVsync.isOn = GraphicManager.instance.GetVsyncAttivo();
        ToggleFps.isOn = GameManager.instance.GetContatoreFpsAttivo();
        ToggleTesto.isOn = GUIManager.instance.GetTestoAttivo();
    }
   
    private void Update()
    {
        
        SliderSetUp();
        TestoAttivo = GUIManager.instance.GetTestoAttivo();
        
        AccelerometroAttivo = GameManager.instance.GetAccelerometroAttivo();
        attivaJoistick = GameManager.instance.getJoistick();
        soloTastiera = GameManager.instance.SoloTastieraGetter();
        fpsCounter = GameManager.instance.GetContatoreFpsAttivo();
        sterzo = GameManager.instance.GetSterzoAttivo();
        

    }
   
    //private void AggiornaToggle()
    //{
    //    //ToggleAccelerometro.isOn = AccelerometroAttivo;
    //    //ToggleJoistick.isOn = attivaJoistick;
    //    //ToggleTastiera.isOn = soloTastiera;
    //    //ToggleSterzo.isOn = sterzo;
    //    if (PlayerPrefs.GetInt("ToggleSelected")==0)
    //    {
    //        ToggleAccelerometro.isOn = true;
    //        ToggleTastiera.isOn = false;
    //        ToggleSterzo.isOn = false;
    //        ToggleJoistick.isOn = false;
    //    }
    //    else if (PlayerPrefs.GetInt("ToggleSelected") ==1)
    //    {
    //        ToggleAccelerometro.isOn = false;
    //        ToggleTastiera.isOn = false;
    //        ToggleSterzo.isOn = false;
    //        ToggleJoistick.isOn = true;
    //    }
    //   else if (PlayerPrefs.GetInt("ToggleSelected") == 2)
    //    {
    //        ToggleAccelerometro.isOn = false;
    //        ToggleTastiera.isOn = true;
    //        ToggleSterzo.isOn = false;
    //        ToggleJoistick.isOn = true;
    //    }
    //   else  if (PlayerPrefs.GetInt("ToggleSelected") == 3)
    //    {
    //        ToggleAccelerometro.isOn = false;
    //        ToggleTastiera.isOn = false;
    //        ToggleSterzo.isOn = true;
    //        ToggleJoistick.isOn = false;
    //    }
    
    
    //}
    //private void MostraStato()
    //{
    //    if (AccelerometroAttivo) { StatoAccelerometro.text = Abilitato; StatoAccelerometro.color = Color.green;}
    //    if (attivaJoistick){ StatoJoistick.text = Abilitato; StatoJoistick.color = Color.green; }
    //    if (soloTastiera) { StatoTastiera.text = Abilitato; StatoTastiera.color = Color.yellow; }
    //    if (fpsCounter) { StatoCounterFps.text = Abilitato; StatoCounterFps.color = Color.green; }
    //    if (sterzo) { StatoVolante.text = Abilitato; StatoVolante.color = Color.green; }
    //    if (!AccelerometroAttivo) { StatoAccelerometro.text = Disabilitato; StatoAccelerometro.color = Color.red; }
    //    if (!attivaJoistick) { StatoJoistick.text = Disabilitato; StatoJoistick.color = Color.red; }
    //    if (!soloTastiera) { StatoTastiera.text = Disabilitato; StatoTastiera.color = Color.yellow; }
    //    if (!fpsCounter) { StatoCounterFps.text = Disabilitato; StatoCounterFps.color = Color.red; }
    //    if (!sterzo) { StatoVolante.text = Disabilitato; StatoVolante.color = Color.red; }
    //}
    private void SliderSetUp()
    {
        
        Slider.onValueChanged.AddListener((v) =>
            fpsLimiter = Mathf.RoundToInt(v));
        fpsLimiter = Mathf.RoundToInt(Slider.value);
        if (fpsLimiter > 0 && fpsLimiter < 30) { fpsLimiter = 30; }
        if (fpsLimiter > 30 && fpsLimiter < 60) { fpsLimiter = 60; }
        if (fpsLimiter > 60 && fpsLimiter < 144) { fpsLimiter = 144; }
        Slider.value = fpsLimiter;
         TestoSlidereffettivo.text= fpsLimiter.ToString("0");
        GameManager.instance.SetLimiterFps(fpsLimiter);
        testoSpiegazioni.text = FpsAllert;
        testoSpiegazioni.color = Color.cyan;
    }
    public void AggiornaRisoluzione(int IndiceRisoluzione)
    {
        //* per trovare la risoluzione corretta da applicare sfrutto l'indice passato come parametro
        Resolution risoluzione = RisoluzioniDisponibili[IndiceRisoluzione];
        Screen.SetResolution(risoluzione.width, risoluzione.height, Screen.fullScreen);
    }
    public void QualitaVideo(int indiceQualita)
    {
        GraphicManager.instance.SetQualitaVideo(indiceQualita);
    }   
    public void AttivaAccelerometro(bool attivo)
    {
        if (!AccelerometroAttivo&&attivo)
        {
            GameManager.instance.SetSterzoAttivo(false);
            GameManager.instance.SetJoistickattivobool(false);
            GameManager.instance.SetAccelerometroAttivobool(true);
            //ToggleJoistick.isOn = false;
            //ToggleSterzo.isOn = false;
            PlayerPrefs.SetInt("ToggleSelected", 0);
        }
        else if (AccelerometroAttivo&&!attivo)
        {

            
            GameManager.instance.SetAccelerometroAttivobool(false);
        }
       
    }
    public void AttivaJoistick( bool attivo)
    {
        if (!attivaJoistick&& attivo)
        {
            GameManager.instance.SetJoistickattivobool(true);
            GameManager.instance.SetSterzoAttivo(false);
            GameManager.instance.SoloTastieraSetter(false);
            GameManager.instance.SetAccelerometroAttivobool(false);
            
            PlayerPrefs.SetInt("ToggleSelected", 1); 
        }
        else if (attivaJoistick&&!attivo)
        {
            GameManager.instance.SetJoistickattivobool(false);
            
        }
    } 
    public void AttivaTesto(bool attivo)
    {
        if (!TestoAttivo && attivo)
        {
            GUIManager.instance.SetTestoAttivo(true);
            
        }
        else if (TestoAttivo && !attivo){
            GUIManager.instance.SetTestoAttivo(false);
            
        }
    }
    public void indietro()
    {
        Time.timeScale = 1f;
    
    SceneManager.LoadScene(0, LoadSceneMode.Single);
        
    }
    public void SoloTastiera(bool attivo)
    {
        if (!soloTastiera&&attivo)
        {
            GameManager.instance.SoloTastieraSetter(true);
            GameManager.instance.SetJoistickattivobool(false);
            GameManager.instance.SetSterzoAttivo(false);
            GameManager.instance.SetAccelerometroAttivobool(false);
            //ToggleAccelerometro.isOn = false;
            //ToggleJoistick.isOn = false;
            //ToggleSterzo.isOn = false;
            PlayerPrefs.SetInt("ToggleSelected", 2); 
        }
        else if (soloTastiera&&!attivo)
        {
            GameManager.instance.SoloTastieraSetter(false);
            
        }
    }
    public void AttivaDisplayFps(bool attivo)
    {
        if (!fpsCounter&& attivo)
        {
            if (!mostrataAvvertenza)
            {
                PannelloAvvertenzaFps.SetActive(true);
                mostrataAvvertenza = false;
            }
           
            GameManager.instance.SetContatoreFpsAttivoBool(true);
        }
        else if (fpsCounter&&!attivo)
        {
            GameManager.instance.SetContatoreFpsAttivoBool(false);
        }
    }
    public void AttivaSterzo(bool attivo)
    {
        if (!sterzo&&attivo)
        {
            GameManager.instance.SetSterzoAttivo(true);
            GameManager.instance.SetJoistickattivobool(false);
            GameManager.instance.SoloTastieraSetter(false);
            GameManager.instance.SetAccelerometroAttivobool(false);
            //ToggleAccelerometro.onValueChanged.AddListener((v)=>ste);
            //ToggleTastiera.isOn = false;
            //ToggleAccelerometro.isOn = false;
            //ToggleJoistick.isOn = false;
            PlayerPrefs.SetInt("ToggleSelected",3);
        }
        else if (sterzo&&!attivo)
        {
            GameManager.instance.SetSterzoAttivo(false);
        }
    }
    public void ApriPannelloComandi()
    {
        if (!GestioneComandiAttiva)
        {
            PannelloGestioneComandi.SetActive(true);
            GestioneComandiAttiva = true;
        }
        else
        {
            PannelloGestioneComandi.SetActive(false);
            GestioneComandiAttiva = false;
        }
    }
    public void ApriPannelloGrafica()
    {
        if (!GestioneGraficaAttiva)
        {
           PannelloGrafica.SetActive(true);
            GestioneGraficaAttiva = true;
        }
        else
        {
            PannelloGrafica.SetActive(false);
            GestioneGraficaAttiva = false;
        }
    }
    public void verticalSyncro(bool attivo)
    {
        if (!Vsyncattivo && attivo)
        {
            //QualitySettings.vSyncCount = 1;
            PlayerPrefs.SetInt("ToggleActivated", 4);
            GraphicManager.instance.SetVsyncAttivo(true);
            Vsyncattivo = true;
        }
        if (Vsyncattivo && !attivo)
        {
            //QualitySettings.vSyncCount = 0;

            GraphicManager.instance.SetVsyncAttivo(false);
            Vsyncattivo = false;
        }
    }
    public void Antialiasingsettings(int indice)
    {
        if (indice == 0)
        {
            GraphicManager.instance.SetAntialiasing(0);
        }
        if (indice == 1)
        {
            GraphicManager.instance.SetAntialiasing(1);
        }
        if (indice == 2)
        {
            GraphicManager.instance.SetAntialiasing(2);
        }
        if (indice == 3)
        {
            GraphicManager.instance.SetAntialiasing(3);
        }

    }
    public void ShadowQualitySetting(int quality) { GraphicManager.instance.SetLivelloOmbre(quality); }
    public void TextureQuality(int quality) { GraphicManager.instance.SetQualitaTexture(quality); }
    public void ChiudiAvvertenzaFps() { PannelloAvvertenzaFps.SetActive(false); }
    public void ModificaTasti() { 
        SceneManager.LoadScene(0, LoadSceneMode.Single);
        GUIManager.instance.SetModificaAttiva(true);
    }
    public void ApriImpostazioniGui() {
        if (!GestioneGUIAttiva)
        {
            PannelloGui.SetActive(true);
            GestioneGUIAttiva = true;
        }
        else
        {
            PannelloGui.SetActive(false);
            GestioneGUIAttiva = false;
        }
    }
    public void ColoriCorona()
    {
        pannelloColoriCorona.SetActive(true);
        pannelloSpriteCorona.SetActive(false);
    }
    public void ColoriHandle()
    {
        pannelloColoriHandle.SetActive(true);
        pannelloSpriteHandle.SetActive(false);
    }
    public void SpriteCorona()
    {
        pannelloColoriCorona.SetActive(false);
        pannelloSpriteCorona.SetActive(true);
    }
    public void SpriteHandle()
    {
        pannelloColoriHandle.SetActive(false);
        pannelloSpriteHandle.SetActive(true);
    }
    
}
