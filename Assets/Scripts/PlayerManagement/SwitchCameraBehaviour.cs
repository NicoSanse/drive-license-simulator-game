using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCameraBehaviour : MonoBehaviour
{
    public static SwitchCameraBehaviour switchCamera;

    void Awake()
    {
        switchCamera = this;
    }

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void SwitchCamera()
    {
        MSVehicleControllerFree.mSVehicleControllerFree.InputsCamerasMobile();
    }
}
