using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class InputTastiera : MonoBehaviour
{
    private float HorizontalInput;
    private float VerticalInput;
    [SerializeField] GameObject menu;
    InputAcceleratore acceleratore;
    ApriEChiudiMenuPausa Pausa;
    private void FixedUpdate()
    {
        LeggiComando();

    }
    private void Start()
    {
        Pausa = menu.GetComponent<ApriEChiudiMenuPausa>();
        acceleratore = menu.GetComponent<InputAcceleratore>();
    }
    private void LeggiComando()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
        VerticalInput = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.Escape))
        {
            Pausa.AttivaPausa();
        }
        //if (Input.GetKeyDown(KeyCode.K))
        //{
        //    //acceleratore.Retromarcia();
        //    GameManager.instance.SetRetromarcia(true);
        //}
        //if (Input.GetKeyDown(KeyCode.L))
        //{
        //    GameManager.instance.SetRetromarcia(false);
        //}
    }
    public float MovimentoOrizzontaleGetter()
    {
        
        return HorizontalInput;
        
    }
    public float MovimentoVerticaleGetter()
    {
        return VerticalInput;
    }
    
}
