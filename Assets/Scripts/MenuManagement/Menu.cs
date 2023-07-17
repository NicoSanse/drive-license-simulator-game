using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject 
    buttonFirstLevel, buttonSecondLevel, buttonThirdLevel, buttonFourthLevel, 
    buttonFifthLevel, buttonSixthLevel, buttonSeventhLevel;

    private static Menu menu;
    private static ListOfLevels listOfLevels;
    private static Level currentLevel;
    private GameManager gameManager;

    void Awake()
    {
        menu = this;
        listOfLevels = gameObject.AddComponent<ListOfLevels>();
    }

    //here i update the content of the menu. I just want to see updated the levels that 
    //i have passed through the little image of the locker on the right of the button
    void Start()
    {
        gameManager = GameManager.GetGameManagerInstance();

        for (int i = 0; i < listOfLevels.Length(); i++)
        {
            if (listOfLevels.GetLevel(i).IsPassed())
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
                        buttonFifthLevel.transform.GetChild(1).gameObject.SetActive(false);
                        break;
                    case 5:
                        buttonFifthLevel.transform.GetChild(1).gameObject.SetActive(false);
                        break;
                    case 6:
                        buttonFifthLevel.transform.GetChild(1).gameObject.SetActive(false);
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
            case "SeventhLevelButton":
                CheckLevel(5);
                break;
            default:
                print(button.tag + " is not a valid tag");
                break;
        }
    }

    private void StartFirstLevel()
    {
        SetCurrentLevel(listOfLevels.GetLevel(0));
        gameManager.ChangeGameState(gameManager.GetCurrentGameState(), 2);
    }


    //checks whether a level can be played or not. I want a level to be available only if the previous one has been passed
    //if a level can ben played, the current level is set and the scene is loaded
    //The first level is always available
    private void CheckLevel(int position) 
    {
        if (listOfLevels.GetLevel(position).IsPassed())
        {
            SetCurrentLevel(listOfLevels.GetLevel(position + 1));
            gameManager.ChangeGameState(gameManager.GetCurrentGameState(), position + 3);
        }
        else
        {
            print("Level " + (position + 2) + " is locked");
        }
    }


    public ListOfLevels GetListOfLevels()
    {
        return listOfLevels;
    }

    public Level GetCurrentLevel()
    {
        return currentLevel;
    }

    public void SetCurrentLevel(Level level)
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
        print("ExitGame");
        Application.Quit();
    }

}
