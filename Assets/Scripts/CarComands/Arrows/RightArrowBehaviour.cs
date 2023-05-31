using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightArrowBehaviour : MonoBehaviour
{
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

    public void SetRightArrowOn(bool arrow)
    {
        rightArrowOn = arrow;
    }  

    public bool IsRightArrowOn()
    {
        return rightArrowOn;
    }

    public void TurnRightArrowOnOrOff()
    {
        if (rightArrowOn)
        {
            StopCoroutine(togglingArrows);

            imageColor.a = 100 / 255f;
            GetComponent<Image>().color = imageColor;

            print("Right Arrows Off");
            SetRightArrowOn(false);
        }
        else
        {
            togglingArrows = StartCoroutine(ToggleArrows());
            print("Right Arrows On");
            SetRightArrowOn(true);
        }
    }

    private IEnumerator ToggleArrows()
    { 
        while (true)
        {
            imageColor.a = 100 / 255f;
            GetComponent<Image>().color = imageColor;
            yield return new WaitForSeconds(0.5f);
            imageColor.a = 255 / 255f;
            GetComponent<Image>().color = imageColor;
            yield return new WaitForSeconds(0.5f);
        }
    }

}
