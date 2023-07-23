using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDescriptions
{
    public string[] descriptions;
    private string description;
    public LevelDescriptions()
    {
        descriptions = new string[6];
        descriptions[0] = FirstDescription();
        descriptions[1] = SecondDescription();
        descriptions[2] = ThirdDescription();
        descriptions[3] = FourthDescription();
        descriptions[4] = FifthDescription();
        descriptions[5] = SixthDescription();
    }

    private string FirstDescription()
    {
        description = " - horizontal signage \n - vertical signage \n";
        return description;
    }

    private string SecondDescription()
    {
        description += " - roundabouts \n - intersections \n - traffic lights \n";
        return description;
    }

    private string ThirdDescription()
    {
        description += " - pedestrian crossings \n - speed limits";
        return description;
    }

    private string FourthDescription()
    {
        description += " - priority \n - overtaking \n";
        return description;
    }

    private string FifthDescription()
    {
        description += " - drive at nightime \n";
        return description;
    }

    private string SixthDescription()
    {
        description = "This level is a recap of all the previous levels. \n";
        return description;
    }
}
