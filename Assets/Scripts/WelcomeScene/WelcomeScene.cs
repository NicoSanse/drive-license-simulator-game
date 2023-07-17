using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class WelcomeScene : MonoBehaviour
{
    [SerializeField] Image firstWelcomePanel;
    private GameManager gameManager;
    private SaveState saveState;
    private string playerName;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.GetGameManagerInstance();
        saveState = SaveState.GetSaveStateInstance();
        if (saveState != null){
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

    // Update is called once per frame
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
        saveState = new SaveState(name);
        gameManager.ChangeGameState(gameManager.GetCurrentGameState());
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
