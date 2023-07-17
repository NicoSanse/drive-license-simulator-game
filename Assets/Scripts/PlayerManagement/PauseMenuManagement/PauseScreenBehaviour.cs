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
        int currentLevel = menu.GetCurrentLevel().GetId();
        gameManager.ChangeGameState(gameManager.GetCurrentGameState());
        SceneManager.LoadScene(currentLevel + 1);
    }

    public void Quit()
    {
        quitting = true;
        gameManager.ChangeGameState(gameManager.GetCurrentGameState());
        SceneManager.LoadScene("Menu");
    }

    public bool ClickedOnQuit()
    {
        return quitting;
    }

    public static PauseScreenBehaviour GetPauseScreenBehaviourInstance()
    {
        return pauseScreenBehaviour;
    }
}
