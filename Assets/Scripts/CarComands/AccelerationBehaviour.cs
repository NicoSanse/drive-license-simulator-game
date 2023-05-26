using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerationBehaviour : MonoBehaviour
{

    public static AccelerationBehaviour accelerator;
    private float acceleration;
    private Coroutine coroutineAccelerate;
    private bool isAcceleratorPressed;

    void Awake()
    {
        accelerator = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        isAcceleratorPressed = false;
        acceleration = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setAcceleration(float value) 
    {
        acceleration = value;
    }

    public float getAcceleration() 
    {
        return acceleration;
    }

    public void AcceleratorIsPressed() 
    {
        isAcceleratorPressed = true;
        coroutineAccelerate = StartCoroutine(accelerate());
    }

    public void AcceleratorIsReleased()
    {
        isAcceleratorPressed = false;
        StopCoroutine(coroutineAccelerate);
    }

    private IEnumerator accelerate() 
    {
        while (acceleration < 500f) {
            print("acceleration: " + acceleration);
            acceleration += 1.5f;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
