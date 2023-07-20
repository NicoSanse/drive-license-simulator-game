using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//this class gives the functionalities to the player
//it is responsible for the score and for the level passing
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

    void Awake()
    {
        player = this;
    }

    void Start()
    {
        gameManager = GameManager.GetGameManagerInstance();
        saveManager = SaveManager.GetSaveManagerInstance();
        saveState = saveManager.GetSaveState();
        menu = Menu.GetMenuInstance();
        currentLevel = menu.GetCurrentLevel();
        car = Car.GetCarInstance();
        score = 0;
    }

    void Update()
    {

    }    

    //once the player enters the goal, the level is passed
    //TODO: implement the control on scores which is still to be created
    void OnTriggerEnter(Collider collision)
    {
        GameObject.FindGameObjectWithTag("GUI").SetActive(false);

        //in this case the player has won
        if (collision.gameObject.tag == "Goal")
        {
            //activating the green panel and setting the level as passed
            SetScore(100);
            GameObject.FindWithTag("CanvasEndOfLevel").GetComponentsInChildren<Image>(true)[0].gameObject.SetActive(true);
            saveState.GetListOfLevels()[currentLevel.GetId() - 1].SetPassed(true);
        }
        else
        {
            //activating the red panel
            SetScore(1);
            GameObject.FindWithTag("CanvasEndOfLevel").GetComponentsInChildren<Image>(true)[1].gameObject.SetActive(true);
        }

        StopCar();
        LevelFinished();
    }

    private void StopCar()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        car.Off();
    }

    //saving state and changing game state
    private void LevelFinished()
    {
        saveState.GetListOfLevels()[menu.GetCurrentLevel().GetId() - 1].SetScore(GetScore());
        saveManager.SetSaveState(saveState);
        saveManager.Save();
        gameManager.ChangeGameState(gameManager.GetCurrentGameState());
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
