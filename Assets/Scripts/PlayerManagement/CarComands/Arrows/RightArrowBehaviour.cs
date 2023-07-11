using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightArrowBehaviour : MonoBehaviour
{
    [SerializeField] Light rightFrontArrowLight;
    [SerializeField] Light rightBackArrowLight;
    public static RightArrowBehaviour rightArrow;
    private bool rightArrowOn;
    private Color imageColor;
    private Coroutine togglingArrows;

    void Awake()
    {
        rightArrow = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        rightArrowOn = false;
        imageColor = GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetRightArrowOn()
    {
        rightArrowOn = true;
        togglingArrows = StartCoroutine(ToggleArrows());
    }

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

    //checks whether the arrow is on or off and according to that
    //turns the arrow off or starts the coroutine to make it toogle
    public void TurnRightArrowOnOrOff()
    {
        //if the car is on you can set arrows
        if (Car.car.GetState())
        {
            //turn off the other arrow if its on
            if(LeftArrowBehaviour.leftArrow.IsLeftArrowOn())
            {
                LeftArrowBehaviour.leftArrow.SetLeftArrowOff();
            }
            if (rightArrowOn)
            {
                SetRightArrowOff();
            }
            else if (!LeftArrowBehaviour.leftArrow.IsLeftArrowOn())
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

}
