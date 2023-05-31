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
        ClutchBehaviour.Gear gear = ClutchBehaviour.clutch.GetCurrentGear();

        switch(gear)
        {
            case ClutchBehaviour.Gear.Gear1:
                GetComponent<TMP_Text>().text = "1'";
                break;
            case ClutchBehaviour.Gear.Gear2:
                GetComponent<TMP_Text>().text = "2'";
                break;
            case ClutchBehaviour.Gear.Gear3:
                GetComponent<TMP_Text>().text = "3'";
                break;
            case ClutchBehaviour.Gear.Gear4:
                GetComponent<TMP_Text>().text = "4'";
                break;
            case ClutchBehaviour.Gear.Gear5:
                GetComponent<TMP_Text>().text = "5'";
                break;
            case ClutchBehaviour.Gear.GearR:
                GetComponent<TMP_Text>().text = "R";
                break;
            case ClutchBehaviour.Gear.GearN:
                GetComponent<TMP_Text>().text = "N";
                break;
        }

    }
}
