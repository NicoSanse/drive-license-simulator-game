using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class shows the red circle that shows the current gear
public class CurrentGearImageBehaviour : MonoBehaviour
{
    private ClutchBehaviour clutch;
    private ClutchBehaviour.Gear currentGear;
    void Start()
    {
        clutch = ClutchBehaviour.GetClutchBehaviourInstance();
    }

    void Update()
    {
        FindLocation();
    }
    
    //locates the red circle on the current gear. The coordinates are local in the editor
    void FindLocation()
    {
        currentGear = clutch.GetCurrentGear();
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
