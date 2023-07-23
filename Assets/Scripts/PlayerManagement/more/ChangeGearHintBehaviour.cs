using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeGearHintBehaviour : MonoBehaviour
{
    private Image upperGear, lowerGear;
    private Car car;
    private ClutchBehaviour.Gear gear;
    private float speed;

    void Start()
    {
        car = Car.GetCarInstance();
        upperGear = GetComponentsInChildren<Image>(true)[2];
        lowerGear = GetComponentsInChildren<Image>(true)[3];
    }

    void Update()
    {
        gear = car.GetGear();
        speed = car.GetSpeed();
        CheckGearRequired();
    }

    private void CheckGearRequired()
    { 
        if ((gear == ClutchBehaviour.Gear.Gear1 && speed > 20f ) || 
            (gear == ClutchBehaviour.Gear.Gear2 && speed > 35f) ||
            (gear == ClutchBehaviour.Gear.Gear3 && speed > 50f) ||
            (gear == ClutchBehaviour.Gear.Gear4 && speed > 60f))
        {
            upperGear.gameObject.SetActive(true);
        }
        else
        {
            upperGear.gameObject.SetActive(false);
        }

        if ((gear == ClutchBehaviour.Gear.Gear2 && speed < 15f) ||
            (gear == ClutchBehaviour.Gear.Gear3 && speed < 25f) ||
            (gear == ClutchBehaviour.Gear.Gear4 && speed < 35f) ||
            (gear == ClutchBehaviour.Gear.Gear5 && speed < 50f))
        {
            lowerGear.gameObject.SetActive(true);
        }
        else
        {
            lowerGear.gameObject.SetActive(false);
        }
         
    }
}
