using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CurrentGearMessageShown : MonoBehaviour
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

    //forse non il modo migliore per fare questa cosa
    private void ChangeMessageShown()
    {
        GetComponent<TMP_Text>().text = "Gear: " + ClutchBehaviour.clutch.GetCurrentGear().ToString().Substring(4);
    }
}
