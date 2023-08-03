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
    private bool onTheRoad;
    [SerializeField] private int path;
    private List<Vector3> waypoints;
    private int index;
    [SerializeField] private GameObject waypointPrefab;
    private GameObject currentWaypointPrefab;
    private float safeDistance;
    private bool isDistanceSafe;

    void Awake()
    {
        player = this;
    }

    void Start()
    {
        GetPath();
        Initialization();
    }

    void Update()
    {
        FollowPath();
    }

    void FixedUpdate()
    {
        PlayerOnTheRoad();
        SafetyDistance();
    }

    //draws the current waypoint so the players can see
    private void DrawCurrentWaypoint()
    { 
        Vector3 currentWaypoint = waypoints[index];
        currentWaypointPrefab = Instantiate(waypointPrefab, currentWaypoint, Quaternion.identity);
    }

    //tells the player where to go and in the end if the score
    //is high enough, the level is passed
    private void FollowPath()
    {
        if (index < waypoints.Count) 
        { 
            if (Vector3.Distance(transform.position, waypoints[index]) <= 15f)
            {
                index++;
                score += 10; 
                Destroy(currentWaypointPrefab);
                DrawCurrentWaypoint();
                particles.SwitchMaterial("green");
                particles.Play();
            }
        }
        else
        {
            if(score >= 90) Win();
            else Lose();
        }
    }

    private void Win()
    {
        GUI.SetActive(false);
        canvasEndOfLevel.GetComponentsInChildren<Image>(true)[0].gameObject.SetActive(true);

        //setting the level as passed
        currentLevel.SetPassed(true);
        currentLevel.SetScore(score);

        StopCar();
        LevelFinished();
    }

    private void Lose()
    {
        particles.SwitchMaterial("red");
        particles.Play();

        GUI.SetActive(false);
        canvasEndOfLevel.GetComponentsInChildren<Image>(true)[0].gameObject.SetActive(true);
        canvasEndOfLevel.GetComponentsInChildren<TMP_Text>()[0].text = "You Lose!";
        canvasEndOfLevel.GetComponentsInChildren<Image>()[0].color = new Color(192 / 255f, 64 / 255f, 69 / 255f, 206 / 255f);

        StopCar();
        LevelFinished();
    }

    //if the player hits anything, the level is lost
    void OnCollisionEnter()
    {
        if (timesCollisionEnterCalled == 0)
        {
            if(!currentLevel.IsMistakeAlreadyAdded("You hit something or someone!"))
            {
                currentLevel.AddMistake("You hit something or someone!");
            }
            Lose();
            timesCollisionEnterCalled++;
        }
    }

    //determine if the player is on the road
    private void PlayerOnTheRoad()
    { 
        onTheRoad = Physics.Raycast(transform.position, Vector3.down, 3f, LayerMask.GetMask("Road"));
        if(!onTheRoad)
        {
            particles.SwitchMaterial("yellow");
            particles.Play();
            if (!currentLevel.IsMistakeAlreadyAdded("You are not on the road"))
            {
                score -= 10;
                currentLevel.AddMistake("You are not on the road");
            }
        }
    }

    //determine if the player is at a safe distance from the car in front of him
    private void SafetyDistance()
    {
        safeDistance = (car.GetSpeed() * 10)/(36);
        isDistanceSafe = !(Physics.Raycast(transform.position, transform.forward, safeDistance, LayerMask.GetMask("OtherCars")));

        if (!isDistanceSafe)
        {
            particles.SwitchMaterial("yellow");
            particles.Play();
            if (!currentLevel.IsMistakeAlreadyAdded("You are too close to the car in front of you"))
            {
                score -= 10;
                currentLevel.AddMistake("You are too close to the car in front of you");
            }
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
        currentLevel.SetScore(score);
        saveManager.SetSaveState(saveState);
        saveManager.Save();
        gameManager.ChangeGameState(gameManager.GetCurrentGameState());
    }

    //getting the path from the PlayerPaths class
    private void GetPath()
    {
        waypoints = PlayerPaths.GetPlayerPath(path);   
    }

    private void Initialization()
    {
        gameManager = GameManager.GetGameManagerInstance();
        saveManager = SaveManager.GetSaveManagerInstance();
        saveState = saveManager.GetSaveState();
        menu = Menu.GetMenuInstance();
        currentLevel = saveState.GetListOfLevels()[menu.GetCurrentLevel().GetId() - 1];
        car = Car.GetCarInstance();
        score = 0;
        particles = ParticlesManagement.getParticlesInstance();
        canvasEndOfLevel = GameObject.FindGameObjectWithTag("CanvasEndOfLevel");
        GUI = GameObject.FindGameObjectWithTag("GUI");
        timesCollisionEnterCalled = 0;
        index = 0;
        DrawCurrentWaypoint();
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
