using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerationBehaviour : MonoBehaviour
{

    public static AccelerationBehaviour accelerator;
    private float acceleration;
    private Coroutine coroutineAccelerate;
    private bool acceleratorPressed;

    void Awake()
    {
        accelerator = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        acceleratorPressed = false;
        acceleration = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(CommonBehaviours.ChangeScale(acceleratorPressed, GetComponent<RectTransform>()));
    }

    public void SetAcceleration(float value) 
    {
        acceleration = value;
    }

    public float GetAcceleration() 
    {
        return acceleration;
    }

    private void SetAcceleratorPressed(bool value) 
    {
        acceleratorPressed = value;
    }

    public bool IsAcceleratorPressed() 
    {
        return acceleratorPressed;
    }

    //triggered by GUIManager class, starts the coroutine to increase the 
    //acceleration value
    public void AcceleratorIsPressed() 
    {
        acceleratorPressed = true;
        coroutineAccelerate = StartCoroutine(Accelerate());
    }

    //triggered by GUIManager class, stops the coroutine
    public void AcceleratorIsReleased()
    {
        acceleratorPressed = false;
        StopCoroutine(coroutineAccelerate);
    }

    //increases the acceleration value
    private IEnumerator Accelerate() 
    {
        while (acceleration < 500f) {
            print("acceleration: " + acceleration);
            acceleration += 3.5f;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
