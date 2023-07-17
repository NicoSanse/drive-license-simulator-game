using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentGearImageBehaviour : MonoBehaviour
{
    private ClutchBehaviour clutch;
    void Start()
    {
        clutch = ClutchBehaviour.GetClutchBehaviourInstance();
    }

    void Update()
    {
        FindLocation();
    }
    
    //locates the red circle on the current gear. for some reason the localPosition is different
    //than inside the editor
    void FindLocation()
    { 
        ClutchBehaviour.Gear currentGear = clutch.GetCurrentGear();
        RectTransform rectTransform = GetComponent<RectTransform>();

        if (currentGear == ClutchBehaviour.Gear.Gear1) rectTransform.localPosition = new Vector3(-130, 120, 0);
        if (currentGear == ClutchBehaviour.Gear.Gear2) rectTransform.localPosition = new Vector3(-130, -120, 0);
        if (currentGear == ClutchBehaviour.Gear.Gear3) rectTransform.localPosition = new Vector3(-005, 120, 0);
        if (currentGear == ClutchBehaviour.Gear.Gear4) rectTransform.localPosition = new Vector3(-005, -120, 0);
        if (currentGear == ClutchBehaviour.Gear.Gear5) rectTransform.localPosition = new Vector3(115, 120, 0);
        if (currentGear == ClutchBehaviour.Gear.GearR) rectTransform.localPosition = new Vector3(115, -120, 0);
        if (currentGear == ClutchBehaviour.Gear.GearN) rectTransform.localPosition = new Vector3(-005, 0, 0);
    }
}
