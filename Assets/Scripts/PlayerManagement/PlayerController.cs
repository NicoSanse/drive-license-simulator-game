using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static PlayerController player;
    private ClutchBehaviour.Gear gear;
    private float speed;

    void Awake()
    {
        player = this;
    }

    //Start is called before the first frame update
    void Start()
    {
        print("Start");
        gear = ClutchBehaviour.clutch.GetCurrentGear();
        speed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
        //the speed is calculated by adding the acceleration and the deceleration
        speed = AccelerationBehaviour.accelerator.GetAcceleration() + BrakeBehaviour.brake.GetDeceleration();
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
            AccelerationBehaviour.accelerator.SetAcceleration(0f);
            BrakeBehaviour.brake.SetDeceleration(0f);
            GameManager.LevelPassed();
        }
    }

    public void NotifyGearChanged()
    {
        gear = ClutchBehaviour.clutch.GetCurrentGear();
        print("Gear changed to " + gear);
    }
}
