using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrakeBehaviour : MonoBehaviour
{
    public static BrakeBehaviour brake;
    private float deceleration;
    private Coroutine coroutineBrake;
    private bool brakePressed;

    void Awake()
    {
        brake = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        brakePressed = false;
        deceleration = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(CommonBehaviours.ChangeScale(brakePressed, GetComponent<RectTransform>()));
    }

    public void SetDeceleration(float value) 
    {
        deceleration = value;
    }

    public float GetDeceleration() 
    {
        return deceleration;
    }

    public void BrakeIsPressed() 
    {
        brakePressed = true;
        coroutineBrake = StartCoroutine(Decelerate());
    }

    public void BrakeIsReleased() 
    {
        brakePressed = false;
        StopCoroutine(coroutineBrake);
    }

    private IEnumerator Decelerate() 
    { 
        while (deceleration > -800f) 
        {
            print("deceleration: " + deceleration);
            deceleration -= 7f;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
