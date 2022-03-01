using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestoAVideo : MonoBehaviour
{
    //private string testo;
    [SerializeField] Text textelement;
    private bool ModificaAttiva;
    [SerializeField] GameObject controller;
    // Start is called before the first frame update
    InputAcceleratore acceleratore;
    InputFreno freno;
    InputFrenoAmano frenoAMano;
    MovimentoJoystick joistick;
    private bool mostratoFrenoAmano= false;
    private bool mostratoRetromarcia=false;
    private bool mostratoJoistick = false;
    private bool JoistickAttivo;
    void Start()
    {
        ModificaAttiva = GUIManager.instance.GetModificaAttiva();
        textelement.enabled = false;
        acceleratore = controller.GetComponent<InputAcceleratore>();
        freno = controller.GetComponent<InputFreno>();
        frenoAMano = controller.GetComponent<InputFrenoAmano>();
        joistick = controller.GetComponent<MovimentoJoystick>();
        JoistickAttivo = GameManager.instance.getJoistick();
    }

    // Update is called once per frame
    void Update()
    {      if(!ModificaAttiva)
        {
            generaCommenti();
            ResettaValoreFrenoAMano();
            ResettaValoreRetromarcia();
            ResettaValoreJoystick();
        }
        else { return; }
    }
    
    private void generaCommenti()
    {
        if( frenoAMano.FrenoAManoGetter() )
        {
            
            if (!mostratoFrenoAmano)
            {
               
                mostratoFrenoAmano = true;
                MostraTesto("Freno a mano inserito");
            }
        }
         if (acceleratore.retromarciaGetter())
        {
            if (!mostratoRetromarcia)
            {
                
                MostraTesto("Retromarcia Innestata");
                mostratoRetromarcia = true;
            }
        }
        
            else if(JoistickAttivo)
        {
            if (!mostratoJoistick)
            {
                
                MostraTesto("joystick abilitato");
                mostratoJoistick = true;
            }
        }
    }

    private void MostraTesto(string testo)
    {
            textelement.enabled = true;
            textelement.text = testo;
            Invoke("DisabilitaTesto", 2.5f);       
    }
    private void DisabilitaTesto()
    {
        textelement.enabled = false;
        
    }
    private void ResettaValoreFrenoAMano()
    {
        if (!frenoAMano.FrenoAManoGetter())
        {
            mostratoFrenoAmano = false;
        }
       
        
    }
    private void ResettaValoreRetromarcia()
    {
        if (!acceleratore.retromarciaGetter())
        {
            mostratoRetromarcia = false;
        }
    }
    private void ResettaValoreJoystick()
    {
        
        if(!JoistickAttivo)
        {
            mostratoJoistick = false;
        }
    }
    //public void MostraScala(Vector3 v)
    //{
        
    //    textelement.text = v.ToString();
    //}
}
