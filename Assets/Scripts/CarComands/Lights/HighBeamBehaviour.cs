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

    public void setHighBeamOn(bool beam)
    {
        highBeamOn = beam;
    }

    public bool isHighBeamOn()
    {
        return highBeamOn;
    }

    public void turnHighBeamOn()
    {
        print("High Beam On");
        setHighBeamOn(true);
    }

    public void turnHighBeamOff()
    {
        print("High Beam Off");
        setHighBeamOn(false);
    }
}
