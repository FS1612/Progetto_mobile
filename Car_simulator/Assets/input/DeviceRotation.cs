using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DeviceRotation 
{
    private static bool gyroinitialized = false;
    public static bool HasGyroscope
    {
        get
        {
            return SystemInfo.supportsGyroscope; 
           

        }
    }
    public static Quaternion Get()
    {
        if (!gyroinitialized)
        {
            InitGyro();
        }
        return HasGyroscope
            ? ReadGyroscopeRotation() 
            : Quaternion.identity;
            
    }
    private static void InitGyro()
    {
        if (HasGyroscope)
        {
            Input.gyro.enabled = true;
            Input.gyro.updateInterval = 0.0167f;
        }
        gyroinitialized = true;
    }
    private static Quaternion ReadGyroscopeRotation()
    {
        return new Quaternion(0.5f, 0.1f, -0.5f, 0.5f) * Input.gyro.attitude * new Quaternion(0,1,0,0);
     
    }   
}
