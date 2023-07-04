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
    }

    // Update is called once per frame
    void Update()
    {

    }    

    //once the player enters the goal, the level is passed
    //TODO: implement the control on scores which is still to be created
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            print("You win!");
            Car.car.Stop();
            GameManager.LevelPassed();
        }
    }

}
