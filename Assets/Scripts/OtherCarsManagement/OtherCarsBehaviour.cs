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
    private int currentWaypointIndex;

    //speed of the car
    private float speed = 30f;

    //not in km/h!!
    private float turningSpeed = 170f;

    void Start()
    {            
        waypoints = OtherCarsPath.GetWaypoints();
        destination = FindNearestWayPoint();
        direction = (destination - transform.position).normalized;
    }

    void FixedUpdate()
    {
        GoToDestination();
        SafetyDistance();
    }

    private void GoToDestination()
    {
        direction = destination - transform.position;

        if (Vector3.Distance(transform.position, destination) > 1f)
        {
            transform.Translate(speed * Vector3.forward * Time.deltaTime);

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


    private Vector3 FindNearestWayPoint()
    {
        float distance = Mathf.Infinity;
        currentWaypointIndex = 0;
        for (int i = 0; i < waypoints.Count; i++)
        {
            float tempDistance = Vector3.Distance(transform.position, waypoints[i]);
            if (tempDistance < distance)
            {
                distance = tempDistance;
                currentWaypointIndex = i;
            }
        }
        return waypoints[currentWaypointIndex];
    }
}
