using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class RayCast : MonoBehaviour
{
    private bool impostazioni;
    //[SerializeField] Text testo;
    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;
    private bool ModificaAttiva;
    private string nome;
    void Start()
    {
        
        //Fetch the Raycaster from the GameObject (the Canvas)
        m_Raycaster = GetComponent<GraphicRaycaster>();
        //Fetch the Event System from the Scene
        m_EventSystem = GetComponent<EventSystem>();
    }

    void Update()
    {
        impostazioni = GUIManager.instance.GetImpostazioniAttive();

        ModificaAttiva = GUIManager.instance.GetModificaAttiva();
        if (ModificaAttiva|| impostazioni)
        {
            //Check if the left Mouse button is clicked
            if (Input.GetKey(KeyCode.Mouse0))
            {
                //Set up the new Pointer Event
                m_PointerEventData = new PointerEventData(m_EventSystem);
                //Set the Pointer Event Position to that of the mouse position
                m_PointerEventData.position = Input.mousePosition;

                //Create a list of Raycast Results
                List<RaycastResult> results = new List<RaycastResult>();

                //Raycast using the Graphics Raycaster and mouse click position
                m_Raycaster.Raycast(m_PointerEventData, results);

                //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
                foreach (RaycastResult result in results)
                {

                    if (ModificaAttiva) { GameManager.instance.setTastoToccato(result.gameObject.name); }
                   else 
                   {
                        if (result.gameObject.CompareTag("selezionabile"))
                        {
                            nome = string.Copy(result.gameObject.name);
                            //GameManager.instance.setTastoToccato(nome);
                            //print("hit:" + "\t" + nome);
                            //Debug.Log("Hit" + "\t" + nome);
                        }
                    } 
                }
                //if (nome != null) { print("hit:" + "\t" + nome); }
            }
            if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
            {
                //Set up the new Pointer Event
                m_PointerEventData = new PointerEventData(m_EventSystem);
                //Set the Pointer Event Position to that of the mouse position
                m_PointerEventData.position = Input.touches[0].position;

                //Create a list of Raycast Results
                List<RaycastResult> results = new List<RaycastResult>();

                //Raycast using the Graphics Raycaster and mouse click position
                m_Raycaster.Raycast(m_PointerEventData, results);

                //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
                foreach (RaycastResult result in results)
                {


                    if (ModificaAttiva)
                    {
                        GameManager.instance.setTastoToccato(result.gameObject.name);
                    }
                    else
                    {
                        if (result.gameObject.CompareTag("selezionabile"))
                        {
                            nome = string.Copy(result.gameObject.name);
                            
                        }
                    }
                }
            }
        }
        VerificaNome();
        GUIManager.instance.setOggetto(nome);
    }

private void VerificaNome()
    {
        
        //NomeHandle();
        //NomeCorona();
    }
    //private void NomeCorona()
    //{//*"Sprite2.corona  " "Sprite3.corona   " "Sprite1.corona" "Sprite6.corona      " "Sprite5.corona     " "Sprite4.corona    "
    //    if (string.Compare(nome, "nero.corona") == 0 || string.Compare(nome, "ciano.corona  ") == 0 || string.Compare(nome, "grigio.corona   ") == 0 || string.Compare(nome, "verde.corona") == 0
    //        || string.Compare(nome, "magenta.corona    ") == 0 || string.Compare(nome, "rosso.corona     ") == 0 || string.Compare(nome, "bianco.corona      ") == 0 || string.Compare(nome, "giallo.corona       ") == 0 ||
    //        string.Compare(nome, "blu.corona ") == 0)
    //    {
    //        //GUIManager.instance.SetColoreCoronaAggiornato(nome);
    //        GUIManager.instance.setOggetto(nome);
    //    }
    //    else if(string.Compare(nome, "Sprite1.corona") == 0 || string.Compare(nome, "Sprite2.corona  ") == 0 || string.Compare(nome, "Sprite3.corona   ") == 0 || string.Compare(nome, "Sprite4.corona    "   ) == 0
    //        || string.Compare(nome, "Sprite5.corona     ") == 0 || string.Compare(nome, "Sprite6.corona      ") == 0 )
    //    {
    //        //GUIManager.instance.SetSpriteCoronaAggiornato(nome);
    //        GUIManager.instance.setOggetto(nome);
    //    }
        
    //}
    //private void NomeHandle()
    //{//*"Sprite4.handle    " "Sprite5.handle " "Sprite1.handle" "Sprite3.handle   " "Sprite2.handle " "Sprite6.handle      "
    //    //Debug.Log(nome);
    //    if (string.Compare(nome, "nero.handle") == 0 || string.Compare(nome, "ciano.handle ") == 0 || string.Compare(nome, "grigio.handle   ") == 0 || string.Compare(nome, "verde.handle") == 0
    //        || string.Compare(nome, "magenta.handle    ") == 0 || string.Compare(nome, "rosso.handle ") == 0 || string.Compare(nome, "bianco.handle      ") == 0 || string.Compare(nome, "giallo.handle  ") == 0||
    //        string.Compare(nome, "blu.handle") == 0)
    //    {
    //        GUIManager.instance.SetColoreHandleAggiornato(nome);
    //        GUIManager.instance.setOggetto(nome);

    //    }
    //    else if (string.Compare(nome, "Sprite1.handle") == 0 || string.Compare(nome, "Sprite2.handle ") == 0 || string.Compare(nome, "Sprite3.handle   ") == 0 || string.Compare(nome, "Sprite4.handle    ") == 0
    //        || string.Compare(nome, "Sprite5.handle ") == 0 || string.Compare(nome, "Sprite6.handle      ") == 0)
    //    {
    //        GUIManager.instance.SetSpriteHandleAggiornato(nome);
    //        GUIManager.instance.setOggetto(nome);
    //    }
    //}
    public string GetNome()
    {
        return nome;
    }
}
