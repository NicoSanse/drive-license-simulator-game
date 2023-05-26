using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftArrowBehaviour : MonoBehaviour
{
    public static LeftArrowBehaviour leftArrow;
    private bool leftArrowOn;

    void Awake()
    {
        leftArrow = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        leftArrowOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLeftArrowOn(bool arrow)
    {
        leftArrowOn = arrow;
    }

    public bool IsLeftArrowOn()
    {
        return leftArrowOn;
    }

    public void TurnLeftArrowOn()
    {
        print("Left Arrows On");
        SetLeftArrowOn(true);
    }

    public void TurnLeftArrowOff(){
        print("Left Arrows Off");
        SetLeftArrowOn(false);
    }
}
