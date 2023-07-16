using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCameraButtonBehaviour : MonoBehaviour
{
    private static SwitchCameraButtonBehaviour switchCamera;

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
        MSVehicleControllerFree.mSVehicleControllerFree.MySwitchCamera();
    }

    public static SwitchCameraButtonBehaviour GetSwitchCameraButtonBehaviourInstance()
    {
        return switchCamera;
    }
}
