using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

//this class gives functionalities to the welcome scene
public class WelcomeScene : MonoBehaviour
{
    [SerializeField] Image firstWelcomePanel;
    private GameManager gameManager;
    private SaveManager saveManager;
    public SaveState saveState;
    private string playerName;

    void Start()
    {
        gameManager = GameManager.GetGameManagerInstance();
        saveManager = SaveManager.GetSaveManagerInstance();
        saveState = saveManager.GetSaveState();
        ShowACanvas();
    }

    void Update()
    {
        
    }

    //stores the player name
    //this is called only once at first access
    public void GetPlayerName()
    { 
        playerName = GameObject.FindWithTag("PlayerName").GetComponent<TMP_Text>().text;
        CreateSaveState();
        GoToMenu();
    }

    //shows the "login" canvas if the player is new, otherwise shows the "welcomeback" one
    private void ShowACanvas() {
        if (saveState != null)
        {
            firstWelcomePanel.gameObject.SetActive(false);
            GetComponentsInChildren<Image>(true)[0].gameObject.SetActive(true);
            GetComponentsInChildren<TMP_Text>()[0].text = "Welcome back, " + saveState.GetNameOfPlayer() + "!";
        }
        else
        {
            firstWelcomePanel.gameObject.SetActive(true);
            GetComponentsInChildren<Image>(true)[0].gameObject.SetActive(false);
        }
    }

    //creates the save state with the player name
    private void CreateSaveState()
    {
        saveState = new SaveState(playerName);
        saveManager.SetSaveState(saveState);
        saveManager.Save();
    }

    public void GoToMenu()
    {
        gameManager.ChangeGameState(gameManager.GetCurrentGameState());
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
