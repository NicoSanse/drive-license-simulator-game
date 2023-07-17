using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrentRPMMessageShown : MonoBehaviour
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
        GetComponent<TMP_Text>().text = Mathf.RoundToInt(car.GetRPM()) + " x1000 rpm";
    }
}
