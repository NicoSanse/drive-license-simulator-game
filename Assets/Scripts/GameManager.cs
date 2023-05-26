using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    private static ListOfLevels listOfLevels;
    private static Level currentLevel;
    void Awake() 
    { 
        gameManager = this;
        listOfLevels = new ListOfLevels();
    }

    // Start is called before the first frame update
    void Start()
    {
        //andranno fatte delle cose per recuperare i dati dal file di salvataggio
        //in modo da non perdere i dati delle pardite ad ogni avvio
        //per ora li inizializzo a mano
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public ListOfLevels getListOfLevels() 
    { 
        return listOfLevels;
    }

    public Level getCurrentLevel() 
    { 
        return currentLevel;
    }

    public void setCurrentLevel(Level level) 
    { 
        currentLevel = level;
    }

    //set the current level as passed and come back to the menu
    public static void LevelPassed()
    {
        currentLevel.setPassed(true);
        SceneManager.LoadScene("Menu");
    }
}
