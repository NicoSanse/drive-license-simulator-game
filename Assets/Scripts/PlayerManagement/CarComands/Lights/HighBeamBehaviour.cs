using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighBeamBehaviour : MonoBehaviour
{
    [SerializeField] Light highBeamLightLeft;
    [SerializeField] Light highBeamLightRight;
    public static HighBeamBehaviour highBeam;
    private static bool highBeamOn;
    private Color imageColor;

    void Awake()
    {
        highBeam = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        highBeamOn = false;
        imageColor = GetComponent<Image>().color;
        highBeamLightLeft.intensity = 0;
        highBeamLightRight.intensity = 0;
    }

    // Update is called once per frame
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
        if (Car.car.GetState())
        {
            if(LowBeamBehaviour.lowBeam.IsLowBeamOn())
            {
                LowBeamBehaviour.lowBeam.TurnLowBeamOnOrOff();
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
}
