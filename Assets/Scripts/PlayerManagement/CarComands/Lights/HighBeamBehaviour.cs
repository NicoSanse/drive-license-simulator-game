using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//this class models the high beam
public class HighBeamBehaviour : MonoBehaviour
{
    [SerializeField] private Light highBeamLightLeft;
    [SerializeField] private Light highBeamLightRight;
    private static HighBeamBehaviour highBeam;
    private static bool highBeamOn;
    private Color imageColor;
    private LowBeamBehaviour lowBeam;
    private Car car;

    void Awake()
    {
        highBeam = this;
    }

    void Start()
    {
        highBeamOn = false;
        imageColor = GetComponent<Image>().color;
        highBeamLightLeft.intensity = 0;
        highBeamLightRight.intensity = 0;

        lowBeam = LowBeamBehaviour.GetLowBeamBehaviourInstance();
        car = Car.GetCarInstance();
    }

    void Update()
    {
        
    }

    public void SetHighBeamOn()
    {
        highBeamOn = true;
        highBeamLightLeft.intensity = 100;
        highBeamLightRight.intensity = 100;
        imageColor.a = 1f;
    }

    public void SetHighBeamOff()
    {
        highBeamOn = false;
        highBeamLightLeft.intensity = 0;
        highBeamLightRight.intensity = 0;
        imageColor.a = 100 / 255f;
        GetComponent<Image>().color = imageColor;
    }

    public bool IsHighBeamOn()
    {
        return highBeamOn;
    }

    //turns the beam off if its on and viceversa
    //also changes the alpha value
    public void TurnHighBeamOnOrOff()
    {
        //if the car is on you can turn on lights
        if (car.IsOn())
        {
            //if low beam is on, turn it off
            if(lowBeam.IsLowBeamOn())
            {
                lowBeam.TurnLowBeamOnOrOff();
            }
            if (highBeamOn)
            {
                SetHighBeamOff();
            }
            else
            {
                SetHighBeamOn();
            }
        }
        GetComponent<Image>().color = imageColor;
    }

    public static HighBeamBehaviour GetHighBeamBehaviourInstance()
    {
        return highBeam;
    }
}
