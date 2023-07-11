using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrakeBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject brakeLight;
    public static BrakeBehaviour brake;
    private float deceleration;
    private bool brakePressed;
    private float sensibility = 3f;

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
        Decelerate();
        BrakesLight();
    }

    private void BrakesLight()
    { 
        if (brakePressed)
        {
        }
        else
        {
        }
    }


    public void SetDeceleration(float value) 
    {
        deceleration = value;
    }

    public float GetDeceleration() 
    {
        return deceleration;
    }

    //triggered by GUIManager class, starts the coroutine to 
    //increase the decelerationb value
    public void BrakeIsPressed() 
    {
        brakePressed = true;
    }

    //triggered by GUIManager class, stops the coroutine
    public void BrakeIsReleased() 
    {
        brakePressed = false;
    }

    //increases(decreases actually) the deceleration value
    private void Decelerate() 
    {
        if (brakePressed)
        {
            deceleration += Time.deltaTime * sensibility;
        }
        else
        {
            deceleration -= Time.deltaTime * sensibility;
        }
        deceleration = Mathf.Clamp(deceleration, 0, 1);
    }
}
