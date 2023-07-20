using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InfoCollection : MonoBehaviour
{
    private static InfoCollection infoCollection;
    private Menu menu;
    private Level selectedLevel;
    private string description;

    void Awake()
    {
        infoCollection = this;
    }

    void Start()
    {
        menu = Menu.GetMenuInstance();
        selectedLevel = menu.GetCurrentLevel();
        description = selectedLevel.GetDescription();
    }

    void Update()
    {
        
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public Level GetSelectedLevel()
    {
        return selectedLevel;
    }

    public static InfoCollection GetInfoCollectionInstance()
    {
        return infoCollection;
    }
}
