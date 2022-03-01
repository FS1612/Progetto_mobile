using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAround : MonoBehaviour
{
    private float StartPosX;
    private float StartPosY;
    private bool moving = false;
    // Start is called before the first frame update
   
    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            this.transform.localPosition = new Vector3(mousePos.x - StartPosX, mousePos.y - StartPosY, this.transform.localPosition.z);
        }
    }
    private void OnMouseDown()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousepos;
            mousepos = Input.mousePosition;
            mousepos = Camera.main.ScreenToWorldPoint(mousepos);
            StartPosX = mousepos.x - this.transform.localPosition.x;
            StartPosY = mousepos.y - this.transform.localPosition.y;
            moving = true;
        }
    }
    private void OnMouseUp()
    {
        moving = false;
    }
}
