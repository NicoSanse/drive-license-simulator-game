using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//this class is used by the button that turns on and off the car
//and just shows whether the car is on or off

public class CurrentCarStateOnOffButtonBehaviour : MonoBehaviour
{
    private Image ButtonImage;
    private TMP_Text TMPtext;
    private static CurrentCarStateOnOffButtonBehaviour currentCarStateOnOffButtonBehaviour;

    void Awake()
    {
        currentCarStateOnOffButtonBehaviour = this;
    }
    void Start()
    {
        ButtonImage = GetComponent<Image>();
        TMPtext = GetComponentInChildren<TMP_Text>();
    }

    void Update()
    {
        
    }

    //this method is called by GUIManager when the button is pressed
    public void DarkenButton()
    {
        MakeTestAppear("OFF");
        StartCoroutine(MakeTextDisappear());
        StartCoroutine(MakeButtonBlack());
    }

    //this method is called by GUIManager when the button is pressed
    public void LightenButton()
    {
        MakeTestAppear("ON");
        StartCoroutine(MakeTextDisappear());
        StartCoroutine(MakeButtonRed());
    }

    private IEnumerator MakeButtonBlack()
    {
        yield return null;
        ButtonImage.color = new Color(0, 0, 0);
    }

    private IEnumerator MakeButtonRed()
    {
        yield return null;
        ButtonImage.color = new Color(255, 0, 0);
    }

    private IEnumerator MakeTextDisappear()
    {
        yield return new WaitForSeconds(1.2f);
        /*
        Color tempColor = TMPtext.color;
        while(tempColor.a != 0)
        {
            tempColor = new Color(tempColor.r, tempColor.g, tempColor.b, tempColor.a - 5);
            TMPtext.color = tempColor;
            yield return new WaitForSeconds(0.05f);
        }
        */
        TMPtext.color = new Color(TMPtext.color.r, TMPtext.color.g, TMPtext.color.b, 0f);
    }

    private void MakeTestAppear(string text)
    {
        TMPtext.text = text;

        Color tempColor = TMPtext.color;
        TMPtext.color = new Color(tempColor.r, tempColor.g, tempColor.b, 255f);
    }

    public static CurrentCarStateOnOffButtonBehaviour GetCurrentCarStateOnOffButtonBehaviourInstance()
    {
        return currentCarStateOnOffButtonBehaviour;
    }
}
