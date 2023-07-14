using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCarRotation : MonoBehaviour
{
    public static MyCarRotation myCarRotation;
    private float rotation;
    private Gyroscope gyroscope;
    private float leftSensibility = 3f;
    private float rightSensibility = 3f;
    private Quaternion currentRotation;
    private Quaternion previousRotation;
    private float angleRotationDifference;
    private float leftTurningValue;
    private float rightTurningValue;
    void Awake()
    {
        myCarRotation = this;
    }
    void Start()
    {
        gyroscope = Input.gyro;
        gyroscope.enabled = true;
        rotation = 0f;
        leftTurningValue = 0f;
        rightTurningValue = 0f;
        previousRotation = new Quaternion(0, 0, 0, 1);
    }

    void Update()
    {
        MeasureRotation();
        previousRotation = currentRotation;
    }

    //the rotation is calculated as a difference in the rotation 
    //of the device measured by the gyroscope
    //using the current and prevoius position of the device
    private void MeasureRotation()
    {
        //measure rotation
        currentRotation = gyroscope.attitude;
        print("current gryscope attitude: " + currentRotation);
        print("previous gryscope attitude: " + previousRotation);
        //making it negative because the rotation of gyroscope is opposite to the rotation of Unity
        angleRotationDifference = -Quaternion.Angle(previousRotation, currentRotation);

        //including the rotation of the device between 45 and -45 degrees
        print("angle rotation difference before clamping: " + angleRotationDifference);
        if(angleRotationDifference > 45) angleRotationDifference = 45;
        if(angleRotationDifference < -45) angleRotationDifference = -45;
        print("angle rotation difference after clamping: " + angleRotationDifference);

        //managing turning left
        if (angleRotationDifference <= -5)
        {
            print("AAAA");
            //leftSensibility = angleRotationDifference / 15;
            leftTurningValue += leftSensibility * Time.deltaTime;
        }
        //not considering little variation as intentional rotation
        else if(angleRotationDifference < 5)
        {
            print("BBBB");
            //leftSensibility = 3f;
            leftTurningValue -= leftSensibility * Time.deltaTime;
        }
        leftTurningValue = Mathf.Clamp(leftTurningValue, 0, 1);
        print("left turning value: " + leftTurningValue);





        //managing turning right
        if (angleRotationDifference >= 5)
        {
            print("CCCC");
            //rightSensibility = angleRotationDifference / 15;
            rightTurningValue += rightSensibility * Time.deltaTime;
        }
        //not considering little variation as intentional rotation
        else if(angleRotationDifference > -5)
        {
            print("DDDD");
            //rightSensibility = 3f;
            rightTurningValue -= rightSensibility * Time.deltaTime;
        }
        rightTurningValue = Mathf.Clamp(rightTurningValue, 0, 1);
        print("right turning value: " + rightTurningValue);



        rotation = rightTurningValue - leftTurningValue;
        print("Rotation: " + rotation);
        print("----------------------------------------------");
    }

    public float GetValue()
    {
        return rotation;
    }
}
