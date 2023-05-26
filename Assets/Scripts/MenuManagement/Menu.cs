using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject 
    buttonFirstLevel, buttonSecondLevel, buttonThirdLevel, buttonFourthLevel, 
    buttonFifthLevel, buttonSixthLevel, buttonSeventhLevel;


    //here i update the content of the menu. I just want to see updated the levels that 
    //i have passed through the little image of the locker on the right of the button
    void Start()
    {
        for (int i = 0; i < GameManager.gameManager.GetListOfLevels().Length(); i++)
        {
            if (GameManager.gameManager.GetListOfLevels().GetLevel(i).IsPassed())
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


    //i go find the right level to be played and go check whether it can be played or not
    public void StartLevel(GameObject button) 
    { 
        switch (button.tag)
        {
            case "FirstLevelButton":
                print("StartFirstLevel");
                GameManager.gameManager.SetCurrentLevel(GameManager.gameManager.GetListOfLevels().GetLevel(0));
                SceneManager.LoadScene("LevelOne");
                break;
            case "SecondLevelButton":
                print("StartSecondLevel");
                CheckLevel(0);
                break;
            case "ThirdLevelButton":
                print("StartThirdLevel");
                CheckLevel(1);
                break;
            case "FourthLevelButton":
                print("StartFourthLevel");
                CheckLevel(2);
                break;
            case "FifthLevelButton":
                print("StartFifthLevel");
                CheckLevel(3);
                break;
            case "SixthLevelButton":
                print("StartSixthLevel");
                CheckLevel(4);
                break;
            case "SeventhLevelButton":
                print("StartSeventhLevel");
                CheckLevel(5);
                break;
            default:
                print(button.tag + " is not a valid tag");
                break;
        }
    }

    //checks whether a level can be played or not. I want a level to be available only if the previous one has been passed
    //if a level can ben played, the current level is set and the scene is loaded
    //The first level is always available
    public void CheckLevel(int position) 
    {
        if (GameManager.gameManager.GetListOfLevels().GetLevel(position).IsPassed())
        {
            GameManager.gameManager.SetCurrentLevel(GameManager.gameManager.GetListOfLevels().GetLevel(position + 1));
            SceneManager.LoadScene(position + 3);
        }
        else
        {
            print("Level " + (position + 2) + " is locked");
        }
    }
    


    public void ExitGame()
    {
        print("ExitGame");
        Application.Quit();
    }

}
