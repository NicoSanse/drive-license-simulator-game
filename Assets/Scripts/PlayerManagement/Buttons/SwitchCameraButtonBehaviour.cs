using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class is just used by the button in the UI 
//to call the method that actually switches the camera
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
