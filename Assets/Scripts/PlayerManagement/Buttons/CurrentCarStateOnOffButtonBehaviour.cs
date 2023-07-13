using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CurrentCarStateOnOffButtonBehaviour : MonoBehaviour
{
    private Color tempColor;
    public static CurrentCarStateOnOffButtonBehaviour currentCarStateOnOffButtonBehaviour;

    void Awake()
    {
        currentCarStateOnOffButtonBehaviour = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DarkenButton()
    {
        Color tempColor = GetComponentInChildren<TMP_Text>().color;
        tempColor.a = 255f;
        GetComponentInChildren<TMP_Text>().color = tempColor;
        GetComponentInChildren<TMP_Text>().text = "OFF";
        GetComponent<Image>().color = new Color(0, 0, 0);
        StartCoroutine(MakeTextDisappear(GetComponentInChildren<TMP_Text>().color));
    }

    public void LightenButton()
    {
        Color tempColor = GetComponentInChildren<TMP_Text>().color;
        tempColor.a = 255f;
        GetComponentInChildren<TMP_Text>().color = tempColor;
        GetComponentInChildren<TMP_Text>().text = "ON";
        GetComponent<Image>().color = new Color(255, 255, 255);
        StartCoroutine(MakeTextDisappear(GetComponentInChildren<TMP_Text>().color));
    }

    private IEnumerator MakeTextDisappear(Color tempColor)
    {
        while(tempColor.a != 0)
        {
            tempColor.a -= 50f;
            yield return new WaitForSeconds(1f);
        }
        GetComponentInChildren<TMP_Text>().color = tempColor;
    }
}
