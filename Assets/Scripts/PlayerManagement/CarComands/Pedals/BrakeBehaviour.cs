using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class models the brake pedal
public class BrakeBehaviour : MonoBehaviour
{
    [SerializeField] private Light brakeLeftLight;
    [SerializeField] private Light brakeRightLight;
    private static BrakeBehaviour brake;
    private float deceleration;
    private bool brakePressed;
    private float sensibility = 3f;
    private Car car;

    void Awake()
    {
        brake = this;
    }

    void Start()
    {
        brakePressed = false;
        deceleration = 0f;
        car = Car.GetCarInstance();
    }

    void Update()
    {
        StartCoroutine(CommonBehaviours.ChangeScale(brakePressed, GetComponent<RectTransform>()));
        Decelerate();
        BrakesLight();
    }

    //turns the brake lights on if the car is on and the brake is pressed
    private void BrakesLight()
    {
        if (car.IsOn() && brakePressed)
        {
            brakeLeftLight.intensity = 50;
            brakeRightLight.intensity = 50;
        }
        else
        {
            brakeLeftLight.intensity = 0;
            brakeRightLight.intensity = 0;
        }
    }

    //triggered by GUIManager class when the brake button is pressed
    public void BrakeIsPressed() 
    {
        brakePressed = true;
    }

    //triggered by GUIManager class when the brake button is released
    public void BrakeIsReleased() 
    {
        brakePressed = false;
    }

    //increases the deceleration value
    private void Decelerate() 
    {
        if (brakePressed)
        {
            deceleration += Time.deltaTime * sensibility;
        }
        else
        {
            deceleration -= Time.deltaTime * sensibility;
        }
        deceleration = Mathf.Clamp(deceleration, 0, 1);
    }

    public void SetDeceleration(float value)
    {
        deceleration = value;
    }

    public float GetDeceleration()
    {
        return deceleration;
    }

    public static BrakeBehaviour GetBrakeBehaviourInstance()
    {
        return brake;
    }
}
