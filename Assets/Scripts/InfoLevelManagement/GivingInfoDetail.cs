using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GivingInfoDetail : MonoBehaviour
{
    private InfoCollection infoCollection;
    private TMP_Text level;
    private TMP_Text description;

    void Start()
    {
        infoCollection = InfoCollection.GetInfoCollectionInstance();
        level = transform.GetChild(0).GetComponent<TMP_Text>();
        description = transform.GetChild(1).GetComponent<TMP_Text>();

        WriteLevel();
        WriteDescription();
    }

    void Update()
    {
        
    }

    private void WriteLevel()
    {
        level.text = "In the " + infoCollection.GetSelectedLevel().GetId() + "° level you are going to see: ";
    }

    private void WriteDescription()
    {
        description.text = infoCollection.GetSelectedLevel().GetDescription();
    }
}
