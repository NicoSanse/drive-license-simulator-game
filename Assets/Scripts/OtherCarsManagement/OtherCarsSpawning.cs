using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class manages the "spawning" of the other cars
//cars too far from playe will be kept inactive

public class OtherCarsSpawning : MonoBehaviour
{
    [SerializeField] private GameObject[] otherCars;
    private float distanceFromPlayer;
    private float actualDistance;

    void Start()
    {
        distanceFromPlayer = 400f;
    }

    void Update()
    {
        CheckDistance();
    }

    private void CheckDistance()
    {
        foreach (GameObject cars in otherCars)
        {
            foreach (Component car in cars.GetComponentsInChildren<Component>(true))
            {
                actualDistance = Vector3.Distance(car.gameObject.transform.position, transform.position);
                if (actualDistance > distanceFromPlayer)
                {
                    car.gameObject.SetActive(false);
                }
                else
                {
                    print("car activated. distance: " + actualDistance);
                    car.gameObject.SetActive(true);
                }
            }
        }
    }
}
