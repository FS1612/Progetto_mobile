using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputFreno : MonoBehaviour
{
    private bool stofrenando ;
    private bool togliFreno;
    private bool frenotasto;
    private bool frenobottone;
    private bool freno;
    public void Frena()
    {

        stofrenando = true;
        togliFreno = false;
        frenobottone = true;
    }
    public void RimuoviFreno()
    {
        togliFreno = true;
        stofrenando = false;
        frenobottone = false;

    }
    void Update()//* il fixed update crea problemi al get keyDown e getKeyUp
    {
        GetInput();
        //freno = (frenobottone || frenotasto);
        GameManager.instance.SetFreno(freno);
    }
    private void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            stofrenando = true;
            togliFreno = false;
            frenotasto = true;


        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            
            togliFreno = true;
            stofrenando = false;
            frenotasto = false; 


        }
    }
    public bool StofrenandoGetter()
    {
        return stofrenando;
    }
    public bool RimuovoFrenoGetter()
    {
        return togliFreno;
    }
    
}
