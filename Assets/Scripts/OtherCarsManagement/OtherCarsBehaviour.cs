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
    //manually set the path the car will follow
    [SerializeField] private int seedPath;
    //need to check if the right side of the car is free
    private Vector3 rayCastDirection;
    private Ray ray;
    private RaycastHit hitInfo;
    private bool isRightSideFree;
    private bool isRightSideFreeFromPlayer;
    private bool isDistanceSafe;
    private bool isDistanceSafeFromPlayer;
    private bool isOnRoad;

    private GameObject roundabout1;
    private GameObject roundabout2;
    private float distanceFromRoundabout;

    void Start()
    {
        waypoints = OtherCarsPath.GetAPath(seedPath);
        destination = waypoints[currentWaypointIndex];
        direction = (destination - transform.position).normalized;

        rayCastDirection = transform.forward;
        ray = new Ray(transform.position, rayCastDirection);
        isRightSideFree = true;

        roundabout1 = GameObject.FindGameObjectsWithTag("roundabout")[0];
        roundabout2 = GameObject.FindGameObjectsWithTag("roundabout")[1];
    }

    void Update()
    {
        SelfDestroy();
        DestroyCarsNotOnRoad();
    }

    void FixedUpdate()
    {
        GoToDestination();
        SafetyDistance();
        WhereToGiveTheWay();
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
        float fakeSafeDistance = 4f;
        isDistanceSafe = !(Physics.Raycast(transform.position, transform.forward, fakeSafeDistance, LayerMask.GetMask("OtherCars")));
        isDistanceSafeFromPlayer = !(Physics.Raycast(transform.position, transform.forward, fakeSafeDistance, LayerMask.GetMask("Player")));

        if (!isDistanceSafe || !isDistanceSafeFromPlayer)
        {
            while (speed >= 30f)
            {
                speed -= 0.5f;
            }
        }
        else
        {
            while (speed <= 50f)
            {
                speed += 0.05f;
            }
        }
    }

    //usually give the way to the ones on right side, but when close to a roundabout, give the way to the ones on left side
    private void WhereToGiveTheWay()
    {
        distanceFromRoundabout = CalculateDistanceFromRoundabout();
        if(distanceFromRoundabout > 20f)
        {
            GiveTheWay(transform.right);
        }
        else
        {
            GiveTheWay(-transform.right);
        }
    }

    //this checks if the right side of the car is free. if not so, stop
    private void GiveTheWay(Vector3 sideToGiveTheWay)
    {
        isRightSideFree = !(Physics.Raycast(ray, out hitInfo, 4f, LayerMask.GetMask("OtherCars")));
        isRightSideFreeFromPlayer = !(Physics.Raycast(ray, out hitInfo, 4f, LayerMask.GetMask("Player")));
        int index = 2;

        while(index <= 10 && isRightSideFree && isRightSideFreeFromPlayer)
        { 
            float t = (float) index / 10;
            rayCastDirection = Vector3.Slerp(rayCastDirection, sideToGiveTheWay, t);
            ray = new Ray(transform.position, rayCastDirection);
            isRightSideFree = !(Physics.Raycast(ray, out hitInfo, 4f, LayerMask.GetMask("OtherCars")));
            isRightSideFreeFromPlayer = !(Physics.Raycast(ray, out hitInfo, 4f, LayerMask.GetMask("Player")));
            index++;
        }
        rayCastDirection = transform.forward;

        if (!isRightSideFree || !isRightSideFreeFromPlayer)
        {
            speed = 5;
        }
        else
        {
            speed = 30f;
        }
    }

    //this finds the value that best fits turningSpeed variable based on empirical tests
    private void AdjustTurningSpeed()
    {
        //setting for first path
        if (seedPath == 0)
        {
            if (currentWaypointIndex == 3 || currentWaypointIndex == 6 || currentWaypointIndex == 8 || currentWaypointIndex == 9)
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
        //setting for second path
        else if (seedPath == 1)
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
        //setting for third path
        else if(seedPath == 2)
        {
            if (currentWaypointIndex == 1 || currentWaypointIndex == 10)
            {
                turningSpeed = 150f;
            }
            else if (currentWaypointIndex == 6)
            {
                turningSpeed = 90f;
            }
            else if (currentWaypointIndex == 8 || currentWaypointIndex == 16)
            {
                turningSpeed = 100f;
            }
            else
            {
                turningSpeed = 170f;
            }
        }
        //setting for the reverse of first path
        else if (seedPath == 5)
        {
            if (currentWaypointIndex == 3 || currentWaypointIndex == 5 || currentWaypointIndex == 9)
            {
                turningSpeed = 100f;
            }
            else
            {
                turningSpeed = 170f;
            }
        }
        //setting for the reverse of the second path
        else if (seedPath == 6)
        {
            if (currentWaypointIndex == 9)
            {
                turningSpeed = 90f;
            }
            else if (currentWaypointIndex == 13)
            {
                turningSpeed = 100f;
            }
            else if (currentWaypointIndex == 15)
            {
                turningSpeed = 120f;
            }
            else if (currentWaypointIndex == 11 || currentWaypointIndex == 15)
            {
                turningSpeed = 75f;
            }
            else
            {
                turningSpeed = 170f;
            }
        }
        //setting for the reverse of third path
        else if(seedPath == 7)
        {
            if (currentWaypointIndex == 5)
            {
                turningSpeed = 120f;
            }
            else if (currentWaypointIndex == 13)
            {
                turningSpeed = 150f;
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
            while (speed >= 30f)
            {
                speed -= 0.5f;
            }
        }
        else
        {
            while (speed <= 50f)
            {
                speed += 0.05f;
            }
        }
    }

    private float CalculateDistanceFromRoundabout()
    { 
        float distanceFromRoundabout1 = Vector3.Distance(transform.position, roundabout1.transform.position);
        float distanceFromRoundabout2 = Vector3.Distance(transform.position, roundabout2.transform.position);
        return Mathf.Min(distanceFromRoundabout1, distanceFromRoundabout2);
    }

    private void DestroyCarsNotOnRoad()
    { 
        isOnRoad = Physics.Raycast(transform.position, -transform.up, 4f, LayerMask.GetMask("Road"));
        if (!isOnRoad)
        {
            Destroy(gameObject);
        }
    }

    private void SelfDestroy()
    {
        if (transform.position.y < -10 || transform.position.y > 15)
        {
            Destroy(gameObject);
        }
    }
}
