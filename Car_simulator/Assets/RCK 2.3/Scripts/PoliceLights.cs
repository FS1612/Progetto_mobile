using UnityEngine;
using System.Collections;

public class PoliceLights : MonoBehaviour
{



    public bool activeLight = true;

    public float time = 20;

    public AudioSource policeAudioSource;

    public AudioClip[] policeAudioClips;


    public Light[] RedLights;
    public Light[] BlueLights;

    

    private float timer = 0.0f;
    private int lightNum = 0;
}




