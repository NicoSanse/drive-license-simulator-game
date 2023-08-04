using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GivingDetails : MonoBehaviour
{
    private MistakesCollection mistakesCollection;
    private TMP_Text level;
    private TMP_Text mistakes;

    void Start()
    {
        mistakesCollection = MistakesCollection.GetMistakesCollectionInstance();
        level = transform.GetChild(0).GetComponent<TMP_Text>();
        mistakes = transform.GetChild(1).GetComponent<TMP_Text>();

        WriteLevel();
        WriteMistakes();   
    }

    void Update()
    {
        
    }

    private void WriteLevel()
    {
        level.text = "Mistakes you made in " + mistakesCollection.GetSelectedLevel().GetId() + "° level";
    }

    private void WriteMistakes()
    {
        List<string> mistakesList = mistakesCollection.GetMistakes();
        foreach (string mistake in mistakesList)
        {
            mistakes.text += mistake + "\n";
        }
    }
}
