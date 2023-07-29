using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherCarsPath : MonoBehaviour
{
    private static List<Vector3> waypoints;

    void Awake()
    {
        waypoints = new List<Vector3>();
        GenerateWaypoints();
    }

    void Start()
    {
        
    }

    void Update()
    {

    }

    private void GenerateWaypoints()
    {
        Vector3 tempWayPoint = new Vector3(307, 0, 404);
        Vector3 tempWayPoint2 = new Vector3(309, 0, 417);
        Vector3 tempWayPoint3 = new Vector3(312, 0, 428);
        Vector3 tempWayPoint4 = new Vector3(326, 0, 430);
        Vector3 tempWayPoint5 = new Vector3(360, 0, 430);
        waypoints.Add(tempWayPoint);
        waypoints.Add(tempWayPoint2);
        waypoints.Add(tempWayPoint3);
        waypoints.Add(tempWayPoint4);
        waypoints.Add(tempWayPoint5);
    }


    public static List<Vector3> GetWaypoints()
    {
        return waypoints;
    }

    
}
