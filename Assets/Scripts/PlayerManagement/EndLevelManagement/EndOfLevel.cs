using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//this class is used to show scores to player and
//to navigate to the menu
public class EndOfLevel : MonoBehaviour
{
    private GameManager gameManager;
    private PlayerController player;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text mistakeText;
    private int score;
    private string lastMistakes;

    void Start()
    {
        gameManager = GameManager.GetGameManagerInstance();
        player = PlayerController.GetPlayerControllerInstance();
    }

    void Update()
    {        
        score = player.GetScore();
        scoreText.text = "Your score: " + score + " points";
        lastMistakes = GetLastMistake();
        mistakeText.text = lastMistakes;
    }

    public void GoToMenu()
    {
        gameManager.ChangeGameState(gameManager.GetCurrentGameState());
    }

    private string GetLastMistake()
    {
        List<string> mistakes = player.GetTempMistakes();
        if (mistakes.Count > 0)
        {
            return mistakes[mistakes.Count - 1];
        }
        else 
        { 
            return ""; 
        }
    }
}
