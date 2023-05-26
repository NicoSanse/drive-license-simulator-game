using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowBeamBehaviour : MonoBehaviour
{
    public static LowBeamBehaviour lowBeam;
    private static bool lowBeamOn;

    void Awake()
    {
        lowBeam = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        lowBeamOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setLowBeamOn(bool beam)
    {
        lowBeamOn = beam;
    }

    public bool isLowBeamOn()
    {
        return lowBeamOn;
    }

    public void turnLowBeamOn()
    {
        print("Low Beam On");
        setLowBeamOn(true);
    }

    public void turnLowBeamOff()
    {
        print("Low Beam Off");
        setLowBeamOn(false);
    }
}
