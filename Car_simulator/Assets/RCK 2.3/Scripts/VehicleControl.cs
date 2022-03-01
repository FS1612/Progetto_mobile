using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public enum ControlMode { simple = 1, touch = 2 }


public class VehicleControl : MonoBehaviour
{


    public ControlMode controlMode = ControlMode.simple;

    public bool activeControl = false;


    // Wheels Setting /////////////////////////////////

    public CarWheels carWheels;

    [System.Serializable]
    public class CarWheels
    {
        public ConnectWheel wheels;
        public WheelSetting setting;
    }


    [System.Serializable]
    public class ConnectWheel
    {
        public bool frontWheelDrive = true;
        public Transform frontRight;
        public Transform frontLeft;

        public bool backWheelDrive = true;
        public Transform backRight;
        public Transform backLeft;
    }

    [System.Serializable]
    public class WheelSetting
    {
        public float Radius = 0.4f;
        public float Weight = 1000.0f;
        public float Distance = 0.2f;
    }


    // Lights Setting ////////////////////////////////

    public CarLights carLights;

    [System.Serializable]
    public class CarLights
    {
        public Light[] brakeLights;
        public Light[] reverseLights;
    }

    // Car sounds /////////////////////////////////

    public CarSounds carSounds;

    [System.Serializable]
    public class CarSounds
    {
        public AudioSource IdleEngine, LowEngine, HighEngine;

        public AudioSource nitro;
        public AudioSource switchGear;
    }

    // Car Particle /////////////////////////////////

    public CarParticles carParticles;

    [System.Serializable]
    public class CarParticles
    {
        public GameObject brakeParticlePerfab;
        public ParticleSystem shiftParticle1, shiftParticle2;
        private GameObject[] wheelParticle = new GameObject[4];
    }

    // Car Engine Setting /////////////////////////////////

    public CarSetting carSetting;

    [System.Serializable]
    public class CarSetting
    {

        public bool showNormalGizmos = false;
        public Transform carSteer;
        public HitGround[] hitGround;

        public List<Transform> cameraSwitchView;

        public float springs = 25000.0f;
        public float dampers = 1500.0f;

        public float carPower = 120f;
        public float shiftPower = 150f;
        public float brakePower = 8000f;

        public Vector3 shiftCentre = new Vector3(0.0f, -0.8f, 0.0f);

        public float maxSteerAngle = 25.0f;

        public float shiftDownRPM = 1500.0f;
        public float shiftUpRPM = 2500.0f;
        public float idleRPM = 500.0f;

        public float stiffness = 2.0f;

        public bool automaticGear = true;

        public float[] gears = { -10f, 9f, 6f, 4.5f, 3f, 2.5f };


        public float LimitBackwardSpeed = 60.0f;
        public float LimitForwardSpeed = 220.0f;

    }

    


    [System.Serializable]
    public class HitGround
    {
       
        public string tag = "street";
        public bool grounded = false;
        public AudioClip brakeSound;
        public AudioClip groundSound;
        public Color brakeColor;
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    private float steer = 0;
    private float accel = 0.0f;
    [HideInInspector]
    public bool brake;

    private bool shifmotor;

    [HideInInspector]
    public float curTorque = 100f;
    [HideInInspector]
    public float powerShift = 100;
    [HideInInspector]
    public bool shift;
#pragma warning restore CS0414 // El campo 'VehicleControl.torque' está asignado pero su valor nunca se usa

    [HideInInspector]
    public float speed = 0.0f;

    private float lastSpeed = -10.0f;
#pragma warning restore CS0414 // El campo 'VehicleControl.shifting' está asignado pero su valor nunca se usa


    float[] efficiencyTable = { 0.6f, 0.65f, 0.7f, 0.75f, 0.8f, 0.85f, 0.9f, 1.0f, 1.0f, 0.95f, 0.80f, 0.70f, 0.60f, 0.5f, 0.45f, 0.40f, 0.36f, 0.33f, 0.30f, 0.20f, 0.10f, 0.05f };


    float efficiencyTableStep = 250.0f;



    private float Pitch;
    private float PitchDelay;

    private float shiftTime = 0.0f;

    private float shiftDelay = 0.0f;


    [HideInInspector]
    public int currentGear = 0;
    [HideInInspector]
    public bool NeutralGear = true;

    [HideInInspector]
    public float motorRPM = 0.0f;

    [HideInInspector]
    public bool Backward = false;

    ////////////////////////////////////////////// TouchMode (Control) ////////////////////////////////////////////////////////////////////


    [HideInInspector]
    public float accelFwd = 0.0f;
    [HideInInspector]
    public float accelBack = 0.0f;
    [HideInInspector]
    public float steerAmount = 0.0f;


    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



    private float wantedRPM = 0.0f;
    private float w_rotate;
    private float slip, slip2 = 0.0f;


    private GameObject[] Particle = new GameObject[4];

    private Vector3 steerCurAngle;

    private Rigidbody myRigidbody;

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


    private WheelComponent[] wheels;



    private class WheelComponent
    {

        public Transform wheel;
        public WheelCollider collider;
        public Vector3 startPos;
        public float rotation = 0.0f;
        public float rotation2 = 0.0f;
        public float maxSteer;
        public bool drive;
        public float pos_y = 0.0f;
    }


    private WheelComponent SetWheelComponent(Transform wheel, float maxSteer, bool drive, float pos_y)
    {


        WheelComponent result = new WheelComponent();
        GameObject wheelCol = new GameObject(wheel.name + "WheelCollider");

        wheelCol.transform.parent = transform;
        wheelCol.transform.position = wheel.position;
        wheelCol.transform.eulerAngles = transform.eulerAngles;
        pos_y = wheelCol.transform.localPosition.y;

        WheelCollider col = (WheelCollider)wheelCol.AddComponent(typeof(WheelCollider));

        result.wheel = wheel;
        result.collider = wheelCol.GetComponent<WheelCollider>();
        result.drive = drive;
        result.pos_y = pos_y;
        result.maxSteer = maxSteer;
        result.startPos = wheelCol.transform.localPosition;

        return result;

    }

    public void ShiftUp()
    {
        float now = Time.timeSinceLevelLoad;

        if (now < shiftDelay) return;

        if (currentGear < carSetting.gears.Length - 1)
        {

           // if (!carSounds.switchGear.isPlaying)
                carSounds.switchGear.GetComponent<AudioSource>().Play();


                if (!carSetting.automaticGear)
            {
                if (currentGear == 0)
                {
                    if (NeutralGear){currentGear++;NeutralGear = false;}
                    else
                    { NeutralGear = true;}
                }
                else
                {
                    currentGear++;
                }
            }
            else
            {
                currentGear++;
            }


           shiftDelay = now + 1.0f;
           shiftTime = 1.5f;
        }
    }




    public void ShiftDown()
    {
        float now = Time.timeSinceLevelLoad;

       if (now < shiftDelay) return;

        if (currentGear > 0 || NeutralGear)
        {

           //w if (!carSounds.switchGear.isPlaying)
                carSounds.switchGear.GetComponent<AudioSource>().Play();

                if (!carSetting.automaticGear)
            {

                if (currentGear == 1)
                {
                    if (!NeutralGear){currentGear--;NeutralGear = true;}
                }
                else if (currentGear == 0){NeutralGear = false;}else{currentGear--;}
            }
            else
            {
                currentGear--;
            }


            shiftDelay = now + 0.1f;
            shiftTime = 2.0f;
        }
    }
}