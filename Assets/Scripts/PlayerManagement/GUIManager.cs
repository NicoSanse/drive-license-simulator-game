using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;


public class GUIManager : MonoBehaviour
{
    public static GUIManager guiManager;

    void Awake()
    {
        guiManager = this;
    }
    void Start()
    {

    }

    public void ClickOnLeftArrow() 
    { 
        //implementazione da sistemare: la freccia dovrebbe togliersi da sola
        //il controllo si servirà dell'accelerometro del cellulare
        LeftArrowBehaviour.leftArrow.TurnLeftArrowOnOrOff();
    }

    public void ClickOnRightArrow() 
    { 
        //implementazione da sistemare: la freccia dovrebbe togliersi da sola
        //il controllo si servirà dell'accelerometro del cellulare
        RightArrowBehaviour.rightArrow.TurnRightArrowOnOrOff();
    }

    public void ClickOnHighBeam() 
    { 
        HighBeamBehaviour.highBeam.TurnHighBeamOnOrOff();
    }

    public void ClickOnLowBeam() 
    { 
        LowBeamBehaviour.lowBeam.TurnLowBeamOnOrOff();
    }

    public void ClickOnAccelerator() 
    { 
        AccelerationBehaviour.accelerator.AcceleratorIsPressed();
    }

    public void ReleaseAccelerator()
    {
        AccelerationBehaviour.accelerator.AcceleratorIsReleased();
    }

    public void ClickOnBrake() 
    { 
        BrakeBehaviour.brake.BrakeIsPressed();
    }

    public void ReleaseBrake() 
    { 
        BrakeBehaviour.brake.BrakeIsReleased();
    }

    public void ClickOnClutch() 
    { 
        ClutchBehaviour.clutch.ClutchIsPressed();
    }

    public void ReleaseClutch() 
    { 
        ClutchBehaviour.clutch.ClutchIsReleased();
    }

    public void BeginDragChangePanel(BaseEventData data) 
    {
        PointerEventData eventData = data as PointerEventData;
        ChangeGearPanelBehaviour.changeGear.TakeFirstTouchCoordinates(eventData);
    }

    public void EndDragChangePanel(BaseEventData data) 
    {
        PointerEventData eventData = data as PointerEventData;
        ChangeGearPanelBehaviour.changeGear.TakeLastTouchCoordinates(eventData);
    }

    public void SetNeutralGear(BaseEventData data) 
    {
        PointerEventData eventData = data as PointerEventData;
        ChangeGearPanelBehaviour.changeGear.NeutralGear(eventData);
    }

    public void ReleseGearChangePanel(BaseEventData data) 
    {
        PointerEventData eventData = data as PointerEventData;
        ChangeGearPanelBehaviour.changeGear.ReleseGearChangePanel(eventData);
    }
}
