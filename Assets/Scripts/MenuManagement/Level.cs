using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//very important class
//the bool passed tells whether the level has been passed or not
//and the int id is the level number
//the first level has id 1, the second has id 2 and so on...

public class Level
{
    private bool passed;
    private int id;
    private int score;
    public Level(int id)
    {
        passed = false;
        this.id = id;
        score = 0;
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
}
