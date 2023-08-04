using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class models the accelerator
public class AccelerationBehaviour : MonoBehaviour
{
    [SerializeField] Light retroLeftLight;
    [SerializeField] Light retroRightLight;
    private static AccelerationBehaviour accelerator;
    private float acceleration;
    private bool acceleratorPressed;
    private float sensibility = 3f;
    private ClutchBehaviour clutch;
    private Car car;

    void Awake()
    {
        accelerator = this;
    }

    void Start()
    {
        acceleratorPressed = false;
        acceleration = 0f;
        clutch = ClutchBehaviour.GetClutchBehaviourInstance();
        car = Car.GetCarInstance();
    }

    void Update()
    {
        StartCoroutine(CommonBehaviours.ChangeScale(acceleratorPressed, GetComponent<RectTransform>()));
        Accelerate();
        RetroLights();
    }

    //turns the retro lights on if the car is on and the gear is R
    private void RetroLights()
    {
        if (car.IsOn() && clutch.GetCurrentGear() == ClutchBehaviour.Gear.GearR && acceleratorPressed)
        { 
            retroLeftLight.intensity = 20;
            retroRightLight.intensity = 20;
        }
        else
        {
            retroLeftLight.intensity = 0;
            retroRightLight.intensity = 0;
        }
    }

    //triggered by GUIManager class when pressing the accelerator button
    public void AcceleratorIsPressed() 
    {
        acceleratorPressed = true;
    }

    //triggered by GUIManager class when releasing the accelerator button
    public void AcceleratorIsReleased()
    {
        acceleratorPressed = false;
    }

    //increases the acceleration value
    private void Accelerate() 
    {
        if (acceleratorPressed)
        {
            acceleration += Time.deltaTime * sensibility;
        }
        else
        {
            acceleration -= Time.deltaTime * sensibility;
        }
        acceleration = Mathf.Clamp(acceleration, 0, 1);
    }

    public void SetAcceleration(float value)
    {
        acceleration = value;
    }

    public float GetAcceleration()
    {
        return acceleration;
    }

    private void SetAcceleratorPressed(bool value)
    {
        acceleratorPressed = value;
    }

    public bool IsAcceleratorPressed()
    {
        return acceleratorPressed;
    }

    public static AccelerationBehaviour GetAccelerationBehaviourInstance()
    {
        return accelerator;
    }
}
