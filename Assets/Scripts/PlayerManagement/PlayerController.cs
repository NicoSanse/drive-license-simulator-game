using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static PlayerController player;
    private int gear;
    private float speed;

    void Awake()
    {
        player = this;
    }

    //Start is called before the first frame update
    void Start()
    {
        print("Start");
        gear = ClutchBehaviour.clutch.getGear();
        speed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (gear == 1){ 
            print("Gear 1");
        }
        if (gear == 2)
        {
            print("Gear 2");
        }
        if (gear == 3)
        {
            print("Gear 3");
        }
        if (gear == 4)
        {
            print("Gear 4");
        }
        if (gear == 5)
        {
            print("Gear 5");
        }
        */

        //the speed is calculated by adding the acceleration and the deceleration
        speed = AccelerationBehaviour.accelerator.getAcceleration() + BrakeBehaviour.brake.getDeceleration();
        if (speed <= 0f)
        {
            speed = 0f;
        }

        transform.position += Vector3.forward * Time.deltaTime * speed;
    }

    //once the player enters the goal, the level is passed
    //TODO: implement the control on scores which is still to be created
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            print("You win!");
            speed = 0f;
            AccelerationBehaviour.accelerator.setAcceleration(0f);
            BrakeBehaviour.brake.setDeceleration(0f);
            GameManager.gameManager.LevelPassed();
        }
    }
}
