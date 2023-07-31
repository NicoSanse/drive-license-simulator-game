using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherCarsBehaviour : MonoBehaviour
{
    //list of waypoints
    private List<Vector3> waypoints;

    //current destination the car is aheaded to in world coordinates
    private Vector3 destination;

    //direction the car is headed to, it's a vector
    private Vector3 direction;

    //index of the list containing waypoints
    [SerializeField] private int currentWaypointIndex;
    //speed of the car
    private float speed = 50f;

    //not in km/h!!
    private float turningSpeed = 170f;
    [SerializeField] private int seedPath;

    void Start()
    {
        waypoints = OtherCarsPath.GetAPath(seedPath);
        destination = waypoints[currentWaypointIndex];
        direction = (destination - transform.position).normalized;
    }

    void FixedUpdate()
    {
        GoToDestination();
        SafetyDistance();
    }

    //main function that moves the other cars
    private void GoToDestination()
    {
        direction = destination - transform.position;

        if (Vector3.Distance(transform.position, destination) > 1f)
        {
            AdjustTravelSpeed();
            transform.Translate(speed * Vector3.forward * Time.deltaTime);

            AdjustTurningSpeed();
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, turningSpeed * Time.deltaTime);
        }
        else 
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Count)
            {
                currentWaypointIndex = 0;
            }
            destination = waypoints[currentWaypointIndex];
        }
    }

    //keeps each car correctly distanced from the car ahead
    private void SafetyDistance()
    {
        float safeDistance = (speed * 1000)/(3600);
        bool isDistanceSafe = !(Physics.Raycast(transform.position, transform.forward, safeDistance, LayerMask.GetMask("OtherCars")));

        if (!isDistanceSafe)
        {
            speed -= 0.01f;
        }
        else if (speed <= 30f)
        {
            speed += 0.01f;
        }
    }

    //this finds the value that best fits turningSpeed variable based on empirical tests
    private void AdjustTurningSpeed()
    {
        if (seedPath == 1)
        {
            if (currentWaypointIndex == 5 || currentWaypointIndex == 11)
            {
                turningSpeed = 65f;
            }
            else if (currentWaypointIndex == 9 || currentWaypointIndex == 7)
            {
                turningSpeed = 90f;
            }
            else if (currentWaypointIndex == 13)
            {
                turningSpeed = 120f;
            }
            else if(currentWaypointIndex == 17 || currentWaypointIndex == 21)
            {
                turningSpeed = 150f;
            }
            else
            {
                turningSpeed = 170f;
            }
        }
        else if (seedPath == 0)
        {
            if (currentWaypointIndex == 3 || currentWaypointIndex == 6 || currentWaypointIndex == 8 || currentWaypointIndex == 9 )
            {
                turningSpeed = 90f;
            }
            else if (currentWaypointIndex == 10 || currentWaypointIndex == 12)
            { 
                turningSpeed = 100f;
            }
            else
            {
                turningSpeed = 170f;
            }
        }
    }

    //sets an appropriate travel speed
    private void AdjustTravelSpeed()
    { 
        if(Vector3.Distance(transform.position, destination) < 40)
        {
            while (speed > 30f)
            {
                speed -= 0.5f;
            }
        }
        else
        { 
            while (speed < 50f)
            {
                speed += 0.01f;
            }
        }
    }

}
