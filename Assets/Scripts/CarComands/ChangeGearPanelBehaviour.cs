using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeGearPanelBehaviour : MonoBehaviour
{
    //private Vector2 previousPosition;
    public static ChangeGearPanelBehaviour changeGear;

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
    /*

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 currentPosition = eventData.position;
        Vector2 direction = currentPosition - previousPosition;

        //if (ClutchBehaviour.clutch.IsClutchPressed()) 
        //{ 

        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
            }
            else if (direction.x < 0)
            {
            }
        }
        else
        {
            //il seguente comportamento si può revisionare
            if (direction.y > 0)
            {
            }
            else if (direction.y < 0)
            {
            }
        }
    //}
    //else
    //{
    //    Debug.Log("Frizione non premuta");
    //}

    previousPosition = currentPosition;
    }

    */

    public void ChangeGear() 
    {
        CalculateDirection();
        /*
        if (directionDragged == "up") 
        {
            ClutchBehaviour.clutch.SetGear((int) ClutchBehaviour.clutch.GetCurrentGear() + 1);
        }
        else if (directionDragged == "down")
        {
            ClutchBehaviour.clutch.SetGear((int) ClutchBehaviour.clutch.GetCurrentGear() - 1);
        }
        else if (directionDragged == "left")
        {
            ClutchBehaviour.clutch.SetGear((int) ClutchBehaviour.Gears.GearR);
        }
        else if (directionDragged == "right")
        {
            ClutchBehaviour.clutch.SetGear((int) ClutchBehaviour.Gears.GearN);
        }
        */
    }

    public void GetFirstTouchCoordinates() 
    {
        //immagazzinare coordinate
    }

    public void GetLastTouchCoordinates() 
    {
        //immagazzinare coordinate
    }

    public void CalculateDirection() 
    {
        //calcolare direzione
    }
}
