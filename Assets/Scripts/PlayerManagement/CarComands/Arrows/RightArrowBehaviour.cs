using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//this class models the right arrow
public class RightArrowBehaviour : MonoBehaviour
{
    [SerializeField] private Light rightFrontArrowLight;
    [SerializeField] private Light rightBackArrowLight;
    private static RightArrowBehaviour rightArrow;
    private bool rightArrowOn;
    private Color imageColor;
    private Coroutine togglingArrows;
    private LeftArrowBehaviour leftArrow;
    private Car car;

    void Awake()
    {
        rightArrow = this;
    }
    void Start()
    {
        rightArrowOn = false;
        imageColor = GetComponent<Image>().color;

        leftArrow = LeftArrowBehaviour.GetLeftArrowBehaviourInstance();
        car = Car.GetCarInstance();
    }

    void Update()
    {
        
    }

    //updates the state of the arrow and starts the "animation"
    public void SetRightArrowOn()
    {
        rightArrowOn = true;
        togglingArrows = StartCoroutine(ToggleArrows());
    }

    //updates the state of the arrow and stops the "animation"
    public void SetRightArrowOff()
    {
        rightArrowOn = false;
        if (togglingArrows != null)
        {
            StopCoroutine(togglingArrows);
        }

        rightBackArrowLight.intensity = 0;
        rightFrontArrowLight.intensity = 0;
        imageColor.a = 100 / 255f;
        GetComponent<Image>().color = imageColor;
    }

    public bool IsRightArrowOn()
    {
        return rightArrowOn;
    }

    //turns the arrow off or on
    public void TurnRightArrowOnOrOff()
    {
        //if the car is on you can set arrows
        if (car.IsOn())
        {
            //turn off the other arrow if its on
            if(leftArrow.IsLeftArrowOn())
            {
                leftArrow.SetLeftArrowOff();
            }
            if (rightArrowOn)
            {
                SetRightArrowOff();
            }
            else if (!leftArrow.IsLeftArrowOn())
            {
                SetRightArrowOn();
            }
        }
    }

    //toggles the arrows on and off with 0.5 seconds between
    private IEnumerator ToggleArrows()
    { 
        while (true)
        {
            imageColor.a = 100 / 255f;
            GetComponent<Image>().color = imageColor;
            rightBackArrowLight.intensity = 20;
            rightFrontArrowLight.intensity = 20;
            yield return new WaitForSeconds(0.5f);
            rightBackArrowLight.intensity = 0;
            rightFrontArrowLight.intensity = 0;
            imageColor.a = 255 / 255f;
            GetComponent<Image>().color = imageColor;
            yield return new WaitForSeconds(0.5f);
        }
    }

    public static RightArrowBehaviour GetRightArrowBehaviourInstance()
    {
        return rightArrow;
    }

}
