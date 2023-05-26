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

    public void setPassed(bool passed) {
        this.passed = passed;
    }

    public bool isPassed() {
        return passed;
    }

    public void setId(int id) {
        this.id = id;
    }

    public int getId() {
        return id;
    }
}
