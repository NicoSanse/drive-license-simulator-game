using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighBeamBehaviour : MonoBehaviour
{
    public static HighBeamBehaviour highBeam;
    private static bool highBeamOn;

    void Awake()
    {
        highBeam = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        highBeamOn = false;
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

    public void TurnHighBeamOn()
    {
        print("High Beam On");
        SetHighBeamOn(true);
    }

    public void TurnHighBeamOff()
    {
        print("High Beam Off");
        SetHighBeamOn(false);
    }
}
