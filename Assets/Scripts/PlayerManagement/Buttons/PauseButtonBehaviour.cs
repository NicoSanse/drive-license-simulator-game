using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButtonBehaviour : MonoBehaviour
{
    [SerializeField] GameObject pauseScreen;
    private static PauseButtonBehaviour pauseButtonBehaviour;
    private GameManager gameManager;
    void Awake()
    {
        pauseButtonBehaviour = this;
    }

    void Start()
    {
        gameManager = GameManager.GetGameManagerInstance();
    }

    void Update()
    {
        
    }

    public void ClickOnPauseButton()
    {
        MSSceneControllerFree.mSSceneControllerFree.SetPause(true);
        pauseScreen.SetActive(true);
        gameManager.SetGameState(GameManager.GameState.LevelPaused);
    }

    public static PauseButtonBehaviour GetPauseButtonBehaviourInstance()
    {
        return pauseButtonBehaviour;
    }
}
