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
        CalculateDirection();
        print(directionDragged);
        
        
        if (directionDragged == "up")
        {
            if (ClutchBehaviour.clutch.GetCurrentGear() != ClutchBehaviour.Gear.GearN &&
                ClutchBehaviour.clutch.GetCurrentGear() != ClutchBehaviour.Gear.GearR &&
                ClutchBehaviour.clutch.GetCurrentGear() != ClutchBehaviour.Gear.Gear5) 
                {
                    ClutchBehaviour.clutch.SetGear(ClutchBehaviour.clutch.GetCurrentGear() + 1);
                    print(ClutchBehaviour.clutch.GetCurrentGear());
                }
        }

        if(directionDragged == "down")
        {
            ClutchBehaviour.clutch.SetGear(ClutchBehaviour.clutch.GetCurrentGear() - 1);
            print(ClutchBehaviour.clutch.GetCurrentGear());
        }

        if (directionDragged == "left")
        {
            ClutchBehaviour.clutch.SetGear(ClutchBehaviour.Gear.GearR);
            print(ClutchBehaviour.clutch.GetCurrentGear());
        }

        if (directionDragged == "right")
        {
            ClutchBehaviour.clutch.SetGear(ClutchBehaviour.Gear.GearN);
            print(ClutchBehaviour.clutch.GetCurrentGear());
        }
        
        
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

        //if (ClutchBehaviour.clutch.IsClutchPressed()) 
        //{ 

        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                directionDragged = "right";
            }
            else if (direction.x < 0)
            {
                directionDragged = "left";
            }
        }
        else
        {
            //il seguente comportamento si può revisionare
            if (direction.y > 0)
            {
                directionDragged = "up";
            }
            else if (direction.y < 0)
            {
                directionDragged = "down";
            }
        }
        //}
        //else
        //{
        //    print("Frizione non premuta");
        //}
    }
}
