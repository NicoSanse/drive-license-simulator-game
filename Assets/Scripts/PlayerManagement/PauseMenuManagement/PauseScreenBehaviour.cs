using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void Resume()
    {
        MSSceneControllerFree.mSSceneControllerFree.SetPause(false);
        gameManager.ChangeGameState(gameManager.GetCurrentGameState());
        pauseScreen.SetActive(false);
    }

    public void Restart()
    {
        restarting = true;
        int currentLevel = menu.GetCurrentLevel().GetId();
        gameManager.ChangeGameState(gameManager.GetCurrentGameState(), currentLevel + 1);
    }

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
