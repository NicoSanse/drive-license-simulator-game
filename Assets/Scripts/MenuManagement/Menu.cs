using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//this class is used to manage the menu
public class Menu : MonoBehaviour
{
    [SerializeField] GameObject buttonFirstLevel, buttonSecondLevel, buttonThirdLevel,
    buttonFourthLevel, buttonFifthLevel, buttonSixthLevel;

    private static Menu menu;
    private static List<Level> listOfLevels;
    private static Level currentLevel;
    private GameManager gameManager;
    private SaveManager saveManager;
    private SaveState saveState;

    void Awake()
    {
        menu = this;
    }

    //here i update the content of the menu. I just want to see updated the levels that 
    //i have passed through the little image of the locker on the right of the button
    void Start()
    {
        gameManager = GameManager.GetGameManagerInstance();
        saveManager = SaveManager.GetSaveManagerInstance();
        saveState = saveManager.GetSaveState();
        listOfLevels = saveState.GetListOfLevels();

        for (int i = 0; i < listOfLevels.Count; i++)
        {
            if (listOfLevels[i].IsPassed())
            {
                switch (i)
                {
                    case 0:
                        buttonSecondLevel.transform.GetChild(1).gameObject.SetActive(false);
                        break;
                    case 1:
                        buttonThirdLevel.transform.GetChild(1).gameObject.SetActive(false);
                        break;
                    case 2:
                        buttonFourthLevel.transform.GetChild(1).gameObject.SetActive(false);
                        break;
                    case 3:
                        buttonFifthLevel.transform.GetChild(1).gameObject.SetActive(false);
                        break;
                    case 4:
                        buttonSixthLevel.transform.GetChild(1).gameObject.SetActive(false);
                        break;
                    default:
                        break;
                }
            }
        }
    }


    //finds the right level to be played and go check whether it can be played or not
    public void StartLevel(GameObject button) 
    { 
        switch (button.tag)
        {
            case "FirstLevelButton":
                StartFirstLevel();
                break;
            case "SecondLevelButton":
                CheckLevel(0);
                break;
            case "ThirdLevelButton":
                CheckLevel(1);
                break;
            case "FourthLevelButton":
                CheckLevel(2);
                break;
            case "FifthLevelButton":
                CheckLevel(3);
                break;
            case "SixthLevelButton":
                CheckLevel(4);
                break;
            default:
                print(button.tag + " is not a valid tag");
                break;
        }
    }

    //the first level is always available
    private void StartFirstLevel()
    {
        SetCurrentLevel(listOfLevels[0]);
        gameManager.ChangeGameState(gameManager.GetCurrentGameState(), 2);
    }


    //checks whether a level can be played or not. I want a level to be available only if the previous one was passed
    //if a level can ben played, the current level is set and the scene is loaded
    private void CheckLevel(int position) 
    {
        if (listOfLevels[position].IsPassed())
        {
            SetCurrentLevel(listOfLevels[position + 1]);
            gameManager.ChangeGameState(gameManager.GetCurrentGameState(), position + 3);
        }
        else
        {
            print("Level " + (position + 2) + " is locked");
        }
    }


    public List<Level> GetListOfLevels()
    {
        return listOfLevels;
    }

    public Level GetCurrentLevel()
    {
        return currentLevel;
    }

    private void SetCurrentLevel(Level level)
    {
        currentLevel = level;
    }

    public static Menu GetMenuInstance()
    {
        return menu;
    }

    //makes quit the game
    public void ExitGame()
    {
        Application.Quit();
    }

}
