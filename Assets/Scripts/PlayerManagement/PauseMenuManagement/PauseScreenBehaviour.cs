using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreenBehaviour : MonoBehaviour
{

    private Menu menu;
    private GameManager gameManager;
    [SerializeField] GameObject pauseScreen;
    // Start is called before the first frame update
    void Start()
    {
        menu = Menu.GetMenuInstance();
        gameManager = GameManager.GetGameManagerInstance();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Resume()
    {
        MSSceneControllerFree.mSSceneControllerFree.SetPause(false);
        gameManager.SetGameState(GameManager.GameState.Playing);
        pauseScreen.SetActive(false);
    }

    public void Restart()
    {
        int currentLevel = menu.GetCurrentLevel().GetId();
        gameManager.SetGameState(GameManager.GameState.Playing);
        SceneManager.LoadScene(currentLevel + 1);
    }

    public void Quit()
    { 
        SceneManager.LoadScene("Menu");
        gameManager.SetGameState(GameManager.GameState.Menu);
    }
}
