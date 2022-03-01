using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] GameObject freno;
    [SerializeField] private WheelCollider FrontLeftWheelCollider;
    [SerializeField] private WheelCollider FrontRightWheelCollider;
    [SerializeField] private WheelCollider RearLeftWheelCollider;
    [SerializeField] private WheelCollider RearRightWheelCollider;
    [SerializeField] private float breakForce;
    private bool frenato = false;
    // Start is called before the first frame update
    //void Start()
    //{
    //    freno.SetActive(true); 
    //}

    // Update is called once per frame
    void FixedUpdate()
    {
        freno.SetActive(true);
        frena();
        if (frenato)
        {
            toglifreno();
        }
    }
    public void frena()
    {
        FrontRightWheelCollider.brakeTorque = breakForce;
        FrontLeftWheelCollider.brakeTorque = breakForce;
        RearRightWheelCollider.brakeTorque = breakForce;
        RearLeftWheelCollider.brakeTorque = breakForce;
        frenato = true;
        print("sto frenando, cazzo");
    }
    private void toglifreno()
    {
        FrontRightWheelCollider.brakeTorque = 0;
        FrontLeftWheelCollider.brakeTorque = 0;
        RearRightWheelCollider.brakeTorque = 0;
        RearLeftWheelCollider.brakeTorque = 0;
        frenato= false;
    }
}
