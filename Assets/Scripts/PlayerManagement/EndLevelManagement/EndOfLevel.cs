using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//this class is used to show scores to player and
//to navigate to the menu
public class EndOfLevel : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    private GameManager gameManager;
    private PlayerController player;
    private int score;

    void Start()
    {
        gameManager = GameManager.GetGameManagerInstance();
        player = PlayerController.GetPlayerControllerInstance();
    }

    void Update()
    {        
        score = player.GetScore();
        scoreText.text = "Your score: " + score + " points";
    }

    public void GoToMistakes()
    {
        gameManager.LoadScene("CheckMistakes");
    }

    public void GoToMenu()
    {
        gameManager.ChangeGameState(gameManager.GetCurrentGameState());
    }
}
