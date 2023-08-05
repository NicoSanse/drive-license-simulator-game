using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//this class gives the functionalities to the player and includes the logic behind
//the player behaviour. It is responsible for the score and for the level passing

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
    private MSVehicleControllerFree mSVehicleControllerFree;
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
    private List<string> tempMistakes;
    private int speedLimitDefault;
    private Transform carTransform;

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
        SpeedLimit();
    }

    void FixedUpdate()
    {
        PlayerOnTheRoad();
        SafetyDistance();
    }

    //draws the current waypoint so the players can see
    private void DrawCurrentWaypoint()
    {
        if (index < waypoints.Count)
        {
            Vector3 currentWaypoint = waypoints[index];
            currentWaypointPrefab = Instantiate(waypointPrefab, currentWaypoint, Quaternion.identity);
        }
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
                score += 8; 
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

    public void Win()
    {
        GUI.SetActive(false);
        canvasEndOfLevel.GetComponentsInChildren<Image>(true)[0].gameObject.SetActive(true);

        //setting the level as passed
        currentLevel.SetPassed(true);
        currentLevel.SetScore(score);

        CheckMistakes();

        StopCar();
        LevelFinished();
    }

    public void Lose()
    {
        particles.SwitchMaterial("red");
        particles.Play();

        GUI.SetActive(false);
        canvasEndOfLevel.GetComponentsInChildren<Image>(true)[0].gameObject.SetActive(true);
        canvasEndOfLevel.GetComponentsInChildren<TMP_Text>()[0].text = "You Lose!";
        canvasEndOfLevel.GetComponentsInChildren<Image>()[0].color = new Color(192 / 255f, 64 / 255f, 69 / 255f, 206 / 255f);

        currentLevel.SetScore(score);

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
                tempMistakes.Add("You hit something or someone!");
            }
            Lose();
            timesCollisionEnterCalled++;
        }
    }

    //finds whether the player is respecting speed limit or not
    private void SpeedLimit()
    {
        //in this area speed limit is 30
        if (carTransform.position.z > 420 && carTransform.position.z < 700 && 
            carTransform.position.x < -14 && carTransform.position.x > -620)
        {
            speedLimitDefault = 30;
        }
        else
        {
            speedLimitDefault = 50;
        }

        if(car.GetSpeed() > speedLimitDefault)
        {
            particles.SwitchMaterial("yellow");
            particles.Play();
        }

        if (car.GetSpeed() > speedLimitDefault + 5)
        {
            if (!currentLevel.IsMistakeAlreadyAdded("You were going too fast!"))
            {
                score -= 10;
                currentLevel.AddMistake("You were going too fast!");
                tempMistakes.Add("You were going too fast!");
            }
            Lose();
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
            if (!currentLevel.IsMistakeAlreadyAdded("You went out of the road!"))
            {
                score -= 10;
                currentLevel.AddMistake("You went out of the road!");
                tempMistakes.Add("You went out of the road!");
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
            if (!currentLevel.IsMistakeAlreadyAdded("You were too close to the car in front of you!"))
            {
                score -= 10;
                currentLevel.AddMistake("You were too close to the car in front of you!");
                tempMistakes.Add("You were too close to the car in front of you!");
            }
        }
    }

    //if the player is going too slow, we tell him
    public void SpeedTooLow()
    {
        particles.SwitchMaterial("yellow");
        particles.Play();
        if(!currentLevel.IsMistakeAlreadyAdded("You were going too slow and the car stopped!"))
        {
            score -= 10;
            currentLevel.AddMistake("You were going too slow and the car stopped!");
            tempMistakes.Add("You were going too slow and the car stopped!");
        }
    }

    //at the end of every level, we save the mistakes the player made
    //previous mistakes that are not made again are deleted
    private void CheckMistakes()
    { 
        currentLevel.SetMistakes(tempMistakes);
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
        mSVehicleControllerFree = MSVehicleControllerFree.mSVehicleControllerFree;
        score = 0;
        particles = ParticlesManagement.GetParticlesInstance();
        canvasEndOfLevel = GameObject.FindGameObjectWithTag("CanvasEndOfLevel");
        GUI = GameObject.FindGameObjectWithTag("GUI");
        timesCollisionEnterCalled = 0;
        index = 0;
        tempMistakes = new List<string>();
        speedLimitDefault = 50;
        carTransform = car.GetComponent<Transform>();
        DrawCurrentWaypoint();
    }

    private void StopCar()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        mSVehicleControllerFree.MySetEngineOnOff(true);
        car.Off();
    }

    public int GetScore()
    { 
        return score;
    }

    public void SetScore(int score)
    {
        this.score = score;
    }

    public List<string> GetTempMistakes()
    {
        return tempMistakes;
    }

    public static PlayerController GetPlayerControllerInstance()
    {
        return player;
    }

}
