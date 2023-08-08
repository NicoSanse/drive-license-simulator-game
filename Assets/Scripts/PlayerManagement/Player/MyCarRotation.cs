using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCarRotation : MonoBehaviour
{
    public static MyCarRotation myCarRotation;
    private PlayerController player;
    private LeftArrowBehaviour leftArrow;
    private RightArrowBehaviour rightArrow;
    private float rotation;
    private float sensibility;
    
    void Awake()
    {
        myCarRotation = this;
    }
    void Start()
    {
        player = PlayerController.GetPlayerControllerInstance();
        leftArrow = LeftArrowBehaviour.GetLeftArrowBehaviourInstance();
        rightArrow = RightArrowBehaviour.GetRightArrowBehaviourInstance();
        rotation = 0f;
        sensibility = 2f;
    }

    void Update()
    {
        MeasureRotation();
        CheckArrowOn();
    }

    //the rotation is calculated through accelerometer of the device
    private void MeasureRotation()
    {
        rotation = Input.acceleration.x * sensibility;
        Mathf.Clamp(rotation, -0.9f, 0.9f);
        if(rotation > -0.2f && rotation < 0.2f) rotation = 0f;
    }

    //the player must set the arrow on before turning
    private void CheckArrowOn()
    {
        if (rotation > 0.35f && !rightArrow.IsRightArrowOn())
        { 
            player.ArrowNotSetMistake();
        }
        if (rotation < -0.35f && !leftArrow.IsLeftArrowOn())
        {
            player.ArrowNotSetMistake();
        }
    }

    public float GetValue()
    {
        return rotation;
    }
}
