using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//this class collects the mistakes the user made 
//it can happen in two ways:
//if called from end of level, it gets the id of the level from the menu
//otherwise it gets the id of the level from the inspector
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
        gameManager.SetGameState(GameManager.GameState.Menu);
        SceneManager.LoadScene("Menu");
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
