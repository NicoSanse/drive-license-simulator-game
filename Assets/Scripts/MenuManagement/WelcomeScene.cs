using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WelcomeScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
        GameManager.gameManager.SetGameState(GameManager.GameState.Menu);
    }

    public void ExitGame()
    {
        print("ExitGame");
        Application.Quit();
    }
}
