using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class models the mainly the informations of the player car and it's almost 
//uncorrelated to MSVechicleControllerFree Class, which instead models physics

public class Car : MonoBehaviour
{
    private static Car car;
    private float speed;
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
    
    void Start()
    {
        GettingInstances();
        gear = clutch.GetCurrentGear();
        speed = 0f;
        currentState = State.Off;
    }

    void Update()
    {
        CalculateSpeed();
    }

    //records the speed of the car
    private void CalculateSpeed()
    {
        speed = GetComponent<Rigidbody>().velocity.magnitude * 3.6f;
    }

    //turns off all the lights and sets to zero all the rest
    public void Stop()
    {
        accelerator.SetAcceleration(0f);
        brake.SetDeceleration(0f);
        lowBeam.SetLowBeamOff();
        highBeam.SetHighBeamOff();
        leftArrow.SetLeftArrowOff();
        rightArrow.SetRightArrowOff();
    }

    //turns off the car
    public void Off()
    {
        Stop();
        currentState = State.Off;
    }

    //turns on the car
    public void On()
    { 
        gear = clutch.GetCurrentGear();
        currentState = State.On;
    }

    //sets the gear
    public void NotifyGearChanged()
    {
        gear = clutch.GetCurrentGear();
    }

    public bool IsOn()
    {
        if (currentState == State.On) return true;
        else return false;
    }

    public void SetSpeed(float speed)
    { 
        this.speed = speed;
    }

    public float GetSpeed()
    {
        return speed;
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
    
    private void GettingInstances()
    {
        leftArrow = LeftArrowBehaviour.GetLeftArrowBehaviourInstance();
        rightArrow = RightArrowBehaviour.GetRightArrowBehaviourInstance();
        highBeam = HighBeamBehaviour.GetHighBeamBehaviourInstance();
        lowBeam = LowBeamBehaviour.GetLowBeamBehaviourInstance();
        accelerator = AccelerationBehaviour.GetAccelerationBehaviourInstance();
        brake = BrakeBehaviour.GetBrakeBehaviourInstance();
        clutch = ClutchBehaviour.GetClutchBehaviourInstance();
    }

    public static Car GetCarInstance()
    {
        return car;
    }
}
