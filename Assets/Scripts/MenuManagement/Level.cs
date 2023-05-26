using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
