using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoPlayer : MonoBehaviour
{
    float velocit� = 10f;
   
    CharacterController controllo;
    public Transform terracheck;
    float distanzasuolo = 1f;
    public LayerMask TerraMask; //* variabile distanza suolo e layermask servono per attivare la gravit� solo se sono distante dal terreno calpestabile, altrimenti gravit� =0
    bool tocco;
 
    Vector3 velocit�y;
    float g = -9.8f; //* accelerazione di gravit�
    float altezza = 3f;
}
