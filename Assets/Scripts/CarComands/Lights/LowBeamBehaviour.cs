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

    public void SetLowBeamOn(bool beam)
    {
        lowBeamOn = beam;
    }

    public bool IsLowBeamOn()
    {
        return lowBeamOn;
    }

    public void TurnLowBeamOn()
    {
        print("Low Beam On");
        SetLowBeamOn(true);
    }

    public void TurnLowBeamOff()
    {
        print("Low Beam Off");
        SetLowBeamOn(false);
    }
}
