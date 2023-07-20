using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class represents a level
//the first level has id 1, the second has id 2 and so on...

[System.Serializable]
public class Level
{
    private bool passed;
    private int id;
    private int score;
    private List<string> mistakes;
    private string description;
    public Level(int id)
    {
        passed = false;
        this.id = id;
        score = 0;
        mistakes = new List<string>();
        description = "";
    }

    public void SetPassed(bool passed) 
    {
        this.passed = passed;
    }

    public bool IsPassed() 
    {
        return passed;
    }

    public void SetId(int id) 
    {
        this.id = id;
    }

    public int GetId() 
    {
        return id;
    }

    public void SetScore(int score) 
    {
        this.score = score;
    }

    public int GetScore() 
    {
        return score;
    }

    public string GetDescription() 
    {
        return description;
    }

    public void SetDescription(string description) 
    {
        this.description = description;
    }

    public void AddMistake(string mistake) 
    {
        mistakes.Add(mistake);
    }

    public List<string> GetMistakes() 
    {
        return mistakes;
    }

    public void ResetMistakes() 
    {
        mistakes.Clear();
    }


}
