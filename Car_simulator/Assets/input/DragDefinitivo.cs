using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDefinitivo : MonoBehaviour,IDragHandler,IEndDragHandler,IBeginDragHandler
{
    private Vector3 pos;
    private bool ModificaAttiva;
    private Transform padre;
    private string nome;
    private bool touchAttivo;
    private string nome1;
    private string nome2;
    public void OnBeginDrag(PointerEventData eventData)
    {
        

    }
    //private void OnTouch()
    //{
    //    if(Input.touchCount > 0)
    //    {
    //        if (Input.GetTouch(0).phase == TouchPhase.Began)
    //        {
    //            print("sono fermo su:" + transform.gameObject.name);
    //        }
    //    }
    //}
    public void OnDrag(PointerEventData eventData)
    {
        if (ModificaAttiva)
        {
            if (Input.touchCount == 0)
            {
                //transform.position = (Input.mousePosition);
                //padre = transform.gameObject.GetComponentInParent<Transform>();
                //padre.position = Input.mousePosition;
                transform.parent.position= (Input.mousePosition);
                transform.position= (Input.mousePosition);
                //nome1 = transform.ToString();
                //touchAttivo = false;
                //GameManager.instance.setTastoToccato(transform.gameObject.name);

            }
            else if (Input.touchCount > 0)
            {
                transform.parent.position = Input.GetTouch(0).position;
                transform.position = Input.GetTouch(0).position;
                //nome2 = transform.ToString();
                //touchAttivo = true;
               
                //GameManager.instance.setTastoToccato(transform.gameObject.name);
            }
        }
        else { return; }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (ModificaAttiva) {
            pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            
        }
        else { return;  }
    }
    // Start is called before the first frame update
    void Start()
    {
        ModificaAttiva = GUIManager.instance.GetModificaAttiva();
        
    }
    
    // Update is called once per frame

    void Update()
    {
        ////OnTouch();

        //if (Input.touchCount > 0&&Input.touches[0].phase==TouchPhase.Began)
        //{
        //    //Touch touch = Input.GetTouch(0);
        //    //if (touch.phase == TouchPhase.Began)
        //    //{
        //    //    print("ho un tocco");
        //    //}
        //    Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
        //    RaycastHit hit;
        //    if(Physics.Raycast(ray,out hit))
        //    {
        //        if (hit.collider != null)
        //        {
        //            print("oggetto colpito:" + hit.collider.name);
        //        }
        //    }
        //}
        //if (Input.GetMouseButtonDown(0))
        //{
        //    //Touch touch = Input.GetTouch(0);
        //    //if (touch.phase == TouchPhase.Began)
        //    //{
        //    //    print("ho un tocco");
        //    //}
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit;
        //    if (Physics.Raycast(ray, out hit,100f,5))
        //    {
        //        if (hit.collider != null)
        //        {
        //            print("oggetto colpito:" + hit.collider.transform.gameObject.name);
        //        }
        //    }
        //}
    }
}
