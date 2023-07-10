using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrentCarStateOnOffButtonBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShowState();
    }

    private void ShowState()
    {
        if (Car.car.GetState())
        {
            GetComponentInChildren<TMP_Text>().text = "ON";
        }
        else
        {
            GetComponentInChildren<TMP_Text>().text = "OFF";
        }
    }
}
