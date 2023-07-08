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
    public Level()
    {
        passed = false;
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
}
