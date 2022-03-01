using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GestoreVita : MonoBehaviour
{
    private float MaxVita;
    private float  Vita;
    //private float Vitanormalizzata;
    [SerializeField] Image BarraVita;
   
    void Start()
    {
        MaxVita = GameManager.instance.GetVitaTotaleAuto();
        Vita = MaxVita;
        GameManager.instance.SetVitaAttualeAuto(Vita);
    }

    
    void Update()
    {
        GameManager.instance.SetVitaAttualeAuto(Vita);
        BarraVita.fillAmount = Vita / MaxVita;
        
    }
    public void Damage(int damageTaken)
    {
        Vita -= damageTaken;
        GameManager.instance.SetVitaAttualeAuto(Vita);
        
        if (Vita < 1)
        {
            
            //print("La macchina è troppo danneggiata per proseguire la guida");
        }
        if (Vita > MaxVita)
        {
            Vita = MaxVita;
        }
        
    }
    

}
