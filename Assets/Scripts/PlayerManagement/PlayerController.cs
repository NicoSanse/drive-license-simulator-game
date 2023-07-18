using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private static PlayerController player;
    private GameManager gameManager;
    private ClutchBehaviour.Gear gear;
    private float speed;
    private bool crashed;
    private Car car;
    private int score;

    void Awake()
    {
        player = this;
    }

    void Start()
    {
        gameManager = GameManager.GetGameManagerInstance();
        car = Car.GetCarInstance();
        crashed = false;
    }

    void Update()
    {

    }    

    //once the player enters the goal, the level is passed
    //TODO: implement the control on scores which is still to be created
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            crashed = false;
            score = 100;
            GameObject.FindWithTag("CanvasEndOfLevel").GetComponentsInChildren<Image>(true)[0].gameObject.SetActive(true);
        }
        else
        {
            crashed = true;
            score = 1;
            GameObject.FindWithTag("CanvasEndOfLevel").GetComponentsInChildren<Image>(true)[1].gameObject.SetActive(true);
        }
        car.Stop();
        GameObject.FindGameObjectWithTag("GUI").SetActive(false);
        gameManager.ChangeGameState(gameManager.GetCurrentGameState());
    }

    public bool IsCrashed()
    {
        return crashed;
    }

    public int GetScore()
    { 
        return score;
    }

    public static PlayerController GetPlayerControllerInstance()
    {
        return player;
    }

}
