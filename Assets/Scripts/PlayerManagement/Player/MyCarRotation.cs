using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCarRotation : MonoBehaviour
{
    public static MyCarRotation myCarRotation;
    private float rotation;
    private float sensibility;
    
    void Awake()
    {
        myCarRotation = this;
    }
    void Start()
    {
        rotation = 0f;
        sensibility = 2f;
    }

    void Update()
    {
        MeasureRotation();
    }

    //the rotation is calculated through accelerometer of the device
    private void MeasureRotation()
    {
        rotation = Input.acceleration.x * sensibility;
        Mathf.Clamp(rotation, -0.9f, 0.9f);
        if(rotation > -0.2f && rotation < 0.2f)
        {
            rotation = 0f;
        }
    }

    public float GetValue()
    {
        return rotation;
    }
}
