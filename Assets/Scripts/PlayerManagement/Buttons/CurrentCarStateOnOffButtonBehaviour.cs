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
    private Color ButtonColor;
    private TMP_Text TMPtext;
    private Color textColor;
    private static CurrentCarStateOnOffButtonBehaviour currentCarStateOnOffButtonBehaviour;

    void Awake()
    {
        currentCarStateOnOffButtonBehaviour = this;
    }
    void Start()
    {
        ButtonImage = GetComponent<Image>();
        ButtonColor = ButtonImage.color;
        TMPtext = GetComponentInChildren<TMP_Text>();
        textColor = TMPtext.color;
    }

    void Update()
    {
        
    }

    //this method is called by GUIManager when the button to turn off the engine is pressed
    public void DarkenButton()
    {
        MakeTextAppear("OFF");
        MakeButtonBlack();
        StartCoroutine(MakeTextDisappear());
    }

    //this method is called by GUIManager when the button to turn on the engine is pressed
    public void LightenButton()
    {
        MakeTextAppear("ON");
        MakeButtonRed();
        StartCoroutine(MakeTextDisappear());
    }

    //called when the car turns off for going too slow
    public void Off()
    {
        MakeTextAppear("OFF");
        MakeButtonBlack();
    }

    private void MakeButtonBlack()
    {
        ButtonColor.r = 0f;
        ButtonColor.g = 0f;
        ButtonColor.b = 0f;
        ButtonImage.color = ButtonColor;
    }

    private void MakeButtonRed()
    {
        ButtonColor.r = 255f;
        ButtonColor.g = 0f;
        ButtonColor.b = 0f;
        ButtonImage.color = ButtonColor;
    }

    private IEnumerator MakeTextDisappear()
    {
        yield return new WaitForSeconds(1.0f);
        
        textColor.a = 0f;
        TMPtext.color = textColor;
    }

    private void MakeTextAppear(string text)
    {
        TMPtext.text = text;

        textColor.a = 255f;
        TMPtext.color = textColor;
    }

    public static CurrentCarStateOnOffButtonBehaviour GetCurrentCarStateOnOffButtonBehaviourInstance()
    {
        return currentCarStateOnOffButtonBehaviour;
    }
}
