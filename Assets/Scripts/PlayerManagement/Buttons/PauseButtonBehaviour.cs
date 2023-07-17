using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButtonBehaviour : MonoBehaviour
{
    [SerializeField] GameObject pauseScreen;
    private static PauseButtonBehaviour pauseButtonBehaviour;
    private GameManager gameManager;
    private bool wasPauseButtonClicked;
    void Awake()
    {
        pauseButtonBehaviour = this;
    }

    void Start()
    {
        gameManager = GameManager.GetGameManagerInstance();
        wasPauseButtonClicked = false;
    }

    void Update()
    {
        
    }

    public void ClickOnPauseButton()
    {
        SetPauseButtonClicked(true);
        MSSceneControllerFree.mSSceneControllerFree.SetPause(true);
        pauseScreen.SetActive(true);
        gameManager.ChangeGameState(gameManager.GetCurrentGameState());
        SetPauseButtonClicked(false);
    }

    public static PauseButtonBehaviour GetPauseButtonBehaviourInstance()
    {
        return pauseButtonBehaviour;
    }

    public void SetPauseButtonClicked(bool value)
    {
        wasPauseButtonClicked = value;
    }

    public bool WasPauseButtonClicked()
    {
        return wasPauseButtonClicked;
    }
}
