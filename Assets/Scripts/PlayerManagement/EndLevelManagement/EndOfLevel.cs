using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfLevel : MonoBehaviour
{
    private GameManager gameManager;
    void Start()
    {
        gameManager = GameManager.GetGameManagerInstance();
    }

    void Update()
    {
        
    }

    public void GoToMenu()
    {
        gameManager.ChangeGameState(gameManager.GetCurrentGameState());
        SceneManager.LoadScene("Menu");
    }
}
