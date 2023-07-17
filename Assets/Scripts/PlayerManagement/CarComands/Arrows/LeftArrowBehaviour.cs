using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftArrowBehaviour : MonoBehaviour
{
    [SerializeField] private Light leftFrontArrowLight;
    [SerializeField] private Light leftBackArrowLight;
    private static LeftArrowBehaviour leftArrow;
    private bool leftArrowOn;
    private Color imageColor;
    private Coroutine togglingArrows;
    private RightArrowBehaviour rightArrow;
    private Car car;

    void Awake()
    {
        leftArrow = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        leftArrowOn = false;
        imageColor = GetComponent<Image>().color;

        rightArrow = RightArrowBehaviour.GetRightArrowBehaviourInstance();
        car = Car.GetCarInstance();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLeftArrowOn()
    {
        leftArrowOn = true;
        togglingArrows = StartCoroutine(ToggleArrows());
    }

    public void SetLeftArrowOff()
    {
        leftArrowOn = false;
        if (togglingArrows != null)
        {
            StopCoroutine(togglingArrows);
        }

        leftBackArrowLight.intensity = 0;
        leftFrontArrowLight.intensity = 0;
        imageColor.a = 100 / 255f;
        GetComponent<Image>().color = imageColor;
    }

    public bool IsLeftArrowOn()
    {
        return leftArrowOn;
    }

    //checks whether the arrow is on or off and according to that
    //turns the arrow off or starts the coroutine to make it toogle
    public void TurnLeftArrowOnOrOff() 
    {
        //if the car is on you can set arrows
        if (car.IsOn())
        {
            //turn off the other arrow if its on
            if(rightArrow.IsRightArrowOn())
            {
                rightArrow.SetRightArrowOff();
            }
            if (leftArrowOn)
            {
                SetLeftArrowOff();
            }
            else if (!rightArrow.IsRightArrowOn())
            {
                SetLeftArrowOn();
            }
        }
    }


    //toggle the arrows on and off with 0.5 seconds between
    private IEnumerator ToggleArrows()
    {
        while (true)
        {
            imageColor.a = 1f;
            leftBackArrowLight.intensity = 20;
            leftFrontArrowLight.intensity = 20;
            GetComponent<Image>().color = imageColor;
            yield return new WaitForSeconds(0.5f);
            leftBackArrowLight.intensity = 0;
            leftFrontArrowLight.intensity = 0;
            imageColor.a = 100 / 255f;
            GetComponent<Image>().color = imageColor;
            yield return new WaitForSeconds(0.5f);
        }
    }

    public static LeftArrowBehaviour GetLeftArrowBehaviourInstance()
    {
        return leftArrow;
    }
}
