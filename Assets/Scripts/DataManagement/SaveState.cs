using System;

[System.Serializable]
public class SaveState
{
    private int driveLicensePoints;
    private DateTime lastTimeSave;

    public SaveState()
    { 
        driveLicensePoints = 0;
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
}
