using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoCollection : MonoBehaviour
{
    private static InfoCollection infoCollection;
    private GameManager gameManager;
    private Menu menu;
    private Level selectedLevel;
    private string description;

    void Awake()
    {
        infoCollection = this;
    }

    void Start()
    {
        menu = Menu.GetMenuInstance();
        gameManager = GameManager.GetGameManagerInstance();
        selectedLevel = menu.GetCurrentLevel();
        description = selectedLevel.GetDescription();
    }

    void Update()
    {
        
    }
    
    public void BackToMenu()
    {
        gameManager.ChangeGameState(gameManager.GetCurrentGameState(), 1);
    }

    public Level GetSelectedLevel()
    {
        return selectedLevel;
    }

    public static InfoCollection GetInfoCollectionInstance()
    {
        return infoCollection;
    }
}
