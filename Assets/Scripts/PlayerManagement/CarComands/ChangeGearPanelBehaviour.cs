using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//this class models the change gear panel
//management of touches is necessary since the event trigger gets confused by multiple events

public class ChangeGearPanelBehaviour : MonoBehaviour
{
    private static ChangeGearPanelBehaviour changeGear;
    private Vector2 firstTouchCoordinates;
    private Vector2 lastTouchCoordinates;
    private Vector2 direction;
    private Vector2 clickFirstTouchCoordinates;
    private Vector2 clickLastTouchCoordinates;
    private Vector2 vectorBetweenClickTouches;
    private string directionDragged;
    private Coroutine coroutineTimeForNeutralGear;
    private float timeForNeutralGear;
    private ClutchBehaviour clutch;
    private Car car;
    private ParticlesManagement particles;
    private PlayerController player;
    private SaveManager saveManager;
    private SaveState saveState;
    private Menu menu;
    private Level currentLevel;
    private List<string> tempMistakes;

    void Awake()
    {
        changeGear = this;
    }

    void Start()
    {
        Initialization();
    }

    void Update()
    {
        ChangeAlphaValue();
    }
    

    //triggered by GUIManager class, stores the coordinates of first drag touch
    public void TakeFirstTouchCoordinates(PointerEventData eventData) 
    {
        firstTouchCoordinates = eventData.position;
    }

    //triggered by GUIManager class, stores the coordinates of last drag touch then changes the gear
    public void TakeLastTouchCoordinates(PointerEventData eventData) 
    {
        lastTouchCoordinates = eventData.position;
        ChangeGear();
    }
    
    //triggered by GUIManager class, stores the coordinates of first click and finds the time the user is keeping pressed the change gear panel
    public void NeutralGear(PointerEventData eventData)
    {
        clickFirstTouchCoordinates = eventData.position;
        if (clutch.IsClutchPressed())
        {
            coroutineTimeForNeutralGear = StartCoroutine(TimeForNeutralGear());
        }
        else
        {
            ClutchNotPressed();
        }
    }

    //triggered buy GUIManager class, stores the coordinates of last click, finds
    //the distance between the clicks and finds if the user wants to set neutral gear or not
    public void ReleseGearChangePanel(PointerEventData eventData)
    {
        //forse qua andrà aggiunto a tutta questa parte di codice la 
        //condizione if(IsClutchPressed())
        clickLastTouchCoordinates = eventData.position;
        vectorBetweenClickTouches = clickLastTouchCoordinates - clickFirstTouchCoordinates;
        float distance = vectorBetweenClickTouches.magnitude;

        if (coroutineTimeForNeutralGear != null)
        {
            StopCoroutine(coroutineTimeForNeutralGear);
        }

        //if distance is too little, it won't be considered as dragging, but as clicking
        if(distance < 5){
            //the user must keep pressed the change gear panel for about 1s
            if (timeForNeutralGear > 0.95f) 
            {
                particles.SwitchMaterial("green");
                particles.Play();
                clutch.SetGear(ClutchBehaviour.Gear.GearN);
                car.NotifyGearChanged();
            }
            clutch.GetComponent<RectTransform>().localScale = new Vector3(0.1f, 0.3f, 1f);
        }
    }

    //makes the image half-transparent if the clutch is not pressed
    private void ChangeAlphaValue()
    {
        Color color = this.GetComponent<Image>().color;
        if (!clutch.IsClutchPressed())
        {
            color.a = 100 / 255f;
        }
        else
        {
            color.a = 1f;
        }
        this.GetComponent<Image>().color = color;
    }

    //measures the time the user is keeping pressed the change gear panel
    private IEnumerator TimeForNeutralGear()
    {
        timeForNeutralGear = 0f;
        while (timeForNeutralGear < 1f)
        {
            timeForNeutralGear += 0.01f;
            yield return new WaitForSeconds(0.01f);
        }

        yield return null;
    }

    //uses the coordinates of first and last touch of drags to calculate
    //the direction of drag
    private void CalculateDirection()
    {
        direction = lastTouchCoordinates - firstTouchCoordinates;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        angle += 360; 
        angle %= 360; 

        if (angle >= 337.5f || angle < 22.5f)
            directionDragged = "right";
        if (angle >= 22.5f && angle < 67.5f)
            directionDragged = "up-right";
        if (angle >= 67.5f && angle < 112.5f)
            directionDragged = "up";
        if (angle >= 112.5f && angle < 157.5f)
            directionDragged = "up-left";
        if (angle >= 157.5f && angle < 202.5f)
            directionDragged = "left";
        if (angle >= 202.5f && angle < 247.5f)
            directionDragged = "down-left";
        if (angle >= 247.5f && angle < 292.5f)
            directionDragged = "down";
        if (angle >= 292.5f && angle < 337.5f)
            directionDragged = "down-right";
    }

