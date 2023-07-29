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
        Vector3 tempWayPoint = new Vector3(307, 1, 420);
        Vector3 tempWayPoint2 = new Vector3(320, 1, 431);
        Vector3 tempWayPoint3 = new Vector3(460, 1, 431);
        waypoints.Add(tempWayPoint);
        waypoints.Add(tempWayPoint2);
        waypoints.Add(tempWayPoint3);
    }


    public static List<Vector3> GetWaypoints()
    {
        return waypoints;
    }

    
}
