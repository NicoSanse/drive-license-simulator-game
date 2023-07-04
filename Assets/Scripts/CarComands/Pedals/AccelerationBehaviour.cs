using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerationBehaviour : MonoBehaviour
{

    public static AccelerationBehaviour accelerator;
    private float acceleration;
    private bool acceleratorPressed;
    private float sensibility = 3f;

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
        Accelerate();
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
    }

    //triggered by GUIManager class, stops the coroutine
    public void AcceleratorIsReleased()
    {
        acceleratorPressed = false;
    }

    //increases the acceleration value
    private void Accelerate() 
    {
        if (acceleratorPressed)
        {
            acceleration += Time.deltaTime * sensibility;
        }
        else
        {
            acceleration -= Time.deltaTime * sensibility;
        }
        acceleration = Mathf.Clamp(acceleration, 0, 1);
    }
}
