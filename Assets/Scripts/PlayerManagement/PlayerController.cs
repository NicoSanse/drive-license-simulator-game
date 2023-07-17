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

    void Awake()
    {
        player = this;
    }

    void Start()
    {
        gameManager = GameManager.GetGameManagerInstance();
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
            GameObject.FindWithTag("CanvasEndOfLevel").GetComponentsInChildren<Image>(true)[0].gameObject.SetActive(true);
        }
        else
        {
            crashed = true;
            GameObject.FindWithTag("CanvasEndOfLevel").GetComponentsInChildren<Image>(true)[1].gameObject.SetActive(true);
        }
        Car.car.Stop();
        GameObject.FindGameObjectWithTag("GUI").SetActive(false);
        gameManager.ChangeGameState(gameManager.GetCurrentGameState());
    }

    public bool IsCrashed()
    {
        return crashed;
    }

    public static PlayerController GetPlayerControllerInstance()
    {
        return player;
    }

}
