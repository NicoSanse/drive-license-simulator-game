using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

//this class models the speedometer
public class SpeedometerBehaviour : MonoBehaviour
{
    public Rigidbody target;

    public float maxSpeed = 0.0f;

    public float minSpeedArrowAngle;
    public float maxSpeedArrowAngle;

    [Header("UI")]
    public RectTransform arrow; 

    private float speed = 0.0f;
    private void Update()
    {
        // 3.6f to convert in kilometers
        // The speed must be clamped by the car controller
        speed = target.velocity.magnitude * 3.6f;

        if (arrow != null)
            arrow.localEulerAngles =
                new Vector3(0, 0, Mathf.Lerp(minSpeedArrowAngle, maxSpeedArrowAngle, speed / maxSpeed));
    }
}