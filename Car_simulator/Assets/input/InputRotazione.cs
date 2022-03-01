using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputRotazione : MonoBehaviour
{
    
    private float HorizontalInput;
    private bool AccelerometroAttivo;
    private float rotazione;
    private bool AccelerometroSupportato;
    private bool AccelerometroInUso = false;

    // Update is called once per frame


    //public void Accelerometro()
    //{
    //    if (!AccelerometroAttivo)
    //    {
    //        AccelerometroAttivo = true;
    //    }
    //    else if (AccelerometroAttivo)
    //    {
    //        AccelerometroAttivo = false;
    //    }
    //}
    //private void Start()
    //{
    //    GameManager.instance.SetAccelerometroAttivobool(true);
    //}
    void Update()
    {
        
        AccelerometroAttivo = GameManager.instance.GetAccelerometroAttivo();
        GetInput();
        VerificaAccelerometro();
    }
    private void GetInput()
    {
        
        HorizontalInput = Input.GetAxis("Horizontal");
    }
    public float HorizontalInputGetter()
    {
        return HorizontalInput;
        //print(HorizontalInput);
    }
    private void VerificaAccelerometro()
    {
        //if  (SystemInfo.supportsAccelerometer)//* bug : non rileva l'accelerometro 
        //{
        //     AccelerometroSupportato = true;
        //}
          //if (AccelerometroAttivo&& AccelerometroSupportato)
          if (AccelerometroAttivo)
          {
            
                rotazione = Input.acceleration.x;
            //print(rotazione);
            AccelerometroInUso = true;
          }
    }
    public float AccelerometroGetter()
    {
        return rotazione;
    }
    public bool AccelerometroInUsoGetter()
    {
        return AccelerometroInUso;
    }
    public bool SupportatoNonInUsoGetter()
    {
        if (AccelerometroSupportato && (!AccelerometroAttivo))
            return true;
        else return false;
    }
    public float GetRotazione()
    {
        return rotazione;
    }
}
