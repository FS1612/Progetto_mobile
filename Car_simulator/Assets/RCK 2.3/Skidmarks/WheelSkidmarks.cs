using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class WheelSkidmarks : MonoBehaviour {

#pragma warning disable CS1633 // Directiva #pragma no reconocida
#pragma strict

//@script RequireComponent(WheelCollider)//We need a wheel collider

public GameObject skidCaller;//The parent oject having a rigidbody attached to it.
#pragma warning restore CS1633 // Directiva #pragma no reconocida
public float startSlipValue = 0.4f;
private Skidmarks skidmarks = null;//To hold the skidmarks object
private int lastSkidmark = -1;//To hold last skidmarks data
private WheelCollider wheel_col;//To hold self wheel collider


}
