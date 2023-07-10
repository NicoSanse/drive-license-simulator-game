using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighBeamBehaviour : MonoBehaviour
{
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHighBeamOn(bool beam)
    {
        highBeamOn = beam;
    }

    public bool IsHighBeamOn()
    {
        return highBeamOn;
    }

    //turns the beam off if its on and viceversa
    //also changes the alpha value
    public void TurnHighBeamOnOrOff()
    {
        if (highBeamOn)
        {
            imageColor.a = 100/255f;
            SetHighBeamOn(false);
        }
        else
        {
            imageColor.a = 1f;
            SetHighBeamOn(true);
        }
        GetComponent<Image>().color = imageColor;
    }
}
