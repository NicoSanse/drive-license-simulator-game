using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager gameManager;
    public enum GameState { Welcome, Menu, Playing, LevelPaused, LevelWon, LevelLost };
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

    public void ChangeGameState(GameState state) 
    { 
        switch (state)
        {
            case GameState.Welcome:
                HandleWelcomeState();
                break;
            case GameState.Menu:
                HandleMenuState();
                break;
            case GameState.Playing:
                HandlePlayingState();
                break;
            case GameState.LevelPaused:
                HandleLevelPausedState();
                break;
            case GameState.LevelWon:
                HandleLevelWonState();
                break;
            case GameState.LevelLost:
                HandleLevelLostState();
                break;
            default:
                break;
        }
    }

    private void HandleWelcomeState()
    {
        SetGameState(GameState.Menu);
    }

    private void HandleMenuState()
    { 
        SetGameState(GameState.Playing);
    }

    private void HandlePlayingState()
    {
        if (pauseButton.WasPauseButtonClicked())
        {
            SetGameState(GameState.LevelPaused);
        }
        else
        {
            if (player.IsCrashed())
            {
                SetGameState(GameState.LevelLost);
            }
            else
            {
                SetGameState(GameState.LevelWon);
            }
        }
    }

    private void HandleLevelPausedState()
    {
        if(pauseScreen.ClickedOnQuit())
        {
            SetGameState(GameState.Menu);
        }
        else
        {
            SetGameState(GameState.Playing);
        }
    }

    private void HandleLevelWonState()
    { 
        SetGameState(GameState.Menu);
        LevelPassed();
    }

    private void HandleLevelLostState()
    { 
        SetGameState(GameState.Menu);
        LevelFailed();
    }

    //sets the current level as passed and come back to the menu
    public void LevelPassed()
    {
        menu.GetCurrentLevel().SetPassed(true);
    }

    //sets the current level as failed
    public void LevelFailed()
    {
        menu.GetCurrentLevel().SetPassed(false);
    }

    public static GameManager GetGameManagerInstance() 
    { 
        return gameManager;
    }
}
