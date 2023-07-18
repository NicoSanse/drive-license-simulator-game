using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager gameManager;
    private SaveManager saveManager;
    private SaveState saveState;
    public enum GameState { Welcome, Menu, Playing, LevelPaused, LevelEnd };
    private static GameState currentGameState = GameState.Welcome;
    private Menu menu;
    private PlayerController player;
    private PauseButtonBehaviour pauseButton;
    private PauseScreenBehaviour pauseScreen;
    void Awake() 
    { 
        gameManager = this;
    }

    void Start()
    {
        menu = Menu.GetMenuInstance();
        saveManager = SaveManager.GetSaveManagerInstance();
        saveState = saveManager.GetSaveState();
        player = PlayerController.GetPlayerControllerInstance();
        pauseButton = PauseButtonBehaviour.GetPauseButtonBehaviourInstance();
    }

    void Update()
    {
        if(pauseScreen == null)
        {
            pauseScreen = PauseScreenBehaviour.GetPauseScreenBehaviourInstance();
        }
    }

    public GameState GetCurrentGameState() 
    { 
        return currentGameState;
    }

    public void SetGameState(GameState state) 
    { 
        currentGameState = state;
    }

    public void ChangeGameState(GameState state, int sceneIndex = 0) 
    { 
        switch (state)
        {
            case GameState.Welcome:
                HandleWelcomeState();
                break;
            case GameState.Menu:
                HandleMenuState(sceneIndex);
                break;
            case GameState.Playing:
                HandlePlayingState();
                break;
            case GameState.LevelPaused:
                HandleLevelPausedState(sceneIndex);
                break;
            case GameState.LevelEnd:
                HandleEndLevelState();
                break;
            default:
                break;
        }

    }

    private void HandleWelcomeState()
    {
        SetGameState(GameState.Menu);
        LoadScene("Menu");
    }

    private void HandleMenuState(int sceneIndex)
    { 
        SetGameState(GameState.Playing);
        LoadScene(sceneIndex);
    }

    private void HandlePlayingState()
    {
        if (pauseButton.WasPauseButtonClicked())
        {
            SetGameState(GameState.LevelPaused);
        }
        else
        {
            SetGameState(GameState.LevelEnd);
        }
    }

    private void HandleLevelPausedState(int sceneIndex)
    {
        if(pauseScreen.ClickedOnQuit())
        {
            SetGameState(GameState.Menu);
            LoadScene("Menu");
        }
        else if (pauseScreen.ClickedOnRestart())
        { 
            SetGameState(GameState.Playing);
            LoadScene(sceneIndex);
        }
        else
        {
            SetGameState(GameState.Playing);
        }
    }

    private void HandleEndLevelState()
    { 
        SetGameState(GameState.Menu);
        LoadScene("Menu");
    }    

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public static GameManager GetGameManagerInstance() 
    { 
        return gameManager;
    }
}
