using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightArrowBehaviour : MonoBehaviour
{
    public static RightArrowBehaviour rightArrow;
    private bool rightArrowOn;

    void Awake()
    {
        rightArrow = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        rightArrowOn = false;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setRightArrowOn(bool arrow)
    {
        rightArrowOn = arrow;
    }  

    public bool isRightArrowOn()
    {
        return rightArrowOn;
    }

    public void turnRightArrowOn()
    {
        print("Right Arrows On");
        setRightArrowOn(true);
    }

    public void turnRightArrowOff(){
        print("Right Arrows Off");
        setRightArrowOn(false);
    }
}
