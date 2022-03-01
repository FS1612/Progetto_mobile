using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoPlayer : MonoBehaviour
{
    float velocità = 10f;
   
    CharacterController controllo;
    public Transform terracheck;
    float distanzasuolo = 1f;
    public LayerMask TerraMask; //* variabile distanza suolo e layermask servono per attivare la gravità solo se sono distante dal terreno calpestabile, altrimenti gravità =0
    bool tocco;
 
    Vector3 velocitày;
    float g = -9.8f; //* accelerazione di gravità
    float altezza = 3f;
}
