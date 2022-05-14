using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MovimentoBottoni : MonoBehaviour
{
    private bool primoavvio;
    private bool ModificaAttiva;
    private bool Modificato;
    //private Vector3 frenoiniziale;
    //private Vector3 frenoamanoiniziale;
    //private Vector3 acceleratoreiniziale;
    //private Vector3 inverteriniziale;
    //private Vector3 joistickiniziale;
    //private Vector3 volanteiniziale;
    //private Vector3 opzioniiniziale;
    //private Vector3 barravitainiziale;
    //private Vector3 tachimetroiniziale;
    //private Vector3 fpsiniziale;
    [SerializeField] private GameObject freno;
    [SerializeField] private GameObject frenoamano;
    [SerializeField] private GameObject acceleratore;
    [SerializeField] private GameObject inverter;
    [SerializeField] private GameObject joistick ;
    [SerializeField] private GameObject volante ;
    [SerializeField] private GameObject opzioni;
    [SerializeField] private GameObject barravita;
    [SerializeField] private GameObject tachimetro;
    [SerializeField] private GameObject fps;
    
    // Start is called before the first frame update
    void Start()
    {
        ModificaAttiva = GUIManager.instance.GetModificaAttiva();
        primoavvio = GameManager.instance.GetPrimoAvvio();
        Modificato = GUIManager.instance.GetModificato();
        if (!ModificaAttiva)
        {
            if (!primoavvio&&Modificato)
            {
                freno.transform.parent.localScale = GUIManager.instance.GetScaleFrenoAggiornata();
                frenoamano.transform.parent.localScale = GUIManager.instance.GetScaleFrenoAManoAggiornata();
                acceleratore.transform.parent.localScale = GUIManager.instance.GetScaleAcceleratoreAggiornata();
                inverter.transform.parent.localScale = GUIManager.instance.GetScaleInverterAggiornata();
                volante.transform.parent.localScale = GUIManager.instance.GetScaleVolanteAggiornata();
                joistick.transform.parent.localScale = GUIManager.instance.GetScaleJoistickAggiornata();
                opzioni.transform.parent.localScale = GUIManager.instance.GetScaleOpzioniAggiornata();
                barravita.transform.parent.localScale = GUIManager.instance.GetScaleBarraVitaAggiornata();
                fps.transform.parent.localScale = GUIManager.instance.GetScaleFpsAggiornata();
                tachimetro.transform.parent.localScale = GUIManager.instance.GetScaleTachimetroAggiornata();
                //freno.transform.localPosition = GUIManager.instance.GetFrenoAttuale();
                ////frenoamano.transform.localPosition = GUIManager.instance.GetFrenoAManoAttuale();
                ////acceleratore.transform.localPosition = GUIManager.instance.GetAcceleratoreAttuale();
                ////inverter.transform.localPosition = GUIManager.instance.GetInverterAttuale();
                ////volante.transform.localPosition = GUIManager.instance.GetVolanteAttuale();
                ////joistick.transform.localPosition = GUIManager.instance.GetJoistyckAttuale();
                ////opzioni.transform.localPosition = GUIManager.instance.GetOpzioniAttuale();
                ////fps.transform.localPosition = GUIManager.instance.GetFpsAttuale();
                ////tachimetro.transform.localPosition = GUIManager.instance.GetTachimetroAttuale();
                ////barravita.transform.localPosition = GUIManager.instance.GetBarraVitaAttuale();
                //FrenoTransform = freno.GetComponent<RectTransform>();
                ////FrenoTransform.offsetMax = new Vector2(150, 150);
                //FrenoTransform.localScale = new Vector3(2,2,2);
                //FrenoTransform.ForceUpdateRectTransforms();

                //freno.transform.parent.position = (GUIManager.instance.GetFrenoAttuale());
                //frenoamano.transform.parent.position = (GUIManager.instance.GetFrenoAttuale());
                //freno.transform.localPosition= (GUIManager.instance.GetFrenoDefault());
                //freno.transform.localPosition = GUIManager.instance.GetFrenoAttuale();

                //frenoamano.transform.localPosition = GUIManager.instance.GetFrenoAManoAttuale();
                //acceleratore.transform.localPosition = GUIManager.instance.GetAcceleratoreAttuale();
                //inverter.transform.localPosition = GUIManager.instance.GetInverterAttuale();
                //volante.transform.localPosition = GUIManager.instance.GetVolanteAttuale();
                //joistick.transform.localPosition = GUIManager.instance.GetJoistyckAttuale();
                //opzioni.transform.localPosition = GUIManager.instance.GetOpzioniAttuale();
                //fps.transform.localPosition = GUIManager.instance.GetFpsAttuale();
                //tachimetro.transform.localPosition = GUIManager.instance.GetTachimetroAttuale();
                //barravita.transform.localPosition = GUIManager.instance.GetBarraVitaAttuale();
                //FrenoTransform = freno.GetComponent<RectTransform>();
                //FrenoTransform.offsetMax = new Vector2(150, 150);
                //FrenoTransform.ForceUpdateRectTransforms();

                freno.transform.parent.localPosition = GUIManager.instance.GetFrenoAttuale();
                //freno.transform.position = GUIManager.instance.GetFrenoAttuale();
                
                frenoamano.transform.parent.localPosition = GUIManager.instance.GetFrenoAManoAttuale();
                //frenoamano.transform.position = GUIManager.instance.GetFrenoAManoAttuale();
                
                acceleratore.transform.parent.localPosition = GUIManager.instance.GetAcceleratoreAttuale();
                //acceleratore.transform.position = GUIManager.instance.GetAcceleratoreAttuale();
                
                inverter.transform.parent.localPosition = GUIManager.instance.GetInverterAttuale();
                //inverter.transform.position = GUIManager.instance.GetInverterAttuale();

                volante.transform.parent.localPosition = GUIManager.instance.GetVolanteAttuale();
                //volante.transform.position = GUIManager.instance.GetVolanteAttuale();

                joistick.transform.parent.localPosition = GUIManager.instance.GetJoistyckAttuale();
                //joistick.transform.position = GUIManager.instance.GetJoistyckAttuale();
                
                opzioni.transform.parent.localPosition = GUIManager.instance.GetOpzioniAttuale();
                //opzioni.transform.position = GUIManager.instance.GetOpzioniAttuale();
                
                fps.transform.parent.localPosition = GUIManager.instance.GetFpsAttuale();
                //fps.transform.position = GUIManager.instance.GetFpsAttuale();

                tachimetro.transform.parent.localPosition = GUIManager.instance.GetTachimetroAttuale();
                //tachimetro.transform.position = GUIManager.instance.GetTachimetroAttuale();

                barravita.transform.parent.localPosition = GUIManager.instance.GetBarraVitaAttuale();
                //barravita.transform.position = GUIManager.instance.GetBarraVitaAttuale();
                //FrenoTransform = freno.GetComponent<RectTransform>();
                //FrenoTransform.offsetMax = new Vector2(150, 150);
                //FrenoTransform.ForceUpdateRectTransforms();


            }
            else if(primoavvio)
            {

                //freno.transform.localScale += GUIManager.instance.GetScaleFrenoDefault();
                //frenoamano.transform.localScale += GUIManager.instance.GetScaleFrenoAManoDefault();
                //acceleratore.transform.localScale += GUIManager.instance.GetScaleAcceleratoreDefault();
                //inverter.transform.localScale += GUIManager.instance.GetScaleInverterDefault();
                //volante.transform.localScale += GUIManager.instance.GetScaleVolanteDefault();
                //joistick.transform.localScale += GUIManager.instance.GetScaleJoistickDefault();
                //opzioni.transform.localScale += GUIManager.instance.GetScaleOpzioniDefault();
                //barravita.transform.localScale += GUIManager.instance.GetScaleBarraVitaDefault();
                //fps.transform.localScale += GUIManager.instance.GetScaleFpsDefault();
                //tachimetro.transform.localScale += GUIManager.instance.GetScaleTachimetroDefault();
               

                //frenoamano.transform.localPosition=(  GUIManager.instance.GetFrenoAManoDefault());
                ////acceleratoreiniziale = new Vector3(-493.7248f, -164.2357f, 56f);
                //acceleratore.transform.localPosition = GUIManager.instance.GetAcceleratoreDefault();
                ////inverteriniziale = new Vector3(-489.19f, -63.33193f, 98.50002f) ;
                //inverter.transform.localPosition = GUIManager.instance.GetInverterDefault();
                ////joistickiniziale = new Vector3(-546f, -187f, 0f);
                //joistick.transform.position = GUIManager.instance.GetJoistyckDefault();
                ////volanteiniziale = new Vector3(489f, -136.7512f, 0f);
                //volante.transform.localPosition = GUIManager.instance.GetVolanteDefault();
                ////opzioniiniziale = new Vector3(461.2f, 236f, 0f);
                //opzioni.transform.localPosition = GUIManager.instance.GetOpzioniDefault();
                ////barravitainiziale = new Vector3(-514.6425f, 245.1577f, 0f);
                //barravita.transform.localPosition = GUIManager.instance.GetBarraVitaDefault();
                ////tachimetroiniziale = new Vector3(-229.47f, -179.47f, 0f);
                //tachimetro.transform.localPosition = GUIManager.instance.GetTachimetroDefault();
                ////fpsiniziale = new Vector3(502f, 329.8f, 0f);
                //fps.transform.localPosition = GUIManager.instance.GetFpsDefault();
                GUIManager.instance.SetFrenoAManoDefault(frenoamano.transform.parent.localPosition);
                GUIManager.instance.SetFrenoDefault(freno.transform.parent.localPosition);
                GUIManager.instance.SetAcceleratoreDefault(acceleratore.transform.parent.localPosition);
                GUIManager.instance.SetJoistyckDefault(joistick.transform.parent.position);
                GUIManager.instance.SetVolanteDefault(volante.transform.parent.localPosition);
                GUIManager.instance.SetOpzioniDefault(opzioni.transform.parent.localPosition);
                GUIManager.instance.SetBarraVitaDefault(barravita.transform.parent.localPosition);
                GUIManager.instance.SetTachimetroDefault(tachimetro.transform.parent.localPosition);
                GUIManager.instance.SetFpsDefault(fps.transform.parent.localPosition);
                GUIManager.instance.SetInverterDefault(inverter.transform.parent.localPosition);

 
            }
            else if (!Modificato&&!primoavvio)
            {
                frenoamano.transform.parent.localPosition = (GUIManager.instance.GetFrenoAManoDefault());
                acceleratore.transform.parent.localPosition = GUIManager.instance.GetAcceleratoreDefault();
                inverter.transform.parent.localPosition = GUIManager.instance.GetInverterDefault();
                joistick.transform.parent.localPosition = GUIManager.instance.GetJoistyckDefault();
                volante.transform.parent.localPosition = GUIManager.instance.GetVolanteDefault();
                opzioni.transform.parent.localPosition = GUIManager.instance.GetOpzioniDefault();
                barravita.transform.parent.localPosition = GUIManager.instance.GetBarraVitaDefault();
                tachimetro.transform.parent.localPosition = GUIManager.instance.GetTachimetroDefault();
                fps.transform.parent.localPosition = GUIManager.instance.GetFpsDefault();
                freno.transform.parent.localScale = GUIManager.instance.GetScaleFrenoDefault();
                frenoamano.transform.parent.localScale = GUIManager.instance.GetScaleFrenoAManoDefault();
                acceleratore.transform.parent.localScale = GUIManager.instance.GetScaleAcceleratoreDefault();
                inverter.transform.parent.localScale = GUIManager.instance.GetScaleInverterDefault();
                volante.transform.parent.localScale = GUIManager.instance.GetScaleVolanteDefault();
                joistick.transform.parent.localScale = GUIManager.instance.GetScaleJoistickDefault();
                opzioni.transform.parent.localScale = GUIManager.instance.GetScaleOpzioniDefault();
                barravita.transform.parent.localScale = GUIManager.instance.GetScaleBarraVitaDefault();
                fps.transform.parent.localScale = GUIManager.instance.GetScaleFpsDefault();
                tachimetro.transform.parent.localScale = GUIManager.instance.GetScaleTachimetroDefault();
            }
        }
        else return;
    }

    // Update is called once per frame
    void Update()
    { 
    }
}
