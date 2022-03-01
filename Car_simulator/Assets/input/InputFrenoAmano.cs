using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputFrenoAmano : MonoBehaviour
{
    private bool FrenoAManoAttivo = true ;
    private bool frenobottone;
    private bool frenotasto;
    
    public void FrenoAMano()
    {
        if (FrenoAManoAttivo)
        {
            GameManager.instance.SetFrenoAMano(false);
            //FrenoAManoAttivo = false;
            frenobottone = false;
        }
        else if (!FrenoAManoAttivo)
        {
            GameManager.instance.SetFrenoAMano(true);
            //FrenoAManoAttivo = true;
            frenobottone = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        GetInput();
         
            //if(!frenobottone || !frenobottone) { FrenoAManoAttivo = true; }
            //if(frenobottone || frenobottone){ FrenoAManoAttivo = false; }
        
        //print(frenobottone);
        //print(frenobottone);
        //GameManager.instance.SetFrenoAMano(FrenoAManoAttivo);
    }
    private void GetInput()
    {
        FrenoAManoAttivo = GameManager.instance.GetFrenoAmano();
        if (Input.GetKey(KeyCode.Z))
        {
            GameManager.instance.SetFrenoAMano(false);
            //FrenoAManoAttivo = false;
            frenotasto = false;
        }
        else if (Input.GetKey(KeyCode.X))
        {
            GameManager.instance.SetFrenoAMano(true);
            //FrenoAManoAttivo = true;
            frenotasto = true;
        }
    }
    public bool FrenoAManoGetter()
    {
        return FrenoAManoAttivo;
    }
}
