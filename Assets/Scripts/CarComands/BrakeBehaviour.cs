using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrakeBehaviour : MonoBehaviour
{
    public static BrakeBehaviour brake;
    private float deceleration;
    private Coroutine coroutineBrake;
    private bool isBrakePressed;

    void Awake()
    {
        brake = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        isBrakePressed = false;
        deceleration = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setDeceleration(float value) {
        deceleration = value;
    }

    public float getDeceleration() {
        return deceleration;
    }

    public void BrakeIsPressed() {
        isBrakePressed = true;
        coroutineBrake = StartCoroutine(decelerate());
    }

    public void BrakeIsReleased() {
        isBrakePressed = false;
        StopCoroutine(coroutineBrake);
    }

    private IEnumerator decelerate() { 
        while (deceleration > -800f) {
            print("deceleration: " + deceleration);
            deceleration -= 3.5f;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
