using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//this is the GameManager class and models the flow of the game
//there are five states: welcome, menu, playing, level-paused and level-end
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

    //given the current game state, each state is manages separately
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

    //from welcome you can only go to menu
    private void HandleWelcomeState()
    {
        SetGameState(GameState.Menu);
        LoadScene("Menu");
    }

    //from menu you can only go to playing (given the level)
    private void HandleMenuState(int sceneIndex)
    { 
        SetGameState(GameState.Playing);
        LoadScene(sceneIndex);
    }

    //while playing you can pause the level or finish it
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

    //when you are on pause, you can either quit the level 
    //or keep playing it again (both if you are resuming or restarting it)
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

    //when you finish a level you can just go back to the menu
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
