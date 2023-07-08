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

    void Awake()
    {
        for (int i = 0; i < 10; i++)
        {
            levels.Add(new Level());
            levels[i].SetId(i + 1);
        }
    }

    void Start() 
    {

    }

    void Update()
    {
        
    }

    public List<Level> GetLevels() 
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
