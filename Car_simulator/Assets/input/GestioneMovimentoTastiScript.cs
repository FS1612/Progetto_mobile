using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GestioneMovimentoTastiScript : MonoBehaviour
{
    //private DragDefinitivo drag;
    private Vector3 frenoiniziale;
    private Vector3 frenoamanoiniziale;
    private Vector3 acceleratoreiniziale;
    private Vector3 inverteriniziale;
    private Vector3 joistickiniziale;
    private Vector3 volanteiniziale;
    private Vector3 opzioniiniziale;
    private Vector3 barravitainiziale;
    private Vector3 tachimetroiniziale;
    private Vector3 fpsiniziale;
    private Vector3 frenoaggiornato;
    private Vector3 frenoamanoaggiornato;
    private Vector3 acceleratoreaggiornato;
    private Vector3 inverteraggiornato;
    private Vector3 joistickaggiornato;
    private Vector3 volanteaggiornato;
    private Vector3 opzioniaggiornato;
    private Vector3 barravitaaggiornato;
    private Vector3 tachimetroaggiornato;
    private Vector3 fpsaggiornato;

    private Vector3 scalefrenoAggiornato;
    private Vector3 scalefrenoamanoaggiornato;
    private Vector3 scaleacceleratoreaggiornato;
    private Vector3 scaleinverteraggiornato;
    private Vector3 scalejoistickaggiornato;
    private Vector3 scalevolanteaggiornato;
    private Vector3 scaleopzioniaggiornato;
    private Vector3 scalebarravitaaggiornato;
    private Vector3 scaletachimetroaggiornato;
    private Vector3 scalefpsaggiornato;

    //TestoAVideo testo;
    private bool frenoAggiornato=false;
    private bool frenoAmanoAggiornato = false;
    private bool InverteroAggiornato = false;
    private bool AcceleratoreAggiornato = false;
    private bool SterzoAggiornato = false;
    private bool JoistickAggiornato = false;
    private bool BarraVitaAggiornato = false;
    private bool FpsAggiornato = false;
    private bool OpzioniAggiornato = false;
    private bool TachimetroAggiornato = false;
    [SerializeField] GameObject acceleratore ;
    [SerializeField] GameObject freno;
    [SerializeField] GameObject frenoamano;
    [SerializeField] GameObject inverter;
    [SerializeField] GameObject tachimetro;
    [SerializeField] GameObject joystick;
    [SerializeField] GameObject sterzo;
    [SerializeField] GameObject fps;
    [SerializeField] GameObject barravita;
    [SerializeField] GameObject opzioni;
    [SerializeField] GameObject PannelloAvvertenze;
    [SerializeField] GameObject ControlloTouch;
    [SerializeField] GameObject stelle;
    //[SerializeField] GameObject Controller;
    private bool primoCambio;
    private bool ModificaAttiva;
    //[SerializeField] Text testo; 
    public void Start()
    {
        joystick.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
        freno.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
        frenoamano.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
        acceleratore.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
        inverter.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
        joystick.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
        opzioni.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
        barravita.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
        fps.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
        tachimetro.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
        //drag = freno.GetComponent<DragDefinitivo>();
        freno.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
        //testo.enabled = (true);
        //testo = Controller.GetComponent<TestoAVideo>();
        ModificaAttiva = GUIManager.instance.GetModificaAttiva();
        PannelloAvvertenze.SetActive(false);
        primoCambio = GUIManager.instance.GetPrimoCambiamento();
        //primoCambio = true;
        ControlloTouch.SetActive(false);

        if (ModificaAttiva)
        {
            ControlloTouch.SetActive(true);
            if (primoCambio)
            {
                //print(primoCambio);
                BottoniDefault();
                
                GUIManager.instance.SetPrimoCambiamento(false);
            }
            else if (!primoCambio)
            {
                print(primoCambio + "finto");
                BottoniSet();
            }
            GUIManager.instance.SetModificato(true);
           
        }
        else return;
    }
   private void BottoniDefault()
    {
        CaricaDefault();
    }
    private void CaricaDefault()
    {
        ////Debug.Log("default");
        frenoiniziale = GUIManager.instance.GetFrenoDefault();
        ////freno.transform.localPosition = new Vector3(0, 0, 0); ;
        //freno.transform.localPosition = frenoiniziale; ;
        frenoamanoiniziale = GUIManager.instance.GetFrenoAManoDefault();
        //frenoamano.transform.localPosition = frenoamanoiniziale;
        acceleratoreiniziale = GUIManager.instance.GetAcceleratoreDefault();
        //acceleratore.transform.localPosition = acceleratoreiniziale;
        inverteriniziale = GUIManager.instance.GetInverterDefault();
        //inverter.transform.localPosition = inverteriniziale;
        joistickiniziale = GUIManager.instance.GetJoistyckDefault();
        //joystick.transform.position = joistickiniziale;
        volanteiniziale = GUIManager.instance.GetVolanteDefault();
        //sterzo.transform.localPosition = volanteiniziale;
        opzioniiniziale = GUIManager.instance.GetOpzioniDefault();
        //opzioni.transform.localPosition = opzioniiniziale;
        barravitainiziale = GUIManager.instance.GetBarraVitaDefault();
        //barravita.transform.localPosition = barravitainiziale;
        tachimetroiniziale = GUIManager.instance.GetTachimetroDefault();
        //tachimetro.transform.localPosition = tachimetroiniziale;
        fpsiniziale = GUIManager.instance.GetFpsDefault();
        //fps.transform.localPosition = fpsiniziale;

        freno.transform.localScale = GUIManager.instance.GetScaleFrenoDefault();
        frenoamano.transform.localScale = GUIManager.instance.GetScaleFrenoAManoDefault();
        acceleratore.transform.localScale = GUIManager.instance.GetScaleAcceleratoreDefault();
        inverter.transform.localScale = GUIManager.instance.GetScaleInverterDefault();
        sterzo.transform.localScale = GUIManager.instance.GetScaleVolanteDefault();
        joystick.transform.localScale = GUIManager.instance.GetScaleJoistickDefault();
        opzioni.transform.localScale = GUIManager.instance.GetScaleOpzioniDefault();
        barravita.transform.localScale = GUIManager.instance.GetScaleBarraVitaDefault();
        fps.transform.localScale = GUIManager.instance.GetScaleFpsDefault();
        tachimetro.transform.localScale = GUIManager.instance.GetScaleTachimetroDefault();
        //frenoiniziale = GUIManager.instance.GetFrenoDefault();
        //freno.transform.localPosition = new Vector3(0, 0, 0); ;
        //freno.transform.position = frenoiniziale; ;
        //frenoamanoiniziale = GUIManager.instance.GetFrenoAManoDefault();
        //frenoamano.transform.position = frenoamanoiniziale;
        //acceleratoreiniziale = GUIManager.instance.GetAcceleratoreDefault();
        //acceleratore.transform.position = acceleratoreiniziale;
        //inverteriniziale = GUIManager.instance.GetInverterDefault();
        //inverter.transform.position = inverteriniziale;
        //joistickiniziale = GUIManager.instance.GetJoistyckDefault();
        //joystick.transform.position = joistickiniziale;
        //volanteiniziale = GUIManager.instance.GetVolanteDefault();
        //sterzo.transform.position = volanteiniziale;
        //opzioniiniziale = GUIManager.instance.GetOpzioniDefault();
        //opzioni.transform.position = opzioniiniziale;
        //barravitainiziale = GUIManager.instance.GetBarraVitaDefault();
        //barravita.transform.position = barravitainiziale;
        //tachimetroiniziale = GUIManager.instance.GetTachimetroDefault();
        //tachimetro.transform.position = tachimetroiniziale;
        //fpsiniziale = GUIManager.instance.GetFpsDefault();
        //fps.transform.position = fpsiniziale;
        GUIManager.instance.SetAcceleratoreAttuale(acceleratoreiniziale);
        GUIManager.instance.SetFrenoAManoAttuale(frenoamanoiniziale);
        GUIManager.instance.SetFrenoAttuale(frenoiniziale);
        GUIManager.instance.SetInverterAttuale(inverteriniziale);
        GUIManager.instance.SetOpzioniAttuale(opzioniiniziale);
        GUIManager.instance.SetBarraVitaAttuale(barravitainiziale);
        GUIManager.instance.SetJoystickAttuale(joistickiniziale);
        GUIManager.instance.SetVolanteAttuale(volanteiniziale);
        GUIManager.instance.SetTachimetroAttuale(tachimetroiniziale);
        GUIManager.instance.SetFpsAttuale(fpsiniziale);

        GUIManager.instance.SetScaleFrenoAggiornata(GUIManager.instance.GetScaleFrenoDefault());
        GUIManager.instance.SetScaleFrenoAManoAggiornata(GUIManager.instance.GetScaleFrenoAManoDefault());
        GUIManager.instance.SetScaleAcceleratoreAggiornata(GUIManager.instance.GetScaleAcceleratoreDefault());
        GUIManager.instance.SetScaleInverterAggiornata(GUIManager.instance.GetScaleInverterDefault());
        GUIManager.instance.SetScaleOpzioniAggiornata(GUIManager.instance.GetScaleOpzioniDefault());
        GUIManager.instance.SetScaleBarraVitaAggiornata(GUIManager.instance.GetScaleBarraVitaDefault());
        GUIManager.instance.SetScaleJoistickAggiornata(GUIManager.instance.GetScaleJoistickDefault());
        GUIManager.instance.SetScaleVolanteAggiornata(GUIManager.instance.GetScaleVolanteDefault());
        GUIManager.instance.SetScaleTachimetroAggiornata(GUIManager.instance.GetScaleTachimetroDefault());
        GUIManager.instance.SetScaleFpsAggiornata(GUIManager.instance.GetScaleFpsDefault());



    }
    private void BottoniSet()
    {
        //frenoiniziale= GUIManager.instance.GetFrenoAttuale();
        //freno.transform.localPosition = frenoiniziale;
        //frenoamanoiniziale = GUIManager.instance.GetFrenoAManoAttuale();
        //frenoamano.transform.localPosition = frenoamanoiniziale;
        //acceleratoreiniziale = GUIManager.instance.GetAcceleratoreAttuale();
        //acceleratore.transform.localPosition = acceleratoreiniziale;
        //inverteriniziale = GUIManager.instance.GetInverterAttuale();
        //inverter.transform.localPosition = inverteriniziale;
        //opzioniiniziale = GUIManager.instance.GetOpzioniAttuale();
        //opzioni.transform.localPosition = opzioniiniziale;
        //barravitainiziale = GUIManager.instance.GetBarraVitaAttuale();
        //barravita.transform.localPosition = barravitainiziale;
        //joistickiniziale = GUIManager.instance.GetJoistyckAttuale();
        //joystick.transform.localPosition = joistickiniziale;
        //volanteiniziale = GUIManager.instance.GetVolanteAttuale();
        //sterzo.transform.localPosition = volanteiniziale;
        //tachimetroiniziale = GUIManager.instance.GetTachimetroAttuale();
        //tachimetro.transform.localPosition = tachimetroiniziale;
        //fpsiniziale = GUIManager.instance.GetFpsAttuale();
        //fps.transform.localPosition = fpsiniziale;
        //freno.transform.position = GUIManager.instance.GetFrenoAttuale();
        freno.transform.parent.localScale = GUIManager.instance.GetScaleFrenoAggiornata();
        frenoamano.transform.parent.localScale = GUIManager.instance.GetScaleFrenoAManoAggiornata();
        acceleratore.transform.parent.localScale = GUIManager.instance.GetScaleAcceleratoreAggiornata();
        inverter.transform.parent.localScale = GUIManager.instance.GetScaleInverterAggiornata();
        sterzo.transform.parent.localScale = GUIManager.instance.GetScaleVolanteAggiornata();
        joystick.transform.parent.localScale = GUIManager.instance.GetScaleJoistickAggiornata();
        opzioni.transform.parent.localScale = GUIManager.instance.GetScaleOpzioniAggiornata();
        barravita.transform.parent.localScale = GUIManager.instance.GetScaleBarraVitaAggiornata();
        fps.transform.parent.localScale = GUIManager.instance.GetScaleFpsAggiornata();
        tachimetro.transform.parent.localScale = GUIManager.instance.GetScaleTachimetroAggiornata();

        frenoiniziale = GUIManager.instance.GetFrenoAttuale();
        freno.transform.parent.localPosition = frenoiniziale;
        frenoamanoiniziale = GUIManager.instance.GetFrenoAManoAttuale();
        frenoamano.transform.parent.localPosition = frenoamanoiniziale;
        acceleratoreiniziale = GUIManager.instance.GetAcceleratoreAttuale();
        acceleratore.transform.parent.localPosition = acceleratoreiniziale;
        inverteriniziale = GUIManager.instance.GetInverterAttuale();
        inverter.transform.parent.localPosition = inverteriniziale;
        opzioniiniziale = GUIManager.instance.GetOpzioniAttuale();
        opzioni.transform.parent.localPosition = opzioniiniziale;
        barravitainiziale = GUIManager.instance.GetBarraVitaAttuale();
        barravita.transform.parent.localPosition = barravitainiziale;
        joistickiniziale = GUIManager.instance.GetJoistyckAttuale();
        joystick.transform.parent.localPosition = joistickiniziale;
        volanteiniziale = GUIManager.instance.GetVolanteAttuale();
        sterzo.transform.parent.localPosition = volanteiniziale;
        tachimetroiniziale = GUIManager.instance.GetTachimetroAttuale();
        tachimetro.transform.parent.localPosition = tachimetroiniziale;
        fpsiniziale = GUIManager.instance.GetFpsAttuale();
        fps.transform.parent.localPosition = fpsiniziale;

        GUIManager.instance.SetAcceleratoreAttuale(acceleratoreiniziale); 
         GUIManager.instance.SetFrenoAManoAttuale(frenoamanoiniziale); 
         GUIManager.instance.SetFrenoAttuale(frenoiniziale); 
         GUIManager.instance.SetInverterAttuale(inverteriniziale); 
         GUIManager.instance.SetOpzioniAttuale(opzioniiniziale); 
         GUIManager.instance.SetBarraVitaAttuale(barravitainiziale); 
         GUIManager.instance.SetJoystickAttuale(joistickiniziale); 
         GUIManager.instance.SetVolanteAttuale(volanteiniziale); 
         GUIManager.instance.SetTachimetroAttuale(tachimetroiniziale); 
         GUIManager.instance.SetFpsAttuale(fpsiniziale);
         GUIManager.instance.SetScaleFrenoAggiornata(GUIManager.instance.GetScaleFrenoAggiornata());
    }
    private void Update()
    {
        if (ModificaAttiva)
        {
            
            //frenoaggiornato = new Vector3(freno.transform.localPosition.x, freno.transform.localPosition.y, freno.transform.localPosition.z);
            //frenoamanoaggiornato = new Vector3(frenoamano.transform.position.x, frenoamano.transform.position.y, frenoamano.transform.position.z);
            //acceleratoreaggiornato = new Vector3(acceleratore.transform.position.x, acceleratore.transform.position.y, acceleratore.transform.position.z);
            //inverteraggiornato = new Vector3(inverter.transform.position.x, inverter.transform.position.y, inverter.transform.position.z);
            //joistickaggiornato = new Vector3(joystick.transform.position.x, joystick.transform.position.y, joystick.transform.position.z);
            //volanteaggiornato = new Vector3(sterzo.transform.position.x, sterzo.transform.position.y, sterzo.transform.position.z);
            //opzioniaggiornato = new Vector3(opzioni.transform.position.x, opzioni.transform.position.y, opzioni.transform.position.z);
            //barravitaaggiornato = new Vector3(barravita.transform.position.x, barravita.transform.position.y, barravita.transform.position.z);
            //tachimetroaggiornato = new Vector3(tachimetro.transform.position.x, tachimetro.transform.position.y, tachimetro.transform.position.z);
            //fpsaggiornato = new Vector3(fps.transform.position.x, fps.transform.position.y, fps.transform.position.z);



            frenoaggiornato = new Vector3(freno.transform.parent.localPosition.x, freno.transform.parent.localPosition.y, freno.transform.parent.localPosition.z);
            //frenoaggiornato = new Vector3(freno.transform.localPosition.x, freno.transform.localPosition.y, freno.transform.localPosition.z);
            frenoamanoaggiornato = new Vector3(frenoamano.transform.parent.localPosition.x, frenoamano.transform.parent.localPosition.y, frenoamano.transform.parent.localPosition.z);
            acceleratoreaggiornato = new Vector3(acceleratore.transform.parent.localPosition.x, acceleratore.transform.parent.localPosition.y, acceleratore.transform.parent.localPosition.z);
            inverteraggiornato = new Vector3(inverter.transform.parent.localPosition.x, inverter.transform.parent.localPosition.y, inverter.transform.parent.localPosition.z);
            joistickaggiornato = new Vector3(joystick.transform.parent.localPosition.x, joystick.transform.parent.localPosition.y, joystick.transform.parent.localPosition.z);
            volanteaggiornato = new Vector3(sterzo.transform.parent.localPosition.x, sterzo.transform.parent.localPosition.y, sterzo.transform.parent.localPosition.z);
            opzioniaggiornato = new Vector3(opzioni.transform.parent.localPosition.x, opzioni.transform.parent.localPosition.y, opzioni.transform.parent.localPosition.z);
            barravitaaggiornato = new Vector3(barravita.transform.parent.localPosition.x, barravita.transform.parent.localPosition.y, barravita.transform.parent.localPosition.z);
            tachimetroaggiornato = new Vector3(tachimetro.transform.parent.localPosition.x, tachimetro.transform.parent.localPosition.y, tachimetro.transform.parent.localPosition.z);
            fpsaggiornato = new Vector3(fps.transform.parent.localPosition.x, fps.transform.parent.localPosition.y, fps.transform.parent.localPosition.z);

            //GUIManager.instance.SetAcceleratoreAttuale(acceleratoreaggiornato);
            //GUIManager.instance.SetFrenoAManoAttuale(frenoamanoaggiornato);
            //GUIManager.instance.SetFrenoAttuale(frenoaggiornato);
            //GUIManager.instance.SetInverterAttuale(inverteraggiornato);
            //GUIManager.instance.SetOpzioniAttuale(opzioniaggiornato);
            //GUIManager.instance.SetBarraVitaAttuale(barravitaaggiornato);
            //GUIManager.instance.SetJoystickAttuale(joistickaggiornato);
            //GUIManager.instance.SetVolanteAttuale(volanteaggiornato);
            //GUIManager.instance.SetTachimetroAttuale(tachimetroaggiornato);
            //GUIManager.instance.SetFpsAttuale(fpsaggiornato);
            scalefrenoAggiornato=new Vector3(freno.transform.parent.localScale.x, freno.transform.parent.localScale.y, freno.transform.parent.localScale.z); 
            scalefrenoamanoaggiornato=new Vector3(frenoamano.transform.parent.localScale.x, frenoamano.transform.parent.localScale.y, frenoamano.transform.parent.localScale.z); 
            scaleacceleratoreaggiornato = new Vector3(acceleratore.transform.parent.localScale.x, acceleratore.transform.parent.localScale.y, acceleratore.transform.parent.localScale.z);
            scaleinverteraggiornato = new Vector3(inverter.transform.parent.localScale.x, inverter.transform.parent.localScale.y, inverter.transform.parent.localScale.z);
            scalejoistickaggiornato = new Vector3(joystick.transform.parent.localScale.x, joystick.transform.parent.localScale.y, joystick.transform.parent.localScale.z);
            scalevolanteaggiornato = new Vector3(sterzo.transform.parent.localScale.x, sterzo.transform.parent.localScale.y, sterzo.transform.parent.localScale.z);
            scaleopzioniaggiornato = new Vector3(opzioni.transform.parent.localScale.x, opzioni.transform.parent.localScale.y, opzioni.transform.parent.localScale.z);
            scalebarravitaaggiornato = new Vector3(barravita.transform.parent.localScale.x, barravita.transform.parent.localScale.y, barravita.transform.parent.localScale.z);
            scaletachimetroaggiornato = new Vector3(tachimetro.transform.parent.localScale.x, tachimetro.transform.parent.localScale.y, tachimetro.transform.parent.localScale.z);
            scalefpsaggiornato = new Vector3(fps.transform.parent.localScale.x, fps.transform.parent.localScale.y, fps.transform.parent.localScale.z);
    VerificaSpostamenti();
            AggiornaScala();
        }
        else return;
    }
    public void initReset()
    {
        CaricaDefault();
        GUIManager.instance.SetModificaAttiva(false);
        SceneManager.LoadScene(1);
        
    }
    public void ContinuaModifiche()
    {
        PannelloAvvertenze.SetActive(false);
    }
    public void indietro()
    {
        PannelloAvvertenze.SetActive(true);
        
    }

    public void SalvaModifiche()
    {
        if (AcceleratoreAggiornato) { GUIManager.instance.SetAcceleratoreAttuale(acceleratoreaggiornato); }
        if (frenoAmanoAggiornato) { GUIManager.instance.SetFrenoAManoAttuale(frenoamanoaggiornato); }
        if (frenoAggiornato) { GUIManager.instance.SetFrenoAttuale(frenoaggiornato); }
        if (InverteroAggiornato) { GUIManager.instance.SetInverterAttuale(inverteraggiornato); }
        if (OpzioniAggiornato) { GUIManager.instance.SetOpzioniAttuale(opzioniaggiornato); }
        if (BarraVitaAggiornato) { GUIManager.instance.SetBarraVitaAttuale(barravitaaggiornato); }
        if (JoistickAggiornato) { GUIManager.instance.SetJoystickAttuale(joistickaggiornato); }
        if (SterzoAggiornato) { GUIManager.instance.SetVolanteAttuale(volanteaggiornato); }
        if (TachimetroAggiornato) { GUIManager.instance.SetTachimetroAttuale(tachimetroaggiornato); }
        if (FpsAggiornato) { GUIManager.instance.SetFpsAttuale(fpsaggiornato); }
        GUIManager.instance.SetScaleFrenoAggiornata(scalefrenoAggiornato);
        GUIManager.instance.SetScaleFrenoAManoAggiornata(scalefrenoamanoaggiornato);
        GUIManager.instance.SetScaleAcceleratoreAggiornata(scaleacceleratoreaggiornato);
        GUIManager.instance.SetScaleInverterAggiornata(scaleinverteraggiornato);
        GUIManager.instance.SetScaleOpzioniAggiornata(scaleopzioniaggiornato);
        GUIManager.instance.SetScaleBarraVitaAggiornata(scalebarravitaaggiornato);
        GUIManager.instance.SetScaleJoistickAggiornata(scalejoistickaggiornato);
        GUIManager.instance.SetScaleVolanteAggiornata(scalevolanteaggiornato);
        GUIManager.instance.SetScaleTachimetroAggiornata(scaletachimetroaggiornato);
        GUIManager.instance.SetScaleFpsAggiornata(scalefpsaggiornato);
        GUIManager.instance.SetModificaAttiva(false);
        SceneManager.LoadScene(3);
}
    public void VerificaSpostamenti()
    {
        VerificaFreno();
        VerificaFrenoAMano();
        VerificaInverter();
        Verificaacceleratore();
        VerificaVolante();
        VerificaJoistick();
        VerificaTachimetro();
        VerificaOpzioni();
        VerificaFps();
        VerificaBarraVita();
    }
    private void VerificaFreno()
    {
        if (Vector3.SqrMagnitude(frenoaggiornato - frenoiniziale)  != 0)
        {
            frenoAggiornato = true;
        }
        else
        {
            frenoAggiornato = false;
        }
    }
    private void VerificaFrenoAMano()
    {
        if (Vector3.SqrMagnitude(frenoamanoaggiornato-frenoamanoiniziale) != 0)
        {
            frenoAmanoAggiornato = true;
            
        }
        else
        {
            frenoAmanoAggiornato = false;
        }
    }
    private void VerificaInverter() {
        if (Vector3.SqrMagnitude(inverteraggiornato- inverteriniziale) != 0)
        {
            InverteroAggiornato = true;
        }
        else
        {
            InverteroAggiornato = false;
        }
    }
    private void Verificaacceleratore() {
        if (Vector3.SqrMagnitude(acceleratoreaggiornato- acceleratoreiniziale) != 0)
        {
            AcceleratoreAggiornato = true;
        }
        else
        {
            AcceleratoreAggiornato = false;
        }
    }
    private void VerificaVolante()
    {
        if (Vector3.SqrMagnitude(volanteaggiornato- volanteiniziale) != 0)
        {
            SterzoAggiornato = true;
        }
        else
        {
            SterzoAggiornato = false;
        }
    }
    private void VerificaJoistick()
    {
        if (Vector3.SqrMagnitude(joistickaggiornato- joistickiniziale) != 0)
        {
            JoistickAggiornato = true;
        }
        else
        {
            JoistickAggiornato = false;
        }
    }
    private void VerificaTachimetro()
    {
        if (Vector3.SqrMagnitude(tachimetroaggiornato- tachimetroiniziale) != 0)
        {
            TachimetroAggiornato = true;
        }
        else
        {
            TachimetroAggiornato = false;
        }
    }
    private void VerificaOpzioni()
    {
        if (Vector3.SqrMagnitude(opzioniaggiornato- opzioniiniziale) != 0)
        {
            OpzioniAggiornato = true;
        }
        else
        {
            OpzioniAggiornato = false;
        }
    }
    private void VerificaFps() {
        if (Vector3.SqrMagnitude(fpsaggiornato- fpsiniziale) != 0)
        {
            FpsAggiornato = true;
        }
        else
        {
            FpsAggiornato = false;
        }
    }
    private void VerificaBarraVita() {
        if (Vector3.SqrMagnitude(barravitaaggiornato- barravitainiziale) != 0)
        {
            BarraVitaAggiornato = true;
        }
        else { BarraVitaAggiornato = false; }
    }
    private void AggiornaScala()
    {
        string nome = GameManager.instance.GetTastoToccato();
        if (string.Compare(nome, freno.name) == 0)
        {
            freno.GetComponent<Image>().color = Color.grey;
            frenoamano.GetComponent<Image>().color = Color.white;
            acceleratore.GetComponent<Image>().color = Color.white;
            inverter.GetComponent<Image>().color = Color.white;
            sterzo.GetComponent<Image>().color = Color.white;
            joystick.GetComponent<Image>().color = Color.white;
            opzioni.GetComponent<Image>().color = Color.white;
            barravita.GetComponent<Image>().color = Color.white;
            fps.GetComponent<TextMeshProUGUI>().color = Color.white;
            tachimetro.GetComponent<Image>().color = Color.white;

            freno.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = true;
            frenoamano.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            acceleratore.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            inverter.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            sterzo.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            joystick.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            opzioni.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            barravita.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            fps.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            tachimetro.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            stelle.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            //print("sono figo");
        }
        if (string.Compare(nome, frenoamano.name) == 0)
        {
            freno.GetComponent<Image>().color = Color.white;
            frenoamano.GetComponent<Image>().color = Color.gray;
            acceleratore.GetComponent<Image>().color = Color.white;
            inverter.GetComponent<Image>().color = Color.white;
            sterzo.GetComponent<Image>().color = Color.white;
            joystick.GetComponent<Image>().color = Color.white;
            opzioni.GetComponent<Image>().color = Color.white;
            barravita.GetComponent<Image>().color = Color.white;
            fps.GetComponent<TextMeshProUGUI>().color = Color.white;
            tachimetro.GetComponent<Image>().color = Color.white;
            freno.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            frenoamano.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = true;
            acceleratore.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            inverter.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            sterzo.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            joystick.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            opzioni.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            barravita.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            fps.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            tachimetro.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            stelle.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
        }
        if (string.Compare(nome, acceleratore.name) == 0)
        {
            freno.GetComponent<Image>().color = Color.white;
            frenoamano.GetComponent<Image>().color = Color.white;
            acceleratore.GetComponent<Image>().color = Color.gray;
            inverter.GetComponent<Image>().color = Color.white;
            sterzo.GetComponent<Image>().color = Color.white;
            joystick.GetComponent<Image>().color = Color.white;
            opzioni.GetComponent<Image>().color = Color.white;
            barravita.GetComponent<Image>().color = Color.white;
            fps.GetComponent<TextMeshProUGUI>().color = Color.white;
            tachimetro.GetComponent<Image>().color = Color.white;
            acceleratore.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = true;
            freno.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            frenoamano.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            inverter.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            sterzo.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            joystick.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            opzioni.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            barravita.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            fps.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            tachimetro.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            stelle.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
        }
        if (string.Compare(nome, inverter.name) == 0)
        {
            freno.GetComponent<Image>().color = Color.white;
            frenoamano.GetComponent<Image>().color = Color.white;
            acceleratore.GetComponent<Image>().color = Color.white;
            inverter.GetComponent<Image>().color = Color.gray;
            sterzo.GetComponent<Image>().color = Color.white;
            joystick.GetComponent<Image>().color = Color.white;
            opzioni.GetComponent<Image>().color = Color.white;
            barravita.GetComponent<Image>().color = Color.white;
            fps.GetComponent<TextMeshProUGUI>().color = Color.white;
            tachimetro.GetComponent<Image>().color = Color.white;
            inverter.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = true;
            freno.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            frenoamano.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            acceleratore.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            sterzo.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            joystick.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            opzioni.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            barravita.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            fps.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            tachimetro.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            stelle.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
        }
        if (string.Compare(nome, sterzo.name) == 0)
        {
            freno.GetComponent<Image>().color = Color.white;
            frenoamano.GetComponent<Image>().color = Color.white;
            acceleratore.GetComponent<Image>().color = Color.white;
            inverter.GetComponent<Image>().color = Color.white;
            sterzo.GetComponent<Image>().color = Color.gray;
            joystick.GetComponent<Image>().color = Color.white;
            opzioni.GetComponent<Image>().color = Color.white;
            barravita.GetComponent<Image>().color = Color.white;
            fps.GetComponent<TextMeshProUGUI>().color = Color.white;
            tachimetro.GetComponent<Image>().color = Color.white;
            sterzo.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = true;
            freno.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            frenoamano.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            acceleratore.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            inverter.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            joystick.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            opzioni.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            barravita.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            fps.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            tachimetro.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            stelle.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
        }
        if (string.Compare(nome, joystick.name) == 0)
        {
            freno.GetComponent<Image>().color = Color.white;
            frenoamano.GetComponent<Image>().color = Color.white;
            acceleratore.GetComponent<Image>().color = Color.white;
            inverter.GetComponent<Image>().color = Color.white;
            sterzo.GetComponent<Image>().color = Color.white;
            joystick.GetComponent<Image>().color = Color.gray;
            opzioni.GetComponent<Image>().color = Color.white;
            barravita.GetComponent<Image>().color = Color.white;
            fps.GetComponent<TextMeshProUGUI>().color = Color.white;
            tachimetro.GetComponent<Image>().color = Color.white;
            joystick.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = true;
            freno.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            frenoamano.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            acceleratore.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            inverter.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            sterzo.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            opzioni.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            barravita.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            fps.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            tachimetro.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            stelle.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
        }
        if (string.Compare(nome, opzioni.name) == 0)
        {
            freno.GetComponent<Image>().color = Color.white;
            frenoamano.GetComponent<Image>().color = Color.white;
            acceleratore.GetComponent<Image>().color = Color.white;
            inverter.GetComponent<Image>().color = Color.white;
            sterzo.GetComponent<Image>().color = Color.white;
            joystick.GetComponent<Image>().color = Color.white;
            opzioni.GetComponent<Image>().color = Color.gray;
            barravita.GetComponent<Image>().color = Color.white;
            fps.GetComponent<TextMeshProUGUI>().color = Color.white;
            tachimetro.GetComponent<Image>().color = Color.white;
            opzioni.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = true;
            freno.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            frenoamano.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            acceleratore.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            inverter.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            sterzo.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            joystick.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            barravita.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            fps.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            tachimetro.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            stelle.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
        }
        if (string.Compare(nome, barravita.name) == 0)
        {
            freno.GetComponent<Image>().color = Color.white;
            frenoamano.GetComponent<Image>().color = Color.white;
            acceleratore.GetComponent<Image>().color = Color.white;
            inverter.GetComponent<Image>().color = Color.white;
            sterzo.GetComponent<Image>().color = Color.white;
            joystick.GetComponent<Image>().color = Color.white;
            opzioni.GetComponent<Image>().color = Color.white;
            barravita.GetComponent<Image>().color = Color.gray;
            fps.GetComponent<TextMeshProUGUI>().color = Color.white;
            tachimetro.GetComponent<Image>().color = Color.white;
            barravita.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = true;
            freno.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            frenoamano.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            acceleratore.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            inverter.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            sterzo.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            joystick.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            opzioni.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            fps.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            tachimetro.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            stelle.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
        }
        if (string.Compare(nome, fps.name) == 0)
        {
            freno.GetComponent<Image>().color = Color.white;
            frenoamano.GetComponent<Image>().color = Color.white;
            acceleratore.GetComponent<Image>().color = Color.white;
            inverter.GetComponent<Image>().color = Color.white;
            sterzo.GetComponent<Image>().color = Color.white;
            joystick.GetComponent<Image>().color = Color.white;
            opzioni.GetComponent<Image>().color = Color.white;
            barravita.GetComponent<Image>().color = Color.white;
            fps.GetComponent<TextMeshProUGUI>().color = Color.gray;
            tachimetro.GetComponent<Image>().color = Color.white;
            fps.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = true;
            freno.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            frenoamano.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            acceleratore.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            inverter.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            sterzo.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            joystick.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            opzioni.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            barravita.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            tachimetro.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            stelle.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
        }
        if (string.Compare(nome, tachimetro.name) == 0)
        {
            freno.GetComponent<Image>().color = Color.white;
            frenoamano.GetComponent<Image>().color = Color.white;
            acceleratore.GetComponent<Image>().color = Color.white;
            inverter.GetComponent<Image>().color = Color.white;
            sterzo.GetComponent<Image>().color = Color.white;
            joystick.GetComponent<Image>().color = Color.white;
            opzioni.GetComponent<Image>().color = Color.white;
            barravita.GetComponent<Image>().color = Color.white;
            fps.GetComponent<TextMeshProUGUI>().color = Color.white;
            tachimetro.GetComponent<Image>().color = Color.gray;
            tachimetro.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = true;
            freno.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            frenoamano.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            acceleratore.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            inverter.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            sterzo.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            joystick.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            opzioni.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            barravita.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            fps.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            stelle.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
        }
        if (string.Compare(nome, stelle.name) == 0)
        {
            stelle.GetComponent<Image>().color = Color.grey;
            freno.GetComponent<Image>().color = Color.grey;
            frenoamano.GetComponent<Image>().color = Color.white;
            acceleratore.GetComponent<Image>().color = Color.white;
            inverter.GetComponent<Image>().color = Color.white;
            sterzo.GetComponent<Image>().color = Color.white;
            joystick.GetComponent<Image>().color = Color.white;
            opzioni.GetComponent<Image>().color = Color.white;
            barravita.GetComponent<Image>().color = Color.white;
            fps.GetComponent<TextMeshProUGUI>().color = Color.white;
            tachimetro.GetComponent<Image>().color = Color.white;

            stelle.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = true;
            freno.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            frenoamano.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            acceleratore.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            inverter.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            sterzo.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            joystick.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            opzioni.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            barravita.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            fps.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
            tachimetro.transform.parent.GetComponent<Lean.Touch.LeanPinchScale>().enabled = false;
        }
    }
}
