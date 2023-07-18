using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class is just used by the button in the UI
//to navigate to the menu
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
    }
}
