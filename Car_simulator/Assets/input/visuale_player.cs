 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class visuale_player : MonoBehaviour
{
    public Transform player;
    float sensibilità=300f;
    float rot; //* variabile di appoggio per spostamento telecamera su asse y --> la telecamera infatti si alza per variazioni negative di y, si alza viceversa
}
