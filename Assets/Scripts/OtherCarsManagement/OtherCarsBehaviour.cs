using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherCarsBehaviour : MonoBehaviour
{
    private Vector3 destination;
    private OtherCarsPath path;

    void Start()
    {
        path = OtherCarsPath.GetOtherCarsPathInstance();
        destination = path.GetCurrentWaypoint();
    }

    void Update()
    {
        destination = path.GetCurrentWaypoint();
        GoToDestination();
    }

    private void GoToDestination()
    {
        float distance = Vector3.Distance(transform.position, destination);
        
        if (distance > 0) 
        { 
            transform.position = Vector3.MoveTowards(transform.position, destination, 0.1f);
        }
    }
}
