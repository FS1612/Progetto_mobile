using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDamage : MonoBehaviour
{
   
    [SerializeField] GameObject target;

    private int danno=10;
    // Start is called before the first frame update
    private void Start()
    {
         
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        OnPicked(other);
    //    }
    //}
    //protected virtual void OnPicked(Collider other)
    //{
    //    Debug.Log("oggetto toccato");
    //    print("hai preso un oggetto, danneggiando la macchina"+":"+gameObject.name);
    //    GestoreVita vita = other.GetComponent<GestoreVita>();
    //    if (!vita)
    //    {
    //        return;
    //    }
    //    else
    //        vita.Damage(danno);
    //}
    private void OnCollisionEnter(Collision collision)
    {
      
        if (collision.gameObject.CompareTag("Auto"))
        {
            if (collision.relativeVelocity.magnitude > 0f)
            {
                print("mi hai preso ");
                GestoreVita vita = collision.gameObject.GetComponent<GestoreVita>();
                vita.Damage(danno);
            }
        }
        
    }
}
