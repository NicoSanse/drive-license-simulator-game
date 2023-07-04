using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrentRPMMessageShown : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ChangeMessageShown();
    }

    private void ChangeMessageShown(){
        GetComponent<TMP_Text>().text = "RPM: " + Mathf.RoundToInt(Car.car.GetRPM());
    }
}
