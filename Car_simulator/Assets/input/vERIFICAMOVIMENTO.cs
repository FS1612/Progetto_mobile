using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vERIFICAMOVIMENTO : MonoBehaviour
{
    [SerializeField] Transform ruota;
    [SerializeField] GameObject auto;
    [SerializeField] Transform autotransform;
    private bool mosso ;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
         checker();
    }
    private void checker()
    {
        //if(autotransform.hasChanged)
        if ((auto.GetComponent<Rigidbody>().velocity.magnitude > 0.01f))
        {
            mosso = true;
        }
        if (auto.GetComponent<Rigidbody>().velocity.magnitude < 0.01)
        {
            mosso = false;
        }
    }
    public bool MovimentoGetter()
    {    
        return mosso;
    }
    
}
