using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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

    void Awake()
    {
        changeGear = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        clutch = ClutchBehaviour.GetClutchBehaviourInstance();
        car = Car.GetCarInstance();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeAlphaValue();
    }
    

    //triggered by GUIManager class, stores the coordinates of first
    //touch of drag
    public void TakeFirstTouchCoordinates(PointerEventData eventData) 
    {
        firstTouchCoordinates = eventData.position;
    }

    //triggered by GUIManager class, stores the coordinates of last
    //touch of drag and starts ChangeGear method
    public void TakeLastTouchCoordinates(PointerEventData eventData) 
    {
        lastTouchCoordinates = eventData.position;
        ChangeGear();
    }
    
    //triggered by GUIManager class, stores the coordinates of first click and starts 
    //the coroutine that finds how long the user is keeping pressed the change panel
    public void NeutralGear(PointerEventData eventData)
    {
        clickFirstTouchCoordinates = eventData.position;
        //if (clutch.IsClutchPressed())
        //{
            coroutineTimeForNeutralGear = StartCoroutine(TimeForNeutralGear());
        //}
        //else
        //{
          //  print("Frizione non premuta");
        //}
    }

    //triggered buy GUIManager class, stores the coordinates of last click and finds
    //the distance between the clicks
    //this is necessary since the event trigger gets confused by multiple events
    //then stops the previous coroutine 
    //in the end finds whether the user wants to set neutral gear or not
    public void ReleseGearChangePanel(PointerEventData eventData)
    {
        //forse qua andrà aggiunto a tutta questa parte di codice la 
        //condizione if(IsClutchPressed())
        clickLastTouchCoordinates = eventData.position;
        vectorBetweenClickTouches = clickLastTouchCoordinates - clickFirstTouchCoordinates;
        float distance = vectorBetweenClickTouches.magnitude;

        StopCoroutine(coroutineTimeForNeutralGear);

        if(distance < 5){
            if (timeForNeutralGear > 0.95f) 
            {
                clutch.SetGear(ClutchBehaviour.Gear.GearN);
                car.NotifyGearChanged();
            }
            //fare il resize, preferibilmente nel secondo modo
            clutch.GetComponent<RectTransform>().localScale = new Vector3(0.1f, 0.3f, 1f);
            //StartCoroutine(CommonBehaviours.ChangeScale(!clutch.IsClutchPressed(), clutch.GetComponent<RectTransform>()));
        }
    }

    //makes the alpha value equal to 100 if the clutch is not pressed
    //and to 255 if the clutch is pressed
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

    //finds how long the user is keeping pressed the change panel
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
        angle += 360; // Garantisci che l'angolo sia positivo
        angle %= 360; // Riduci l'angolo a un valore tra 0 e 359

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

    //according to the current gear sets the new gear
    private void ChangeGear()
    {
        //if (clutch.IsClutchPressed())
        //eccetera

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
                    //insommma meh
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
                    //insommma meh
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
                    //insommma meh
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
                if (directionDragged == "dwon-left")
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
                print("boh");
                break;
        }
        clutch.GearHasBeenChanged();
    }

    public static ChangeGearPanelBehaviour GetChangeGearPanelBehaviourInstance()
    {
        return changeGear;
    }
}
