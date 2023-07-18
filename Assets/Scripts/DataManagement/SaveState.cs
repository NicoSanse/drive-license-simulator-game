using System;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class SaveState
{
    private string nameOfPlayer;
    private int driveLicensePoints;
    private List<Level> listOfLevels;
    private DateTime lastTimeSave;

    public SaveState(String nameOfPlayer)
    {
        this.nameOfPlayer = nameOfPlayer;
        driveLicensePoints = 0;
        InitializeListOfLevels();
        lastTimeSave = DateTime.Now;
    }

    public int GetDriveLicensePoints()
    { 
        return driveLicensePoints;
    }

    public void SetDriveLicensePoints(int points)
    { 
        driveLicensePoints = points;
    }

    public DateTime GetLastTimeSave()
    { 
        return lastTimeSave;
    }

    public void SetLastTimeSave(DateTime time)
    { 
        lastTimeSave = time;
    }
    
    public List<Level> GetListOfLevels()
    { 
        return listOfLevels;
    }

    public void SetListOfLevels(List<Level> listOfLevels)
    { 
        this.listOfLevels = listOfLevels;
    }
    
    public void SetNameOfPlayer(String name)
    { 
        nameOfPlayer = name;
    }

    public String GetNameOfPlayer()
    { 
        return nameOfPlayer;
    }

    //creating the list of levels
    private void InitializeListOfLevels()
    {
        listOfLevels = new List<Level>();
        for (int i = 0; i < 5; i++)
        {
            listOfLevels.Add(new Level(i + 1));
        }
    }
}
