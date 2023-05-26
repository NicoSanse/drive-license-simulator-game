using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListOfLevels : MonoBehaviour
{

    public static List<Level> levels;

    // Start is called before the first frame update
    void Awake()
    {
        //andranno fatte delle cose per recuperare i dati dal file di salvataggio
        levels = new List<Level>();
        for (int i = 0; i < 10; i++)
        {
            levels.Add(new Level());
            levels[i].setId(i + 1);
        }
    }

    void Start() 
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<Level> getLevels() 
    {
        return levels;
    }

    public Level getLevel(int id)
    {
        return levels[id];
    }

    public void setLevelPassed(int id) 
    {
        levels[id-1].setPassed(true);
    }

    public bool isLevelPassed(int id) 
    {
        return levels[id-1].isPassed();
    }

    public int Length() { 
        return levels.Count;
    }

}
