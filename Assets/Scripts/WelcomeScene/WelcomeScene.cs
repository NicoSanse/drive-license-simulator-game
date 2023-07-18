using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class WelcomeScene : MonoBehaviour
{
    [SerializeField] Image firstWelcomePanel;
    private GameManager gameManager;
    public SaveState saveState;
    private SaveManager saveManager;
    private string playerName;

    void Start()
    {
        gameManager = GameManager.GetGameManagerInstance();
        saveState = SaveManager.GetSaveManagerInstance().GetSaveState();
        saveManager = SaveManager.GetSaveManagerInstance();
        ShowACanvas();
    }

    void Update()
    {
        
    }

    public void GoToMenu()
    {
        gameManager.ChangeGameState(gameManager.GetCurrentGameState());
    }

    public void GetPlayerName()
    { 
        playerName = GameObject.FindWithTag("PlayerName").GetComponent<TMP_Text>().text;
        CreateSaveState();
        GoToMenu();
    }

    //shows the first canvas if the player is new, otherwise shows the second canvas
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

    private void CreateSaveState()
    {
        saveState = new SaveState(playerName);
        saveManager.SetSaveState(saveState);
        saveManager.Save();
    }


    public void ExitGame()
    {
        Application.Quit();
    }
}
