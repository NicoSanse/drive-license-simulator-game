using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//this class gives the functionalities to the pause screen
public class PauseScreenBehaviour : MonoBehaviour
{
    private Menu menu;
    private GameManager gameManager;
    private static PauseScreenBehaviour pauseScreenBehaviour;
    private bool quitting;
    private bool restarting;
    [SerializeField] GameObject pauseScreen;

    void Awake()
    {
        pauseScreenBehaviour = this;
    }

    void Start()
    {
        menu = Menu.GetMenuInstance();
        gameManager = GameManager.GetGameManagerInstance();
        quitting = false;
        restarting = false;
    }

    void Update()
    {
        
    }

    //allows to resume the level
    public void Resume()
    {
        MSSceneControllerFree.mSSceneControllerFree.SetPause(false);
        gameManager.ChangeGameState(gameManager.GetCurrentGameState());
        pauseScreen.SetActive(false);
    }

    //allows to restart the level
    public void Restart()
    {
        restarting = true;
        int currentLevel = menu.GetCurrentLevel().GetId();
        gameManager.ChangeGameState(gameManager.GetCurrentGameState(), currentLevel + 1);
    }

    //allows to quit the level
    public void Quit()
    {
        quitting = true;
        gameManager.ChangeGameState(gameManager.GetCurrentGameState());
    }

    public bool ClickedOnQuit()
    {
        return quitting;
    }

    public bool ClickedOnRestart()
    {
        return restarting;
    }

    public static PauseScreenBehaviour GetPauseScreenBehaviourInstance()
    {
        return pauseScreenBehaviour;
    }
}
