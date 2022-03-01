using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestioneMovimentoAuto : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float currentsteerAngle;
    private float currentbreakForce;
    private float currentMotorForce;
    private bool braked;// variabile bool di supporto che serve a limitare l'uso di remove breaking, di fatti se non ho mai premuto il freno non ha senso rimuovere la frenata
    //public float consta;
    private Vector3 movement;
    private bool ModificaAttiva;
    private bool VolanteAttivo;
    
    TestoAVideo testo;
    InputRotazione rotazione;
    InputFrenoAmano FrenoAMano;
    InputFreno freno;
    InputAcceleratore acceleratore;
    MovimentoJoystick joystick;
    SterzoASchermo sterzo;
    
    [SerializeField] private Rigidbody auto;
    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteeringAngle;
    [SerializeField] private GameObject controller;
    //[SerializeField] private GameObject MenuPausa;
    [SerializeField] private WheelCollider FrontLeftWheelCollider;
    [SerializeField] private WheelCollider FrontRightWheelCollider;
    [SerializeField] private WheelCollider RearLeftWheelCollider;
    [SerializeField] private WheelCollider RearRightWheelCollider;
    //[SerializeField] private GameObject Menupausa;a
    [SerializeField] private Transform FrontLeftWheelTransform;
    [SerializeField] private Transform FrontRightWheelTransform;
    [SerializeField] private Transform RearLeftWheelTransform;
    [SerializeField] private Transform RearRightWheelTransform;
    private bool JoistickAttivo;
    private bool primoavvio;
    private Vector3 primaposizione;
    private Vector3 posizioneaggiornata;
    private float velocitainiziale;
    private float velocitaAggiornata;
    public float velocitacollider;
    private Vector3 pos;
    public bool avviato =false;
    public bool FrenoAManoAttivo;
    public float velocita;
    public float velocitarb;
    [SerializeField] private float velocitamax;
    public float dragattuale;
    private Vector3 temp2;
    //private bool IsPaused;
    public int RuoteATerra;
    [SerializeField] List<WheelCollider> ListaRuote;
    //private void Awake()
    //{
    //    primoavvio = GameManager.instance.GetPrimoAvvio();
    //}
    private void Start()
    {
        ModificaAttiva = GUIManager.instance.GetModificaAttiva();
        //QualitySettings.vSyncCount = 0;
        //GameManager.instance.SetAvviato(false);
        ////IsPaused = GameManager.instance.getIsPaused();
        primoavvio = GameManager.instance.GetPrimoAvvio();
        
        JoistickAttivo = GameManager.instance.getJoistick();
        //velocitainiziale = GameManager.instance.GetVelocitaIniziale();
        //velocitaAggiornata = GameManager.instance.GetVelocitaAttuale();
        posizioneaggiornata = GameManager.instance.GetPosizioneAttuale();
        //Menupausa.SetActive(false);

        ListaRuote.Add(FrontLeftWheelCollider);
        ListaRuote.Add(FrontRightWheelCollider);
        ListaRuote.Add(RearLeftWheelCollider);
        ListaRuote.Add(RearRightWheelCollider);
        

    }
    private void FixedUpdate()
    {
        //if (GameManager.instance.GetVsyncAttivo()) { QualitySettings.vSyncCount = 1; }
        //if(!GameManager.instance.GetVsyncAttivo()){ QualitySettings.vSyncCount = 0; }
        //QualitySettings.antiAliasing = GameManager.instance.GetAntiAliasing();
        horizontalInput = GameManager.instance.GetRotazione();
        verticalInput = GameManager.instance.GetAcceleratore();
        VolanteAttivo = GameManager.instance.GetSterzoAttivo();
        if (!ModificaAttiva)
        {
            
            movement = new Vector3(Input.acceleration.x, Input.acceleration.y, Input.acceleration.z);
            inizializzazione();
            //GameManager.instance.SetAvviato(true);

            GetInput(); //prende input dalla tastiera 
            HandleMotor();
            //GestioneVelocita();

            HandleSteering();
            UpdateWheels();
            //ControlloAntiRibaltamento();
        }
    }
    private void inizializzazione()
    {
        FrenoAManoAttivo = GameManager.instance.GetFrenoAmano();
        if (!avviato)
        {
            if (primoavvio) { initPrimoAvvio(); }
            else if (!primoavvio) { riprendi(); }
        }
        
    }
    private void initPrimoAvvio()
    {
        primaposizione = GameManager.instance.GetPosizioneIniziale();
        //* siccome lo script è gia attaccato alla macchina basta scrivere trasform per ottenere il suo trasform
            transform.localPosition = primaposizione;
        //velocita = GameManager.instance.GetVelocitaIniziale();
        avviato=true;
        GameManager.instance.SetAvviato(true);

    }
    private void riprendi()
    {
        posizioneaggiornata = GameManager.instance.GetPosizioneAttuale();
        transform.localPosition = posizioneaggiornata;
        avviato = true;
        
        velocita = GameManager.instance.GetVelocitaAttuale();
        currentsteerAngle = GameManager.instance.GetRotazione();
        verticalInput = GameManager.instance.GetAcceleratore();
        velocitacollider = velocita;
        GameManager.instance.SetAvviato(true);
    }
    private void GetInput()
    {
        //* devo per forza richiamarli altrimenti non funziona nulla 
        sterzo = controller.GetComponent<SterzoASchermo>();
        acceleratore = controller.GetComponent<InputAcceleratore>();
        FrenoAMano = controller.GetComponent<InputFrenoAmano>();
        rotazione = controller.GetComponent<InputRotazione>();
        joystick = controller.GetComponent<MovimentoJoystick>();
        freno = controller.GetComponent<InputFreno>();
        velocitacollider = 2 * (22 / 7) * FrontLeftWheelCollider.radius * FrontLeftWheelCollider.rpm * 60 / 100000;
        velocitacollider = Mathf.Round(velocitacollider);
        velocitarb= auto.velocity.magnitude * 3.6f;
        velocitarb = Mathf.Round(velocitarb);
        if (velocitacollider < 0) { velocitacollider = -velocitacollider; }
        if (velocitarb == 0) { auto.drag = 0; }
        dragattuale = auto.drag;
        //auto.drag = auto.velocity.magnitude / 80;
        if (auto.velocity.magnitude*3.6 >= 88) { auto.drag = dragattuale; }
         else { auto.drag = dragattuale + auto.velocity.magnitude / 130000; }
        //if (GameManager.instance.GetRetromarcia() && velocitarb * 3.6 > 50) { auto.drag = dragattuale = auto.drag+ auto.velocity.magnitude / 500; }
        //else { auto.drag = dragattuale; }
        //auto.drag = dragattuale + auto.velocity.magnitude / 130000;
        //if((verticalInput>0||verticalInput<0)&&velocitacollider > 0&& velocitacollider<64 ) { auto.drag = auto.velocity.magnitude / (1000f * (velocitacollider-velocitarb)*100000f); }
        //if((verticalInput > 0 || verticalInput < 0) && velocitacollider >=64 && velocitacollider<=85) { auto.drag = auto.velocity.magnitude / (195.9f * (velocitacollider/velocitarb)); }
        //if(((verticalInput > 0 || verticalInput < 0) && GameManager.instance.GetRetromarcia())) { auto.drag = auto.velocity.magnitude*2.5f / (195.9f * (velocitacollider / velocitarb)); }

        //print("velocita rigidbody" + "=" + velocitarb + "velocitaRuote" + "=" + velocitacollider + "differenza" + (velocitarb - velocitacollider));
        
        GameManager.instance.SetVelocitaAttuale(velocitarb);
        
        if (velocitacollider > velocitamax && GameManager.instance.GetRetromarcia()) { currentMotorForce = 0 * motorForce;
        if(velocitarb  > 50) { auto.drag = 0.2f; }
                }
        else {currentMotorForce = verticalInput * motorForce;}
        if (!ControlloAntiRibaltamento()) { currentMotorForce = 0 * motorForce; }
        else { currentMotorForce = verticalInput * motorForce; }
    }
    private void HandleMotor()
    {
        
        posizioneaggiornata = transform.position;
        GameManager.instance.SetPosizioneAttuale(posizioneaggiornata);
        
        if (!FrenoAManoAttivo)
        {
            
                FrontLeftWheelCollider.motorTorque = currentMotorForce * Time.deltaTime;
                FrontRightWheelCollider.motorTorque = currentMotorForce * Time.deltaTime;
           
        }
        if (freno.StofrenandoGetter())
        {
            currentbreakForce = breakForce;
            ApplyBreaking();
            braked = true;   
        }
        else if (!freno.StofrenandoGetter() && braked)
        {
            RemoveBraking();   
            braked = false;
        }
        else if (acceleratore.StatoAcceleratoreGetter())
        {
            //if (FrenoAMano.FrenoAManoGetter())
            if(FrenoAManoAttivo)
            {   
                //currentbreakForce = FrenoAMano.FrenoAManoGetter() ? breakForce : 0f;
                currentbreakForce = FrenoAManoAttivo ? breakForce : 0f;
                ApplyBreaking();
            } 
        }
        //else if (!FrenoAMano.FrenoAManoGetter())
        else if(!FrenoAManoAttivo)
        {
            currentbreakForce = 0;
            RemoveBraking();
        }   
    } 
    //private void GestioneVelocita()
    //{// provo a ricalcolare la velocita usando i collider 


    //        //Vector3 temp ;
    //    //    //Vector3  temp2;
    //    //    temp= GameManager.instance.GetVettoreVelocita();
    //    //    float tempx;
    //    //   float tempy;
    //    //    float tempz;
    //    //    tempx = temp.x;
    //    //    tempy = temp.y;
    //    //    tempz = temp.z;
    //    //    if (tempx> 4.148562f)
    //    //   {

    //    //       tempx = 4.148562f;
    //    //        temp2[0] = tempx;
    //    //        temp2[1] = tempy;
    //    //        temp2[2] = tempz;
    //    //    }
    //    //    auto.velocity.Set=
    //    //    auto.velocity = temp2;
    //    //    print(temp2);
    //    //if (auto.velocity.magnitude *3.6 > velocitamax)
    //    //{
    //    //   temp = Vector3.ClampMagnitude(auto.velocity, 50);
    //    //    //auto.velocity = Vector3.ClampMagnitude(auto.velocity, 50);
    //    //    auto.velocity.Set ;
    //    //    print(auto.velocity);
    //    //}
    //}
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
    private void HandleSteering()
    {

        //if (VolanteAttivo)
        //{
        //    currentsteerAngle = sterzo.GetClampedValue()* maxSteeringAngle;
        //}
        //else if(JoistickAttivo)

        //{
        //    currentsteerAngle = maxSteeringAngle * joystick.HorizontalJoystickGetter();           
        //}
        //else if (rotazione.SupportatoNonInUsoGetter())
        //{
        //    //testo.TestoSetter("il tuo dispositivo supporta l'accelerometro, attivalo nel menù");
        //    print("il tuo dispositivo supporta l'accelerometro, attivalo nel menù");
        //}
        //else if (!rotazione.AccelerometroInUsoGetter())
        //{
        //    currentsteerAngle = maxSteeringAngle * rotazione.HorizontalInputGetter();
        //}
        //else if (rotazione.AccelerometroInUsoGetter())
        //{ 
        //    currentsteerAngle = maxSteeringAngle * rotazione.AccelerometroGetter();  
        //}
        //currentsteerAngle = maxSteeringAngle * GameManager.instance.GetRotazione(); 
        currentsteerAngle = maxSteeringAngle * horizontalInput;
        FrontLeftWheelCollider.steerAngle = currentsteerAngle;
        FrontRightWheelCollider.steerAngle = currentsteerAngle;
    }
    public void UpdateWheels()
    {
        UpdateSingleWheels(FrontLeftWheelCollider, FrontLeftWheelTransform);
        UpdateSingleWheels(FrontRightWheelCollider, FrontRightWheelTransform);
        UpdateSingleWheels(RearLeftWheelCollider, RearLeftWheelTransform);
        UpdateSingleWheels(RearRightWheelCollider, RearRightWheelTransform);
    }

    private void UpdateSingleWheels(WheelCollider wheelcollider, Transform wheeltransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelcollider.GetWorldPose(out pos, out rot);
        wheeltransform.rotation = rot;
        wheeltransform.position = pos;
    }
    public bool GetAvviato() { return avviato;
        
    }
    private bool ControlloAntiRibaltamento()
    {
        RuoteATerra = 0;
        foreach(WheelCollider ruota in ListaRuote)
        {
            if (ruota.isGrounded)
            {
                RuoteATerra++;
            }
        }
        return (RuoteATerra == 4);
    }
}
