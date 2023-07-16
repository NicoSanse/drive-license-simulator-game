using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public static Car car;
    private float speed;
    private float RPM;
    private float[] torqueAdjustment;
    //private float r;
    private float radius;
    private float circumference;
    private ClutchBehaviour.Gear gear;
    private enum State { On, Off };
    private State currentState;
    private LeftArrowBehaviour leftArrow;
    private RightArrowBehaviour rightArrow;
    private HighBeamBehaviour highBeam;
    private LowBeamBehaviour lowBeam;
    private AccelerationBehaviour accelerator;
    private BrakeBehaviour brake;
    private ClutchBehaviour clutch;

    void Awake()
    {
        car = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        leftArrow = LeftArrowBehaviour.GetLeftArrowBehaviourInstance();
        rightArrow = RightArrowBehaviour.GetRightArrowBehaviourInstance();
        highBeam = HighBeamBehaviour.GetHighBeamBehaviourInstance();
        lowBeam = LowBeamBehaviour.GetLowBeamBehaviourInstance();
        accelerator = AccelerationBehaviour.GetAccelerationBehaviourInstance();
        brake = BrakeBehaviour.GetBrakeBehaviourInstance();
        clutch = ClutchBehaviour.GetClutchBehaviourInstance();

        torqueAdjustment = new float[5];
        SetTorqueAdjustmentValues();
        //r = 3.0f;
        radius = 0.5f;
        circumference = Mathf.PI * radius * 2f;
        gear = clutch.GetCurrentGear();
        speed = 0f;
        RPM = 0f;
        currentState = State.Off;
    }

    private void SetTorqueAdjustmentValues()
    { 
        torqueAdjustment[0] = 1.5f;
        torqueAdjustment[1] = 1.2f;
        torqueAdjustment[2] = 1.0f;
        torqueAdjustment[3] = 1.0f;
        torqueAdjustment[4] = 1.0f;
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
        
        accelerator.SetAcceleration(0f);
        brake.SetDeceleration(0f);

        lowBeam.SetLowBeamOff();
        highBeam.SetHighBeamOff();
        leftArrow.SetLeftArrowOff();
        rightArrow.SetRightArrowOff();
    }

    public void Off()
    {
        Stop();
        gear = ClutchBehaviour.Gear.GearN;
        currentState = State.Off;
    }

    public void On()
    { 
        gear = clutch.GetCurrentGear();
        currentState = State.On;
    }

    public void NotifyGearChanged()
    {
        gear = clutch.GetCurrentGear();
        print("Gear changed to " + gear);
    }

    private float CalculateRPM() 
    {
        float tempRPM = 0;
        float tempTorqueAdjustment = FindRightTorqueAdjustment();

        //tempRPM = (speed * tempTorqueAdjustment * r)/(diameter * Mathf.PI) * 60f;
        //tempRPM = (speed * 60) / (circumference * tempTorqueAdjustment);
        //tempRPM = (speed * 0.278f)/(tempTorqueAdjustment * radius * 2);
        return tempRPM;
    }

    private float FindRightTorqueAdjustment()
    {
        float Torque = 0;
        if(gear == ClutchBehaviour.Gear.Gear1) Torque = torqueAdjustment[0];
        else if(gear == ClutchBehaviour.Gear.Gear2) Torque = torqueAdjustment[1];
        else if(gear == ClutchBehaviour.Gear.Gear3) Torque = torqueAdjustment[2];
        else if(gear == ClutchBehaviour.Gear.Gear4) Torque = torqueAdjustment[3];
        else if(gear == ClutchBehaviour.Gear.Gear5) Torque = torqueAdjustment[4];
        else if(gear == ClutchBehaviour.Gear.GearR) Torque = torqueAdjustment[0];
        else if(gear == ClutchBehaviour.Gear.GearN) Torque = 0;

        return Torque;
    }



    public bool IsOn()
    {
        if (currentState == State.On) return true;
        else return false;
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
    public void SetState(bool state)
    {
        if(state == true) currentState = State.On;
        else currentState = State.Off;
    }
}
