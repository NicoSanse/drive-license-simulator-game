using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class shows a little image representing a level passed in the menu

public class LevelCompleted : MonoBehaviour
{
    private SaveManager saveManager;
    private SaveState saveState;
    private Level level;
    [SerializeField] private int levelPos;

    void Start()
    {
        saveManager = SaveManager.GetSaveManagerInstance();
        saveState = saveManager.GetSaveState();
        level = saveState.GetListOfLevels()[levelPos];

        if (level.IsPassed())
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    void Update()
    {
        
    }
}
