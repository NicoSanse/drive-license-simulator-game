using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//this class shows the current speed
public class CurrentSpeedMessageShown : MonoBehaviour
{
    private Car car;
    void Start()
    {
        car = Car.GetCarInstance();
    }

    void Update()
    {
        ChangeMessageShown();
    }

    private void ChangeMessageShown(){
        GetComponent<TMP_Text>().text = Mathf.RoundToInt(car.GetSpeed()) + " km/h";
    }
}
