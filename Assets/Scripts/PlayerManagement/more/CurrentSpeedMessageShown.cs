using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrentSpeedMessageShown : MonoBehaviour
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
        GetComponent<TMP_Text>().text = "Speed: " + Mathf.RoundToInt(Car.car.GetSpeed()) + " km/h";
    }
}
