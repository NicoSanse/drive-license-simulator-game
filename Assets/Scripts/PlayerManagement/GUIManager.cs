using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void clickOnLeftArrow() { 
        //implementazione da sistemare: la freccia dovrebbe togliersi da sola
        //il controllo si servirà dell'accelerometro del cellulare
        if(LeftArrowBehaviour.leftArrow.isLeftArrowOn()){
            LeftArrowBehaviour.leftArrow.turnLeftArrowOff();
        }
        else{
            LeftArrowBehaviour.leftArrow.turnLeftArrowOn();
        }
    }

    public void clickOnRightArrow() { 
        //implementazione da sistemare: la freccia dovrebbe togliersi da sola
        //il controllo si servirà dell'accelerometro del cellulare
        if(RightArrowBehaviour.rightArrow.isRightArrowOn()){
            RightArrowBehaviour.rightArrow.turnRightArrowOff();
        }
        else{
            RightArrowBehaviour.rightArrow.turnRightArrowOn();
        }
    }

    public void clickOnHighBeam() { 
        if(HighBeamBehaviour.highBeam.isHighBeamOn()){
            HighBeamBehaviour.highBeam.turnHighBeamOff();
        }
        else{
            HighBeamBehaviour.highBeam.turnHighBeamOn();
        }
    }

    public void clickOnLowBeam() { 
        if(LowBeamBehaviour.lowBeam.isLowBeamOn()){
            LowBeamBehaviour.lowBeam.turnLowBeamOff();
        }
        else{
            LowBeamBehaviour.lowBeam.turnLowBeamOn();
        }
    }

    public void clickOnAccelerator() { 
        AccelerationBehaviour.accelerator.AcceleratorIsPressed();
    }

    public void releaseAccelerator()
    {
        AccelerationBehaviour.accelerator.AcceleratorIsReleased();
    }

    public void clickOnBrake() { 
        BrakeBehaviour.brake.BrakeIsPressed();
    }

    public void releaseBrake() { 
        BrakeBehaviour.brake.BrakeIsReleased();
    }

    public void clickOnClutch() { 
        ClutchBehaviour.clutch.ClutchIsPressed();
    }

    public void releaseClutch() { 
        ClutchBehaviour.clutch.ClutchIsReleased();
    }

    public void clickOnChangeButton() { 
        print("Change Button");
    }
}
