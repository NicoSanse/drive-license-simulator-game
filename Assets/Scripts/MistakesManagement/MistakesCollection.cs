using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class collects the mistakes the user made 
//the scene can be called from the menu or at the end of a level
public class MistakesCollection : MonoBehaviour
{
    private static MistakesCollection mistakesCollection;
    private GameManager gameManager;
    private SaveManager saveManager;
    private SaveState saveState;
    private Menu menu;
    private Level selectedLevel;
    private List<string> mistakes;

    void Awake()
    {
        mistakesCollection = this;
    }

    void Start()
    {
        gameManager = GameManager.GetGameManagerInstance();
        saveManager = SaveManager.GetSaveManagerInstance();
        saveState = saveManager.GetSaveState();
        menu = Menu.GetMenuInstance();
        selectedLevel = menu.GetCurrentLevel();
        mistakes = selectedLevel.GetMistakes();
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

    public List<string> GetMistakes()
    {
        return mistakes;
    }

    public static MistakesCollection GetMistakesCollectionInstance()
    {
        return mistakesCollection;
    }
}
