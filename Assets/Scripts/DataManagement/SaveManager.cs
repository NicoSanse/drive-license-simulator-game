using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveManager : MonoBehaviour
{
    private static SaveManager saveManager;
    private SaveState saveState;
    private BinaryFormatter bf;
    private const string SAVE_STATE_FILE = "dati.ss";

    void Awake() 
    { 
        saveManager = this;
        bf = new BinaryFormatter();
        Load();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }


    private void Load()
    {
        try 
        {
            //FileStream file = new FileStream(SAVE_STATE_FILE, FileMode.Open, FileAccess.Read);
            FileStream file = new FileStream(Application.persistentDataPath + SAVE_STATE_FILE, FileMode.Open, FileAccess.Read);
            saveState = (SaveState)bf.Deserialize(file);
            file.Close();
        }
        catch (System.Exception e)
        {
            Save();
        }
    }

    public void Save()
    {
        //todo: get the player name from the input field
        if (saveState != null)
        {
            try
            {
                //FileStream file = new FileStream(SAVE_STATE_FILE, FileMode.OpenOrCreate, FileAccess.Write);
                FileStream file = new FileStream(Application.persistentDataPath + SAVE_STATE_FILE, FileMode.OpenOrCreate, FileAccess.Write);
                saveState.SetLastTimeSave(System.DateTime.Now);
                bf.Serialize(file, saveState);
                file.Close();
            }
            catch (System.Exception e)
            {
                Debug.Log(e.Message);
            }
        }
    }



    public static SaveManager GetSaveManagerInstance() 
    { 
        return saveManager;
    }
}
