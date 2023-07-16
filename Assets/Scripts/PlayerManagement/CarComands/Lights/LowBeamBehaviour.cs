using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LowBeamBehaviour : MonoBehaviour
{
    [SerializeField] private Light lowBeamLightLeft;
    [SerializeField] private Light lowBeamLightRight;
    private static LowBeamBehaviour lowBeam;
    private static bool lowBeamOn;
    private Color imageColor;
    private HighBeamBehaviour highBeam;

    void Awake()
    {
        lowBeam = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        lowBeamOn = false;
        imageColor = GetComponent<Image>().color;
        lowBeamLightLeft.intensity = 0;
        lowBeamLightRight.intensity = 0;

        highBeam = HighBeamBehaviour.GetHighBeamBehaviourInstance();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLowBeamOn()
    {
        lowBeamOn = true;
        lowBeamLightLeft.intensity = 80;
        lowBeamLightRight.intensity = 80;
        imageColor.a = 1f;
    }

    public void SetLowBeamOff()
    { 
        lowBeamOn = false;
        lowBeamLightLeft.intensity = 0;
        lowBeamLightRight.intensity = 0;
        imageColor.a = 100 / 255f;
        GetComponent<Image>().color = imageColor;
    }

    public bool IsLowBeamOn()
    {
        return lowBeamOn;
    }

    //turns the beam off if its on and viceversa
    //also changes the alpha value
    public void TurnLowBeamOnOrOff()
    {
        //if the car is on you can turn on lights
        if (Car.car.IsOn())
        {
            if (highBeam.IsHighBeamOn())
            {
                highBeam.TurnHighBeamOnOrOff();
            }
            if (lowBeamOn)
            {
                SetLowBeamOff();
            }
            else
            {
                SetLowBeamOn();
            }
        }
        GetComponent<Image>().color = imageColor;
    }

    public static LowBeamBehaviour GetLowBeamBehaviourInstance()
    {
        return lowBeam;
    }
}
