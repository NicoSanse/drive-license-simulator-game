using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//this class is used to show scores to player and
//to navigate to the menu
public class EndOfLevel : MonoBehaviour
{
    private static EndOfLevel endOfLevel;
    private GameManager gameManager;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text mistakeText;

    void Awake()
    { 
        endOfLevel = this;
    }

    void Start()
    {
        gameManager = GameManager.GetGameManagerInstance();
    }

    void Update()
    {
        
    }

    public void Initialization(string mistake, int score)
    {
        if (score < 0) score = 0;
        if (score > 100) score = 100;
        scoreText.text = "Your score: " + score + " points";
        mistakeText.text = mistake;
    }

    public void GoToMenu()
    {
        gameManager.ChangeGameState(gameManager.GetCurrentGameState());
    }

    public static EndOfLevel GetEndOfLevelInstance()
    {
        return endOfLevel;
    }
}
