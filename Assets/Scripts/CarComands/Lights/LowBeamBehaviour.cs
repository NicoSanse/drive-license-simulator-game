using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LowBeamBehaviour : MonoBehaviour
{
    public static LowBeamBehaviour lowBeam;
    private static bool lowBeamOn;
    private Color imageColor;

    void Awake()
    {
        lowBeam = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        lowBeamOn = false;
        imageColor = GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLowBeamOn(bool beam)
    {
        lowBeamOn = beam;
    }

    public bool IsLowBeamOn()
    {
        return lowBeamOn;
    }

    public void TurnLowBeamOnOrOff()
    {
        if (lowBeamOn)
        {
            print("Low Beam Off");
            imageColor.a = 100/255f;
            SetLowBeamOn(false);
        }
        else
        {
            print("Low Beam On");
            imageColor.a = 1f;
            SetLowBeamOn(true);
        }
        GetComponent<Image>().color = imageColor;
    }
}
