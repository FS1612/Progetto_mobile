using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Movimentoauto : MonoBehaviour
{
    public Joystick joystick;
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";
    
    private float horizontalInput;
   

    private float verticalInput;
    private float currentsteerAngle;
    private float currentbreakForce;
    private float currentMotorForce;
    private float sterzata;
    private bool braked;// variabile bool di supporto che serve a limitare l'uso di remove breaking, di fatti se non ho mai premuto il freno non ha senso rimuovere la frenata
    private bool permanentlybraked = true;

    private bool accelerom = false;
    private Vector3 movement;
    
    InputFreno freno;
    InputTastiera tastiera;
    SterzoASchermo sterzo;
    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteeringAngle;
    [SerializeField] private GameObject controller;
    [SerializeField] private GameObject stocazzo;
     
    [SerializeField] private WheelCollider FrontLeftWheelCollider;
    [SerializeField] private WheelCollider FrontRightWheelCollider;
    [SerializeField] private WheelCollider RearLeftWheelCollider;
    [SerializeField] private WheelCollider RearRightWheelCollider;

    [SerializeField] private Transform FrontLeftWheelTransform;
    [SerializeField] private Transform FrontRightWheelTransform;
    [SerializeField] private Transform RearLeftWheelTransform;
    [SerializeField] private Transform RearRightWheelTransform;
    public bool SterzoAttivato;
    
    private void FixedUpdate()

    {
        
        movement = new Vector3(Input.acceleration.x, Input.acceleration.y, Input.acceleration.z);
        GetInput(); //prende input dalla tastiera 
        HandleMotor();
        HandleSteering();
        UpdateWheels();
        //print(sterzoattivo);
    }
  

    private void GetInput()
    {
        tastiera = controller.GetComponent<InputTastiera>();
        accelerom = GameManager.instance.GetAccelerometroAttivo();
        horizontalInput = tastiera.MovimentoOrizzontaleGetter();
        SterzoAttivato = GameManager.instance.GetSterzoAttivo();
        verticalInput = tastiera.MovimentoVerticaleGetter();
        currentMotorForce = verticalInput * motorForce;
        freno = controller.GetComponent<InputFreno>();
        sterzo = controller.GetComponent<SterzoASchermo>();
        
       
    }
    private void HandleMotor()
    {

        verificaFrenostazionamento();
        if (!permanentlybraked)
        {

            FrontLeftWheelCollider.motorTorque = currentMotorForce * Time.deltaTime;
            FrontRightWheelCollider.motorTorque = currentMotorForce * Time.deltaTime;


        }

        if (freno.StofrenandoGetter())
        {
            currentbreakForce = freno.StofrenandoGetter() ? breakForce : 0f;
            ApplyBreaking();
            braked = true;

        }

        else if (freno.RimuovoFrenoGetter())
        {
            RemoveBraking();
            print("freno rimosso");
            braked = false;

        }

    }

    private void verificaFrenostazionamento()
    {
        if (permanentlybraked)
        {
            if ((verticalInput != 0) || (horizontalInput != 0))
            {
                print("il freno a mano è inserito, se vuoi muoverti devi prima rimuoverlo");
                print("z rimuove il freno a mano");

            }
        }
        if (Input.GetKey(KeyCode.Z))
        {

            permanentlybraked = false;
            print("ora puoi andare");
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            permanentlybraked = true;

            print("freno a mano inserito");

        }
        AttivazioneFrenoStazionamento();
        //ApplicazioneAttrito();
    }

    private void AttivazioneFrenoStazionamento()// agisce solo sulle ruote posteriori
    {
        if (permanentlybraked)
        {
            currentbreakForce = permanentlybraked ? breakForce : 0f;
            ApplyBreaking();
        }
        else if (!permanentlybraked)
        {
            RemoveBraking();


        }
    }
    private void ApplyBreaking()
    {


        FrontRightWheelCollider.brakeTorque = currentbreakForce * Time.deltaTime;
        FrontLeftWheelCollider.brakeTorque = currentbreakForce * Time.deltaTime;
        RearRightWheelCollider.brakeTorque = currentbreakForce * Time.deltaTime;
        RearLeftWheelCollider.brakeTorque = currentbreakForce * Time.deltaTime;


    }
    private void RemoveBraking()
    {
        FrontRightWheelCollider.brakeTorque = 0;
        FrontLeftWheelCollider.brakeTorque = 0;
        RearRightWheelCollider.brakeTorque = 0;
        RearLeftWheelCollider.brakeTorque = 0;

    }

    
    public void Accelerometro()
    {
        if (!accelerom)
        {
            accelerom = true;
        }
        else if (accelerom)
        {
            accelerom = false;
        }
    }


    private void HandleSteering()
    {
        float rot;
        
        if (!accelerom)
        {

            currentsteerAngle = maxSteeringAngle * horizontalInput;
        }
        else if (accelerom)
        {

            rot = movement[0];

            currentsteerAngle = maxSteeringAngle * rot;
            print(rot);
        }
         if (!GameManager.instance.GetSterzoAttivo())
         {
            currentsteerAngle = maxSteeringAngle * horizontalInput;
         }

        else if (GameManager.instance.GetSterzoAttivo())
        {
            print("sterzo attivo");
            sterzata = sterzo.GetClampedValue();
            currentsteerAngle = maxSteeringAngle * sterzata;
        }

     
        FrontLeftWheelCollider.steerAngle = currentsteerAngle;
        FrontRightWheelCollider.steerAngle = currentsteerAngle;

    }
   public  void UpdateWheels()
    {
        UpdateSingleWheels(FrontLeftWheelCollider,FrontLeftWheelTransform);
        UpdateSingleWheels(FrontRightWheelCollider,FrontRightWheelTransform);
        UpdateSingleWheels(RearLeftWheelCollider,RearLeftWheelTransform);
        UpdateSingleWheels(RearRightWheelCollider,RearRightWheelTransform);
    }

    private void UpdateSingleWheels(WheelCollider wheelcollider,Transform wheeltransform)
    {
        Vector3 pos;
        Quaternion rot;
        
        wheelcollider.GetWorldPose(out pos, out rot);
        
        wheeltransform.rotation = rot;
        wheeltransform.position = pos;
        
    }
}
