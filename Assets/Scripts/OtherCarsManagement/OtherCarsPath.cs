using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherCarsPath : MonoBehaviour
{
    private static OtherCarsPath otherCarsPath;
    private List<Vector3> waypoints = new List<Vector3>();
    private int currentWaypointIndex;
    private Vector3 currentWaypoint;
    private bool wayPointReached;

    void Awake()
    {
        otherCarsPath = this;
    }

    void Start()
    {
        GenerateWaypoints();
        currentWaypointIndex = 0;
        currentWaypoint = waypoints[currentWaypointIndex];
        wayPointReached = false;
    }

    void Update()
    {
        UpdateWaypoint();
    }

    private void UpdateWaypoint()
    {
        if (wayPointReached)
        {
            currentWaypointIndex++;
            currentWaypoint = waypoints[currentWaypointIndex];
            wayPointReached = false;
        }
    }


    private void GenerateWaypoints()
    {
        Vector3 tempWayPoint = new Vector3(307, 0, 404);
        waypoints.Add(tempWayPoint);
    }



    public Vector3 GetCurrentWaypoint()
    {
        return currentWaypoint;
    }

    public static OtherCarsPath GetOtherCarsPathInstance()
    {
        return otherCarsPath;
    }
}
