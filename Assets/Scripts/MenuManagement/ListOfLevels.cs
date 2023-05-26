using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListOfLevels : MonoBehaviour
{
    //andranno fatte delle cose per recuperare i dati dal file di salvataggio
    private static List<Level> levels = new List<Level>();
    //questa riga è molto importante, per qualche motivo la lista va inizializzata qui
    //forse se la inizializzo nella Awake, levels verrebbe inizializzata più volte 
    //cioè quando diventano attive le classi che usano LisTOfLevels,
    //ma non saprei risalire a tutte le chiamate e non avrebbe senso perchè anche il ciclo for dovrebbe ripetersi

    // Start is called before the first frame update
    void Awake()
    {
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

    public Level getLevel(int pos)
    {
        return levels[pos];
    }

    public void setLevelPassed(int id) 
    {
        levels[id-1].setPassed(true);
    }

    public bool isLevelPassed(int id) 
    {
        return levels[id-1].isPassed();
    }

    public int Length() 
    { 
        return levels.Count;
    }

}
