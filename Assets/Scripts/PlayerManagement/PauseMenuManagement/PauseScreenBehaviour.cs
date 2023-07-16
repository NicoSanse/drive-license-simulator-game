using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreenBehaviour : MonoBehaviour
{
    [SerializeField] GameObject pauseScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Resume()
    {
        MSSceneControllerFree.mSSceneControllerFree.SetPause(false);
        GameManager.gameManager.SetGameState(GameManager.GameState.Playing);
        pauseScreen.SetActive(false);
    }

    public void Restart()
    {
        int currentLevel = Menu.menu.GetCurrentLevel().GetId();
        GameManager.gameManager.SetGameState(GameManager.GameState.Playing);
        SceneManager.LoadScene(currentLevel + 1);
    }

    public void Quit()
    { 
        SceneManager.LoadScene("Menu");
        GameManager.gameManager.SetGameState(GameManager.GameState.Menu);
    }
}
