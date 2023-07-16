using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager gameManager;
    public enum GameState { Welcome, Menu, Playing, LevelPaused };
    private static GameState gameState;
    private Menu menu;
    void Awake() 
    { 
        gameManager = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //andranno fatte delle cose per recuperare i dati dal file di salvataggio
        //in modo da non perdere i dati delle pardite ad ogni avvio
        //per ora li inizializzo a mano
        gameState = GameState.Welcome;
        menu = Menu.GetMenuInstance();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameState GetCurrentGameState() 
    { 
        return gameState;
    }

    public void SetGameState(GameState state) 
    { 
        gameState = state;
    }

    //sets the current level as passed and come back to the menu
    public void LevelPassed()
    {
        menu.GetCurrentLevel().SetPassed(true);
        SceneManager.LoadScene("Menu");
        gameState = GameState.Menu;
    }

    public static GameManager GetGameManagerInstance() 
    { 
        return gameManager;
    }
}
