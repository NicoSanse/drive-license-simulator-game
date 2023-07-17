using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WelcomeScene : MonoBehaviour
{
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.GetGameManagerInstance();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToMenu()
    {
        gameManager.ChangeGameState(gameManager.GetCurrentGameState());
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