    //according to the current gear and direction of drag, the new gear is set
    private void ChangeGear()
    {
        if (clutch.IsClutchPressed())
        {
            CalculateDirection();
            ClutchBehaviour.Gear currentGear = clutch.GetCurrentGear();

            switch (currentGear)
            {
                case ClutchBehaviour.Gear.Gear1:
                    if (directionDragged == "down")
                    {
                        clutch.SetGear(ClutchBehaviour.Gear.Gear2);
                    }
                    if (directionDragged == "down-right")
                    {
                        clutch.SetGear(ClutchBehaviour.Gear.GearR);
                    }
                    else
                    {
                        print("Non puoi cambiare marcia");
                    }
                    break;

                case ClutchBehaviour.Gear.Gear2:
                    if (directionDragged == "up")
                    {
                        clutch.SetGear(ClutchBehaviour.Gear.Gear1);
                    }
                    if (directionDragged == "up-right")
                    {
                        clutch.SetGear(ClutchBehaviour.Gear.Gear3);
                    }
                    else
                    {
                        print("Non puoi cambiare marcia");
                    }
                    break;

                case ClutchBehaviour.Gear.Gear3:
                    if (directionDragged == "down")
                    {
                        clutch.SetGear(ClutchBehaviour.Gear.Gear4);
                    }
                    if (directionDragged == "down-left")
                    {
                        clutch.SetGear(ClutchBehaviour.Gear.Gear2);
                    }
                    if (directionDragged == "down-right")
                    {
                        CarDestroyed();
                        clutch.SetGear(ClutchBehaviour.Gear.GearR);
                    }
                    else
                    {
                        print("Non puoi cambiare marcia");
                    }
                    break;

                case ClutchBehaviour.Gear.Gear4:
                    if (directionDragged == "up")
                    {
                        clutch.SetGear(ClutchBehaviour.Gear.Gear3);
                    }
                    if (directionDragged == "up-right")
                    {
                        clutch.SetGear(ClutchBehaviour.Gear.Gear5);
                    }
                    if (directionDragged == "up-left")
                    {
                        particles.SwitchMaterial("yellow");
                        particles.Play();
                        clutch.SetGear(ClutchBehaviour.Gear.Gear1);
                    }
                    else
                    {
                        print("Non puoi cambiare marcia");
                    }
                    break;

                case ClutchBehaviour.Gear.Gear5:
                    if (directionDragged == "down")
                    {
                        CarDestroyed();
                        clutch.SetGear(ClutchBehaviour.Gear.GearR);
                    }
                    else if (directionDragged == "down-left")
                    {
                        clutch.SetGear(ClutchBehaviour.Gear.Gear4);
                    }
                    break;

                case ClutchBehaviour.Gear.GearR:
                    if (directionDragged == "up-left")
                    {
                        clutch.SetGear(ClutchBehaviour.Gear.Gear1);
                    }
                    break;

                case ClutchBehaviour.Gear.GearN:
                    if (directionDragged == "up-left")
                    {
                        clutch.SetGear(ClutchBehaviour.Gear.Gear1);
                    }
                    if (directionDragged == "down-left")
                    {
                        clutch.SetGear(ClutchBehaviour.Gear.Gear2);
                    }
                    if (directionDragged == "up")
                    {
                        clutch.SetGear(ClutchBehaviour.Gear.Gear3);
                    }
                    if (directionDragged == "down")
                    {
                        clutch.SetGear(ClutchBehaviour.Gear.Gear4);
                    }
                    if (directionDragged == "up-right")
                    {
                        clutch.SetGear(ClutchBehaviour.Gear.Gear5);
                    }
                    if (directionDragged == "down-right")
                    {
                        clutch.SetGear(ClutchBehaviour.Gear.GearR);
                    }
                    break;

                default:
                    break;
            }
            
            clutch.GearHasBeenChanged();
        }
        else
        {
            ClutchNotPressed();
        }
    }

    //adds the error the player made
    public void ClutchNotPressed()
    {
        particles.SwitchMaterial("red");
        particles.Play();

        if (!currentLevel.IsMistakeAlreadyAdded("You didn't press the clutch!"))
        {
            currentLevel.AddMistake("You didn't press the clutch!");
            tempMistakes.Add("You didn't press the clutch!");
        }
    }

    //adds the error the player made, decreases the score and the player loses
    private void CarDestroyed()
    { 
        particles.SwitchMaterial("red");
        particles.Play();
        
        if(!currentLevel.IsMistakeAlreadyAdded("You destroyed the car!"))
        {
            currentLevel.AddMistake("You destroyed the car!");
            tempMistakes.Add("You destroyed the car!");
        }
        player.Lose();

        int tempScore = player.GetScore();
        player.SetScore(tempScore - 10);
    }

    private void Initialization()
    {
        saveManager = SaveManager.GetSaveManagerInstance();
        saveState = saveManager.GetSaveState();
        menu = Menu.GetMenuInstance();
        currentLevel = saveState.GetListOfLevels()[menu.GetCurrentLevel().GetId() - 1];
        player = PlayerController.GetPlayerControllerInstance();
        clutch = ClutchBehaviour.GetClutchBehaviourInstance();
        car = Car.GetCarInstance();
        particles = ParticlesManagement.GetParticlesInstance();
        tempMistakes = player.GetTempMistakes();
    }

    public static ChangeGearPanelBehaviour GetChangeGearPanelBehaviourInstance()
    {
        return changeGear;
    }
}
