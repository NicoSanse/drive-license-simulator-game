using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//this class gives the functionalities to the player
//it is responsible for the score and for the level passing

//todo: implement mistakes saving
//they are to be written in the save state as they are committed
//saveState.GetListOfLevels()[currentLevel.GetId() - 1].AddMistake(mistake);
//il mistake sarà una stringa da generare in base a cosa succede

//todo: gestire anche eliminazione errori e/o modifiche

public class PlayerController : MonoBehaviour
{
    private static PlayerController player;
    private GameManager gameManager;
    private SaveManager saveManager;
    private SaveState saveState;
    private Menu menu;
    private Level currentLevel;
    private Car car;
    private int score;
    private ParticlesManagement particles;
    private GameObject canvasEndOfLevel;
    private GameObject GUI;
    private int timesCollisionEnterCalled;
    private int timesTriggerEnterCalled;
    private bool onTheRoad;

    void Awake()
    {
        player = this;
    }

    void Start()
    {
        Initialization();
    }

    void Update()
    {
        PlayerOnTheRoad();
        SafetyDistance();
    }    

    //once the player enters the goal, the level is passed
    void OnTriggerEnter(Collider collider)
    {
        if (timesTriggerEnterCalled == 0)
        {
            GUI.SetActive(false);
            canvasEndOfLevel.GetComponentsInChildren<Image>(true)[0].gameObject.SetActive(true);

            //setting the level as passed
            SetScore(100);
            saveState.GetListOfLevels()[currentLevel.GetId() - 1].SetPassed(true);

            StopCar();
            LevelFinished();
            timesTriggerEnterCalled++;
        }
    }

    //if the player hits anything, the level is lost
    void OnCollisionEnter()
    {
        if (timesCollisionEnterCalled == 0)
        {
            GUI.SetActive(false);
            canvasEndOfLevel.GetComponentsInChildren<Image>(true)[0].gameObject.SetActive(true);
            canvasEndOfLevel.GetComponentsInChildren<TMP_Text>()[0].text = "You Lose!";
            canvasEndOfLevel.GetComponentsInChildren<Image>()[0].color = new Color(192 / 255f, 64 / 255f, 69 / 255f, 206 / 255f);

            SetScore(1);

            StopCar();
            LevelFinished();
            timesCollisionEnterCalled++;
        }
    }

    //determine if the player is on the road
    private void PlayerOnTheRoad()
    { 
        onTheRoad = Physics.Raycast(transform.position, Vector3.down, 1f, LayerMask.GetMask("Road"));
        if(!onTheRoad)
        {
            print("ooooo");
        }
    }

    //determine if the player is at a safe distance from the car in front of him
    private void SafetyDistance()
    {
        float safeDistance = (car.GetSpeed() * 1000)/(3600);
        bool isDistanceSafe = !(Physics.Raycast(transform.position, transform.forward, safeDistance, LayerMask.GetMask("Car")));

        if (!isDistanceSafe)
        {
            print("aaaaa");
        }

    }

    private void StopCar()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        car.Off();
    }

    //saving state and changing game state
    private void LevelFinished()
    {
        saveState.GetListOfLevels()[currentLevel.GetId() - 1].SetScore(score);
        saveManager.SetSaveState(saveState);
        saveManager.Save();
        gameManager.ChangeGameState(gameManager.GetCurrentGameState());
    }

    private void Initialization()
    {
        gameManager = GameManager.GetGameManagerInstance();
        saveManager = SaveManager.GetSaveManagerInstance();
        saveState = saveManager.GetSaveState();
        menu = Menu.GetMenuInstance();
        currentLevel = menu.GetCurrentLevel();
        car = Car.GetCarInstance();
        score = 0;
        particles = ParticlesManagement.getParticlesInstance();
        canvasEndOfLevel = GameObject.FindGameObjectWithTag("CanvasEndOfLevel");
        GUI = GameObject.FindGameObjectWithTag("GUI");
        timesCollisionEnterCalled = 0;
        timesTriggerEnterCalled = 0;
    }

    public int GetScore()
    { 
        return score;
    }

    private void SetScore(int score)
    {
        this.score = score;
    }

    public static PlayerController GetPlayerControllerInstance()
    {
        return player;
    }

}
