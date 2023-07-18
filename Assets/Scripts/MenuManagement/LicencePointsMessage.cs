using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LicencePointsMessage : MonoBehaviour
{
    private SaveState saveState;
    private int score;
    void Start()
    {
        saveState = SaveManager.GetSaveManagerInstance().GetSaveState();
        score = saveState.GetDriveLicensePoints();
        GetComponent<TMP_Text>().text = "Your licence's points: " + score;
        
        print(saveState.GetHashCode() + ". CCC");
    }

    void Update()
    {
        
    }
}
