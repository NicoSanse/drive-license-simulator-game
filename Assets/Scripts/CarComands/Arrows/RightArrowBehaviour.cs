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

    public void SetRightArrowOn(bool arrow)
    {
        rightArrowOn = arrow;
    }  

    public bool IsRightArrowOn()
    {
        return rightArrowOn;
    }

    public void TurnRightArrowOn()
    {
        print("Right Arrows On");
        SetRightArrowOn(true);
    }

    public void TurnRightArrowOff(){
        print("Right Arrows Off");
        SetRightArrowOn(false);
    }
}
