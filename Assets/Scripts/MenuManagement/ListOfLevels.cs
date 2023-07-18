using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListOfLevels : MonoBehaviour
{
    private static List<Level> levels;
    

    void Awake()
    {

    }

    void Start()
    {
    }

    void Update()
    {
        
    }

    public static List<Level> GetLevels() 
    {
        return levels;
    }

    public Level GetLevel(int pos)
    {
        return levels[pos];
    }

    public void SetLevelPassed(int id) 
    {
        levels[id-1].SetPassed(true);
    }

    public bool IsLevelPassed(int id) 
    {
        return levels[id-1].IsPassed();
    }

    public int Length() 
    { 
        return levels.Count;
    }

}
