using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scores : MonoBehaviour
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

        GetComponent<TMP_Text>().text = "Scores: " +  level.GetScore();
    }

    void Update()
    {
        
    }
}
