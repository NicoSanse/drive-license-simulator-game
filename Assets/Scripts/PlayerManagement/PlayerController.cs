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
        GameObject.FindGameObjectWithTag("CanvasEndOfLevel").GetComponentsInChildren<Image>(true)[0].gameObject.SetActive(true);

        //in this case the player has won
        if (collision.gameObject.tag == "Goal")
        {
            //setting the level as passed
            SetScore(100);
            saveState.GetListOfLevels()[currentLevel.GetId() - 1].SetPassed(true);
        }
        else
        {
            //colouring the panel red
            SetScore(1);
            GameObject.FindGameObjectWithTag("CanvasEndOfLevel").GetComponentsInChildren<TMP_Text>()[0].text = "You Lose!";
            GameObject.FindGameObjectWithTag("CanvasEndOfLevel").GetComponentsInChildren<Image>()[0].color = new Color(192f, 64f, 69f, 206f);
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
        saveState.GetListOfLevels()[currentLevel.GetId() - 1].SetScore(score);
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
