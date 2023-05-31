using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftArrowBehaviour : MonoBehaviour
{
    public static LeftArrowBehaviour leftArrow;
    private bool leftArrowOn;
    private Color imageColor;
    private Coroutine togglingArrows;

    void Awake()
    {
        leftArrow = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        leftArrowOn = false;
        imageColor = GetComponent<Image>().color;
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

    public void TurnLeftArrowOnOrOff() 
    {
        if (leftArrowOn)
        {
            StopCoroutine(togglingArrows);

            imageColor.a = 100 / 255f;
            GetComponent<Image>().color = imageColor;

            print("Left Arrows Off");
            SetLeftArrowOn(false);
        }
        else
        {
            togglingArrows = StartCoroutine(ToggleArrows());
            print("Left Arrows On");
            SetLeftArrowOn(true);
        }
    }

    private IEnumerator ToggleArrows()
    {
        while (true)
        {
            imageColor.a = 1f;
            GetComponent<Image>().color = imageColor;
            yield return new WaitForSeconds(0.5f);
            imageColor.a = 100 / 255f;
            GetComponent<Image>().color = imageColor;
            yield return new WaitForSeconds(0.5f);
        }

    }
}
