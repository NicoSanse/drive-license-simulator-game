using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherCarsBehaviour : MonoBehaviour
{
    private List<Vector3> waypoints;
    private Vector3 destination;
    private int currentWaypointIndex;

    void Start()
    {            
        waypoints = OtherCarsPath.GetWaypoints();
        destination = FindNearestWayPoint();
    }

    void Update()
    {
        destination = waypoints[currentWaypointIndex];
        GoToDestination();
    }

    private void GoToDestination()
    {
        float distance = Vector3.Distance(transform.position, destination);
        
        if (distance > 0)
        {
            Quaternion rotation = Quaternion.LookRotation(destination - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.1f);
            transform.position = Vector3.MoveTowards(transform.position, destination, 0.1f);
        }
        else
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Count)
            {
                currentWaypointIndex = 0;
            }
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
