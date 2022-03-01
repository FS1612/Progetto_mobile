using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModificaJoystick : MonoBehaviour
{
    RayCast ray;
    string oggetto1Colore;
    string oggetto2Colore;
    string oggetto2Sprite;
    string oggetto1Sprite;
    bool modificajoistick ;
    [SerializeField] GameObject joystick;
    [SerializeField] GameObject Handle;
    [SerializeField] GameObject Canvas;

    //[SerializeField] Sprite Sprite1Corona;
    //[SerializeField] Sprite Sprite2Corona;
    //[SerializeField] Sprite Sprite3Corona;
    //[SerializeField] Sprite Sprite4Corona;
    //[SerializeField] Sprite Sprite5Corona;
    //[SerializeField] Sprite Sprite6Corona;
    //[SerializeField] Sprite Sprite1Handle;
    //[SerializeField] Sprite Sprite2Handle;
    //[SerializeField] Sprite Sprite3Handle;
    //[SerializeField] Sprite Sprite4Handle;
    //[SerializeField] Sprite Sprite5Handle;
    //[SerializeField] Sprite Sprite6Handle;


    // Start is called before the first frame update
    void Start()
    {
        modificajoistick = GUIManager.instance.GetJoistickModificato();
        Color Coronadefault = GUIManager.instance.GetColoreCoronaDefault();
        Color Handledefault = GUIManager.instance.GetColoreCoronaDefault();
        Sprite HandledefaultSprite = GUIManager.instance.GetSpriteCoronaDefault();
        Sprite CoronadefaultSprite = GUIManager.instance.GetSpriteCoronaDefault();
        //joystick.GetComponentInChildren<Image>().sprite = Sprite1Corona;
        //Handle.GetComponentInChildren<Image>().sprite = Sprite1Corona;
        ray = Canvas.GetComponent<RayCast>();
        if (!GUIManager.instance.GetJoistickModificato())
        {
            GUIManager.instance.SetColoreCoronaAggiornato(Coronadefault);
            GUIManager.instance.SetColoreHandleAggiornato(Handledefault);
            GUIManager.instance.SetSpriteHandleAggiornato(HandledefaultSprite);
            GUIManager.instance.SetSpriteCoronaAggiornato(CoronadefaultSprite);
        }
        //joystick.GetComponentInChildren<Image>().color = Color.green;//*modifica corona
        ////joystick.GetComponentInChildren<>().color = Color.red;
        //Handle.GetComponentInChildren<Image>().color = Color.red;//*modifica cursore
       
    }

    // Update is called once per frame
    void Update()
    {
        

        //print(GameManager.instance.GetTastoToccato());
        //if (ray.getNome() != null) oggetto = string.Copy(ray.getNome());
        //oggetto1Colore = GUIManager.instance.GetColoreHandleAggiornato();
        //oggetto2Colore = GUIManager.instance.GetColoreCoronaAggiornato();
        //oggetto1Sprite = GUIManager.instance.GetSpriteHandleAggiornato();
        //oggetto2Sprite = GUIManager.instance.GetSpriteCoronaAggiornato();
        //print("oggetto colpito\t:" + ray.getNome());
        //modificaColoreCorona();
        //modificaColoreCursore();
        //modificaSpriteCorona();
        //modificaSpriteHandle();
        //if (modificajoistick)
        //{
            joystick.GetComponentInChildren<Image>().color = GUIManager.instance.GetColoreCoronaAggiornato();
            Handle.GetComponentInChildren<Image>().color = GUIManager.instance.GetColoreHandleAggiornato();
            joystick.GetComponentInChildren<Image>().sprite = GUIManager.instance.GetSpriteCoronaAggiornato();
            Handle.GetComponentInChildren<Image>().sprite = GUIManager.instance.GetSpriteHandleAggiornato();
        //}
        //else
        //{
        //    joystick.GetComponentInChildren<Image>().color = GUIManager.instance.GetColoreCoronaDefault();
        //    Handle.GetComponentInChildren<Image>().color = GUIManager.instance.GetColoreHandleDefault();
        //    joystick.GetComponentInChildren<Image>().sprite = GUIManager.instance.GetSpriteCoronaDefault();
        //    Handle.GetComponentInChildren<Image>().sprite = GUIManager.instance.GetSpriteHandleDefault();
        //}
    }
        
    //private void modificaColoreCorona()
    //{
       
    //    if (string.Compare(oggetto2Colore, "nero.corona") == 0) {
    //        if (!modificajoistick) { GUIManager.instance.SetJoistickModificato(true); }
    //        joystick.GetComponentInChildren<Image>().color = Color.black;
    //    }
    //    if (string.Compare(oggetto2Colore, "blu.corona ") == 0) {
    //        if (!modificajoistick) { GUIManager.instance.SetJoistickModificato(true); }
    //        joystick.GetComponentInChildren<Image>().color = Color.blue;
    //    }
    //    if (string.Compare(oggetto2Colore, "ciano.corona  ") == 0) {
    //        if (!modificajoistick) { GUIManager.instance.SetJoistickModificato(true); }
    //        joystick.GetComponentInChildren<Image>().color = Color.cyan;
    //    }
       
    //    if (string.Compare(oggetto2Colore, "grigio.corona   ") == 0) {
    //        if (!modificajoistick) { GUIManager.instance.SetJoistickModificato(true); }
    //        joystick.GetComponentInChildren<Image>().color = Color.grey;
    //    }
    //    if (string.Compare(oggetto2Colore, "verde.corona") == 0) {
    //        if (!modificajoistick) { GUIManager.instance.SetJoistickModificato(true); }
    //        { joystick.GetComponentInChildren<Image>().color = Color.green; }
    //    }
    //    if (string.Compare(oggetto2Colore, "magenta.corona    ") == 0) {
    //        if (!modificajoistick) { GUIManager.instance.SetJoistickModificato(true); }
    //        joystick.GetComponentInChildren<Image>().color = Color.magenta;
    //    }
    //    if (string.Compare(oggetto2Colore, "rosso.corona     ") == 0) {
    //        if (!modificajoistick) { GUIManager.instance.SetJoistickModificato(true); }
    //        joystick.GetComponentInChildren<Image>().color = Color.red;
    //    }
    //    if (string.Compare(oggetto2Colore, "bianco.corona      ") == 0) {
    //        if (!modificajoistick) { GUIManager.instance.SetJoistickModificato(true); }
    //        joystick.GetComponentInChildren<Image>().color = Color.white;
    //    }
    //    if (string.Compare(oggetto2Colore, "giallo.corona       ") == 0) {
    //        if (!modificajoistick) { GUIManager.instance.SetJoistickModificato(true); }
    //        joystick.GetComponentInChildren<Image>().color = Color.yellow;
    //    }
        
    //}
 
    //private void modificaColoreCursore()
    //{
    //    if (string.Compare(oggetto1Colore, "nero.handle") == 0) {
    //        if (!modificajoistick) { GUIManager.instance.SetJoistickModificato(true); }
    //        Handle.GetComponentInChildren<Image>().color = Color.black;
    //    }
       
    //    if (string.Compare(oggetto1Colore, "blu.handle") == 0) {
    //        if (!modificajoistick) { GUIManager.instance.SetJoistickModificato(true); }
    //        Handle.GetComponentInChildren<Image>().color = Color.blue;
    //    }
    //    if (string.Compare(oggetto1Colore, "ciano.handle ") == 0) {
    //        if (!modificajoistick) { GUIManager.instance.SetJoistickModificato(true); }
    //        Handle.GetComponentInChildren<Image>().color = Color.cyan;
    //    }
    //    if (string.Compare(oggetto1Colore, "grigio.handle   ") == 0) {
    //        if (!modificajoistick) { GUIManager.instance.SetJoistickModificato(true); }
    //        Handle.GetComponentInChildren<Image>().color = Color.grey;
    //    }
    //    if (string.Compare(oggetto1Colore, "verde.handle") == 0) {
    //        if (!modificajoistick) { GUIManager.instance.SetJoistickModificato(true); }
    //        Handle.GetComponentInChildren<Image>().color = Color.green;
    //    }
    //    if (string.Compare(oggetto1Colore, "magenta.handle    ") == 0) {
    //        if (!modificajoistick) { GUIManager.instance.SetJoistickModificato(true); }
    //        Handle.GetComponentInChildren<Image>().color = Color.magenta;
    //    }
        
    //    if (string.Compare(oggetto1Colore, "rosso.handle ") == 0) {
    //        if (!modificajoistick) { GUIManager.instance.SetJoistickModificato(true); }
    //        Handle.GetComponentInChildren<Image>().color = Color.red;
    //    }
    //    if (string.Compare(oggetto1Colore, "bianco.handle      ") == 0) {
    //        if (!modificajoistick) { GUIManager.instance.SetJoistickModificato(true); }
    //        Handle.GetComponentInChildren<Image>().color = Color.white;
    //    }
    //    if (string.Compare(oggetto1Colore, "giallo.handle  ") == 0) {
    //        if (!modificajoistick) { GUIManager.instance.SetJoistickModificato(true); }
    //        Handle.GetComponentInChildren<Image>().color = Color.yellow;
    //    }
    //}
   
    //private void modificaSpriteCorona()
    //{
    //    //string.Compare(nome, "Sprite1.corona") == 0 || string.Compare(nome, "Sprite2.corona  ") == 0 || string.Compare(nome, "Sprite3.corona   ") == 0 || string.Compare(nome, "Sprite4.corona    ") == 0
    //    //    || string.Compare(nome, "Sprite5.corona     ") == 0 || string.Compare(nome, "Sprite6.corona      ") == 0 )
    //    //{
    //    //oggetto2
    //    //    GUIManager.instance.SetSpriteCoronaAggiornato(nome);
    //    //joystick.GetComponentInChildren<Image>().sprite = Sprite1Corona;
    //    //}

    //    if (string.Compare(oggetto2Sprite, "Sprite1.corona") == 0) { joystick.GetComponentInChildren<Image>().sprite = Sprite1Corona; if (!modificajoistick) { GUIManager.instance.SetJoistickModificato(true); } }
    //    if (string.Compare(oggetto2Sprite, "Sprite2.corona  ") == 0) { joystick.GetComponentInChildren<Image>().sprite = Sprite2Corona; if (!modificajoistick) { GUIManager.instance.SetJoistickModificato(true); } }
    //    if (string.Compare(oggetto2Sprite, "Sprite3.corona   ") == 0) { joystick.GetComponentInChildren<Image>().sprite = Sprite3Corona; if (!modificajoistick) { GUIManager.instance.SetJoistickModificato(true); } }
    //    if (string.Compare(oggetto2Sprite, "Sprite4.corona    ") == 0) { joystick.GetComponentInChildren<Image>().sprite = Sprite4Corona; if (!modificajoistick) { GUIManager.instance.SetJoistickModificato(true); } }
    //    if (string.Compare(oggetto2Sprite, "Sprite5.corona     ") == 0) { joystick.GetComponentInChildren<Image>().sprite = Sprite5Corona; if (!modificajoistick) { GUIManager.instance.SetJoistickModificato(true); } }
    //    if (string.Compare(oggetto2Sprite, "Sprite6.corona      ") == 0) { joystick.GetComponentInChildren<Image>().sprite = Sprite6Corona; if (!modificajoistick) { GUIManager.instance.SetJoistickModificato(true); } }
        
    //}
    //private void modificaSpriteHandle()
    //{
    //    //*"Sprite4.handle    " "Sprite5.handle " "Sprite1.handle" "Sprite3.handle   " "Sprite2.handle " "Sprite6.handle      "
    //    if (string.Compare(oggetto1Sprite, "Sprite1.handle") == 0) { Handle.GetComponentInChildren<Image>().sprite = Sprite1Handle; if (!modificajoistick) { GUIManager.instance.SetJoistickModificato(true); } }
    //    if (string.Compare(oggetto1Sprite, "Sprite2.handle ") == 0) { Handle.GetComponentInChildren<Image>().sprite = Sprite2Handle; if (!modificajoistick) { GUIManager.instance.SetJoistickModificato(true); } }
    //    if (string.Compare(oggetto1Sprite, "Sprite3.handle   ") == 0) { Handle.GetComponentInChildren<Image>().sprite = Sprite3Handle; if (!modificajoistick) { GUIManager.instance.SetJoistickModificato(true); } }
    //    if (string.Compare(oggetto1Sprite, "Sprite4.handle    ") == 0) { Handle.GetComponentInChildren<Image>().sprite = Sprite4Handle; if (!modificajoistick) { GUIManager.instance.SetJoistickModificato(true); } }
    //    if (string.Compare(oggetto1Sprite, "Sprite5.handle ") == 0) { Handle.GetComponentInChildren<Image>().sprite = Sprite5Handle; if (!modificajoistick) { GUIManager.instance.SetJoistickModificato(true); } }
    //    if (string.Compare(oggetto1Sprite, "Sprite6.handle      ") == 0) { Handle.GetComponentInChildren<Image>().sprite = Sprite6Handle; if (!modificajoistick) { GUIManager.instance.SetJoistickModificato(true); } }
    //}
}
