using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public static Car car;
    private float speed;
    private float RPM;
    private ClutchBehaviour.Gear gear;
    private enum State { On, Off };
    private State currentState;


    void Awake()
    {
        car = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        gear = ClutchBehaviour.clutch.GetCurrentGear();
        speed = 0f;
        RPM = 0f;
        currentState = State.Off;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (currentState == State.On)
        { 
            RPM = CalculateRPM();
        }
        speed = GetComponent<Rigidbody>().velocity.magnitude * 3.6f;
    }

    public void Stop()
    {
        RPM = 0f;
        
        AccelerationBehaviour.accelerator.SetAcceleration(0f);
        BrakeBehaviour.brake.SetDeceleration(0f);

        LowBeamBehaviour.lowBeam.SetLowBeamOff();
        HighBeamBehaviour.highBeam.SetHighBeamOff();
        LeftArrowBehaviour.leftArrow.SetLeftArrowOff();
        RightArrowBehaviour.rightArrow.SetRightArrowOff();
    }

    public void Off()
    {
        Stop();
        gear = ClutchBehaviour.Gear.GearN;
        currentState = State.Off;
    }

    public void On()
    { 
        gear = ClutchBehaviour.clutch.GetCurrentGear();
        currentState = State.On;
    }

    public void NotifyGearChanged()
    {
        gear = ClutchBehaviour.clutch.GetCurrentGear();
        print("Gear changed to " + gear);
    }

    public float GetSpeed()
    {
        return speed;
    }

    public float GetRPM()
    {
        return RPM;
    }

    public ClutchBehaviour.Gear GetGear()
    {
        return gear;
    }

    private float CalculateRPM() 
    {
        float tempRPM = GetComponentsInChildren<WheelCollider>()[0].rpm;
        tempRPM += GetComponentsInChildren<WheelCollider>()[1].rpm;
        tempRPM += GetComponentsInChildren<WheelCollider>()[2].rpm;
        tempRPM += GetComponentsInChildren<WheelCollider>()[3].rpm;
        tempRPM /= 4;
        return tempRPM;
    }

    public void SetState(bool state)
    {
        if(state == true) currentState = State.On;
        else currentState = State.Off;
    }

    public bool GetState()
    {
        if(currentState == State.On) return true;
        else return false;
    }
}
