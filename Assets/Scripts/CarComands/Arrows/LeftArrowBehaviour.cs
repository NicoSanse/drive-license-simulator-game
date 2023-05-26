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

    public void setLeftArrowOn(bool arrow)
    {
        leftArrowOn = arrow;
    }

    public bool isLeftArrowOn()
    {
        return leftArrowOn;
    }

    public void turnLeftArrowOn()
    {
        print("Left Arrows On");
        setLeftArrowOn(true);
    }

    public void turnLeftArrowOff(){
        print("Left Arrows Off");
        setLeftArrowOn(false);
    }
}
