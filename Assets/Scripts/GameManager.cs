using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager gameManager;
    public static ListOfLevels listOfLevels;
    public static Level currentLevel;
    void Awake() { 
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

    public static ListOfLevels getListOfLevels() { 
        return listOfLevels;
    }

    public static Level getCurrentLevel() { 
        return currentLevel;
    }

    public static void setCurrentLevel(Level level) { 
        currentLevel = level;
    }

    //set the current level as passed and come back to the menu
    public static void LevelPassed()
    {
        //ho appea ggiunto il ciclo for, ma non ha funzionato
        currentLevel.setPassed(true);
        for (int i = 0; i < listOfLevels.Length(); i++)
        {
            if (listOfLevels.getLevel(i).getId() == currentLevel.getId())
            {
                listOfLevels.getLevel(i).setPassed(true);
            }
        }
        SceneManager.LoadScene("Menu");
    }
}
