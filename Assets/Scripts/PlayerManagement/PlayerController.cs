using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

        //showing scores, which is the same in case of loss and victory
        GameObject.FindWithTag("CanvasEndOfLevel").GetComponentsInChildren<TMP_Text>(true)[4].gameObject.SetActive(true);
        GameObject.FindWithTag("CanvasEndOfLevel").GetComponentsInChildren<Button>(true)[2].gameObject.SetActive(true);

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
