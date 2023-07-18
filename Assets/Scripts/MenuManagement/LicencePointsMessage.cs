using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//this class is used by the the menu
//scene to show the licence's points

public class LicencePointsMessage : MonoBehaviour
{
    private SaveManager saveManager;
    private SaveState saveState;
    private int score;
    void Start()
    {
        saveManager = SaveManager.GetSaveManagerInstance();
        saveState = saveManager.GetSaveState();
        score = saveState.GetDriveLicensePoints();
        GetComponent<TMP_Text>().text = "Your licence's points: " + score;
    }

    void Update()
    {
        
    }
}
