using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

//we use this class to manage data
public class SaveManager : MonoBehaviour
{
    private static SaveManager saveManager;
    private SaveState saveState;
    private BinaryFormatter binaryFormatter;
    private const string SAVE_STATE_FILE = "dati.ss";

    void Awake() 
    { 
        saveManager = this;
        binaryFormatter = new BinaryFormatter();
        Load();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    //we use this method to get data from a local file
    private void Load()
    {
        try 
        {
            FileStream file = new FileStream(Application.persistentDataPath + SAVE_STATE_FILE, FileMode.Open, FileAccess.Read);
            saveState = (SaveState) binaryFormatter.Deserialize(file);
            file.Close();
        }
        //if the file doesn't exist we create it once
        catch (System.Exception e)
        {
            Save();
        }
    }

    //we use this method to save data in a local file
    public void Save()
    {
        if (saveState != null)
        {
            FileStream file = new FileStream(Application.persistentDataPath + SAVE_STATE_FILE, FileMode.OpenOrCreate, FileAccess.Write);
            saveState.SetLastTimeSave(System.DateTime.Now);
            binaryFormatter.Serialize(file, saveState);
            file.Close();
        }
    }

    public SaveState GetSaveState() 
    { 
        return saveState;
    }

    public void SetSaveState(SaveState saveState) 
    { 
        this.saveState = saveState;
    }

    public static SaveManager GetSaveManagerInstance() 
    { 
        return saveManager;
    }
}
