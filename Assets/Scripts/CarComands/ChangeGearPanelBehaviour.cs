using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeGearPanelBehaviour : MonoBehaviour
{
    //private Vector2 previousPosition;
    public static ChangeGearPanelBehaviour changeGear;
    private Vector2 firstTouchCoordinates;
    private Vector2 lastTouchCoordinates;
    private string directionDragged;
    private Coroutine coroutineTimeForNeutralGear;
    private float timeForNeutralGear;

    void Awake()
    {
        changeGear = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    

    private void ChangeGear() 
    {
        //if (ClutchBehaviour.clutch.IsClutchPressed()
        //eccetera


        CalculateDirection();
        print(directionDragged);
        ClutchBehaviour.Gear currentGear = ClutchBehaviour.clutch.GetCurrentGear();

        switch (currentGear)
        { 
            case ClutchBehaviour.Gear.Gear1:
                if (directionDragged == "down") 
                {
                    ClutchBehaviour.clutch.SetGear(ClutchBehaviour.Gear.Gear2);
                }
                if(directionDragged == "down-right")
                {
                    ClutchBehaviour.clutch.SetGear(ClutchBehaviour.Gear.GearR);
                }
                else
                {
                    print("Non puoi cambiare marcia");
                }
                break;
            
            case ClutchBehaviour.Gear.Gear2:
                if (directionDragged == "up")
                {
                    ClutchBehaviour.clutch.SetGear(ClutchBehaviour.Gear.Gear1);
                }
                if (directionDragged == "up-right")
                {
                    ClutchBehaviour.clutch.SetGear(ClutchBehaviour.Gear.Gear3);
                }
                else
                {
                    print("Non puoi cambiare marcia");
                }
                break;

            case ClutchBehaviour.Gear.Gear3:
                if (directionDragged == "down")
                {
                    ClutchBehaviour.clutch.SetGear(ClutchBehaviour.Gear.Gear4);
                }
                if (directionDragged == "down-left")
                {
                    ClutchBehaviour.clutch.SetGear(ClutchBehaviour.Gear.Gear2);
                }
                if (directionDragged == "down-right")
                {
                    //insommma meh
                    ClutchBehaviour.clutch.SetGear(ClutchBehaviour.Gear.GearR);
                }
                else
                {
                    print("Non puoi cambiare marcia");
                }
                break;

            case ClutchBehaviour.Gear.Gear4:
                if (directionDragged == "up")
                {
                    ClutchBehaviour.clutch.SetGear(ClutchBehaviour.Gear.Gear3);
                }
                if (directionDragged == "up-right")
                {
                    ClutchBehaviour.clutch.SetGear(ClutchBehaviour.Gear.Gear5);
                }
                if (directionDragged == "up-left")
                {
                    //insommma meh
                    ClutchBehaviour.clutch.SetGear(ClutchBehaviour.Gear.Gear1);
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
                    ClutchBehaviour.clutch.SetGear(ClutchBehaviour.Gear.GearR);
                }
                else if (directionDragged == "down-left")
                {
                    ClutchBehaviour.clutch.SetGear(ClutchBehaviour.Gear.Gear4);
                }
                break;

            case ClutchBehaviour.Gear.GearR:
                if (directionDragged == "up-left")
                {
                    ClutchBehaviour.clutch.SetGear(ClutchBehaviour.Gear.Gear1);
                }
                break;

            case ClutchBehaviour.Gear.GearN:
                if (directionDragged == "up-left")
                {
                    ClutchBehaviour.clutch.SetGear(ClutchBehaviour.Gear.Gear1);
                }
                if (directionDragged == "dwon-left")
                {
                    ClutchBehaviour.clutch.SetGear(ClutchBehaviour.Gear.Gear2);
                }
                if (directionDragged == "up")
                {
                    ClutchBehaviour.clutch.SetGear(ClutchBehaviour.Gear.Gear3);
                }
                if (directionDragged == "down")
                {
                    ClutchBehaviour.clutch.SetGear(ClutchBehaviour.Gear.Gear4);
                }
                if (directionDragged == "up-right")
                {
                    ClutchBehaviour.clutch.SetGear(ClutchBehaviour.Gear.Gear5);
                }
                if (directionDragged == "down-right")
                {
                    ClutchBehaviour.clutch.SetGear(ClutchBehaviour.Gear.GearR);
                }
                break;
            
            default:
                print("boh");
                break;
        }
        ClutchBehaviour.clutch.GearHasBeenChanged();
    }

    public void TakeFirstTouchCoordinates(PointerEventData eventData) 
    {
        firstTouchCoordinates = eventData.position;
    }

    public void TakeLastTouchCoordinates(PointerEventData eventData) 
    {
        lastTouchCoordinates = eventData.position;
        ChangeGear();
    }

    private void CalculateDirection() 
    {
        Vector2 direction = lastTouchCoordinates - firstTouchCoordinates;
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

    public void NeutralGear()
    {
        //if (ClutchBehaviour.clutch.IsClutchPressed())
        //{
            coroutineTimeForNeutralGear = StartCoroutine(TimeForNeutralGear());
        //}
        //else
        //{
          //  print("Frizione non premuta");
        //}
    }

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

    public void ReleseGearChangePanel()
    {
        StopCoroutine(coroutineTimeForNeutralGear);

        if (timeForNeutralGear > 0.95f) 
        {
            print("switching to N");
            ClutchBehaviour.clutch.SetGear(ClutchBehaviour.Gear.GearN);
            PlayerController.player.NotifyGearChanged();
        }
        else
        {
            print("GearHasBeenChanged triggered from this script now commented");
            //forse si potrà decommentare quando potrò testare come si deve il gioco su un telefono
            //ClutchBehaviour.clutch.GearHasBeenChanged();
        }
    }
}
