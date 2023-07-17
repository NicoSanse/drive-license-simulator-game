using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;


public class GUIManager : MonoBehaviour
{
    private static GUIManager guiManager;
    private CurrentCarStateOnOffButtonBehaviour currentCarStateOnOffButton;
    private PauseButtonBehaviour pauseButton;
    private SwitchCameraButtonBehaviour switchCameraButton;
    private LeftArrowBehaviour leftArrow;
    private RightArrowBehaviour rightArrow;
    private HighBeamBehaviour highBeam;
    private LowBeamBehaviour lowBeam;
    private AccelerationBehaviour accelerator;
    private BrakeBehaviour brake;
    private ClutchBehaviour clutch;
    private ChangeGearPanelBehaviour changeGearPanel;
    private Car car;

    void Awake()
    {
        guiManager = this;
    }
    void Start()
    {
        GettingInstances();
    }

    public void ClickOnLeftArrow() 
    { 
        //implementazione da sistemare: la freccia dovrebbe togliersi da sola
        //il controllo si servirà dell'accelerometro del cellulare
        leftArrow.TurnLeftArrowOnOrOff();
    }

    public void ClickOnRightArrow() 
    { 
        //implementazione da sistemare: la freccia dovrebbe togliersi da sola
        //il controllo si servirà dell'accelerometro del cellulare
        rightArrow.TurnRightArrowOnOrOff();
    }

    public void ClickOnHighBeam() 
    { 
        highBeam.TurnHighBeamOnOrOff();
    }

    public void ClickOnLowBeam() 
    { 
        lowBeam.TurnLowBeamOnOrOff();
    }

    public void ClickOnAccelerator() 
    { 
        accelerator.AcceleratorIsPressed();
    }

    public void ReleaseAccelerator()
    {
        accelerator.AcceleratorIsReleased();
    }

    public void ClickOnBrake() 
    { 
        brake.BrakeIsPressed();
    }

    public void ReleaseBrake() 
    { 
        brake.BrakeIsReleased();
    }

    public void ClickOnClutch() 
    { 
        clutch.ClutchIsPressed();
    }

    public void ReleaseClutch() 
    { 
        clutch.ClutchIsReleased();
    }

    public void BeginDragChangePanel(BaseEventData data) 
    {
        PointerEventData eventData = data as PointerEventData;
        changeGearPanel.TakeFirstTouchCoordinates(eventData);
    }

    public void EndDragChangePanel(BaseEventData data) 
    {
        PointerEventData eventData = data as PointerEventData;
        changeGearPanel.TakeLastTouchCoordinates(eventData);
    }

    public void SetNeutralGear(BaseEventData data) 
    {
        PointerEventData eventData = data as PointerEventData;
        changeGearPanel.NeutralGear(eventData);
    }

    public void ReleseGearChangePanel(BaseEventData data) 
    {
        PointerEventData eventData = data as PointerEventData;
        changeGearPanel.ReleseGearChangePanel(eventData);
    }

    public void TurningEngineOnBehaviour()
    {
        //if Car is on, turn it off
        if (car.IsOn())
        { 
            MSVehicleControllerFree.mSVehicleControllerFree.MySetEngineOnOff(true);
            currentCarStateOnOffButton.DarkenButton();
        }
        //otherwise turn it on
        else
        {
            MSVehicleControllerFree.mSVehicleControllerFree.MySetEngineOnOff(false);
            currentCarStateOnOffButton.LightenButton();
        }
    }

    public void PauseButton()
    {
        pauseButton.ClickOnPauseButton();
    }

    public void SwitchCameraButton()
    { 
        switchCameraButton.SwitchCamera();
    }

    public static GUIManager GetGUIManagerInstance()
    {
        return guiManager;
    }

    private void GettingInstances()
    {
        currentCarStateOnOffButton = CurrentCarStateOnOffButtonBehaviour.GetCurrentCarStateOnOffButtonBehaviourInstance();
        pauseButton = PauseButtonBehaviour.GetPauseButtonBehaviourInstance();
        switchCameraButton = SwitchCameraButtonBehaviour.GetSwitchCameraButtonBehaviourInstance();
        leftArrow = LeftArrowBehaviour.GetLeftArrowBehaviourInstance();
        rightArrow = RightArrowBehaviour.GetRightArrowBehaviourInstance();
        highBeam = HighBeamBehaviour.GetHighBeamBehaviourInstance();
        lowBeam = LowBeamBehaviour.GetLowBeamBehaviourInstance();
        accelerator = AccelerationBehaviour.GetAccelerationBehaviourInstance();
        brake = BrakeBehaviour.GetBrakeBehaviourInstance();
        clutch = ClutchBehaviour.GetClutchBehaviourInstance();
        changeGearPanel = ChangeGearPanelBehaviour.GetChangeGearPanelBehaviourInstance();
        car = Car.GetCarInstance();
    }
}
