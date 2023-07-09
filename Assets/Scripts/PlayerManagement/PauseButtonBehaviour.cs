using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButtonBehaviour : MonoBehaviour
{
    [SerializeField] GameObject pauseScreen;
    public static PauseButtonBehaviour pauseButtonBehaviour;
    void Awake()
    {
        pauseButtonBehaviour = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ClickOnPauseButton()
    {
        MSSceneControllerFree.mSSceneControllerFree.SetPause(true);
        pauseScreen.SetActive(true);
    }
}
