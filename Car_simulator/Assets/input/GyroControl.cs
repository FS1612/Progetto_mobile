using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroControl : MonoBehaviour
{
     //Start is called before the first frame update
    public bool gyroEnabled;
    private Gyroscope gyro;
    private GameObject autocontainer;
    private Quaternion rot;
    void Start()
    {
        autocontainer = new GameObject("autocontainer");
        autocontainer.transform.position = transform.position;
        transform.SetParent(autocontainer.transform);

        gyroEnabled = EnableGyro();
        autocontainer.transform.rotation = Quaternion.Euler(180f,180f,0);
        rot = new Quaternion(0, 0, 1, 0);
    }

    
    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyroEnabled = true;
            return true;
        }
        return false;
    }
    // Update is called once per frame
    private void Update()
    {
        if (gyroEnabled)
        {
            transform.localRotation = gyro.attitude * rot;
        }
    }
}
