using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GestioneStelle : MonoBehaviour
{
    [SerializeField] Image Stella1;
    [SerializeField] Image Stella2;
    [SerializeField] Image Stella3;
    private int numeroStelleAttive = 0;
    private int maxStelleAttive;
    private bool Modifica;
    Color spento;
    Color acceso;
    // Start is called before the first frame update
    void Start()
    {
        Modifica = GUIManager.instance.GetModificaAttiva();
        spento = new Color(0, 0, 0, 0.2f);
        acceso = new Color(1, 1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        numeroStelleAttive = GameManager.instance.GetStelleAttive();
        visualizzaStelle();
        
    }
    private void visualizzaStelle()
    {
        if(numeroStelleAttive == 0)
        {
            Stella1.color = spento;
            Stella2.color = spento;
            Stella3.color = spento;
        }

        if (numeroStelleAttive ==1)
        {
            Stella1.color = acceso;
        }
        if (numeroStelleAttive == 2)
        {
            Stella1.color = acceso;
            Stella2.color = acceso;
        }

        if (numeroStelleAttive == 3||Modifica)
        {
            Stella1.color = acceso;
            Stella2.color = acceso;
            Stella3.color = acceso;
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Infrazione"))
        {

            print("haicommesso un'infrazione \t ");

            Infrazione(1);


        }
    }
    public void Infrazione(int infrazione)
    {
        numeroStelleAttive += infrazione;
        GameManager.instance.SetStelleAttive(numeroStelleAttive);

        //if (numeroStelleAttive < 1)
        //{

        //    print("Hai terminato le possibilità, Riprova la prossima volta");
        //}
        //if (numeroStelleAttive > 3)
        //{
        //    numeroStelleAttive = 3;
        //}

    }
     
}
