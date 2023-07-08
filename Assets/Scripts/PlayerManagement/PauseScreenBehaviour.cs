using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreenBehaviour : MonoBehaviour
{
    [SerializeField] GameObject pauseScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Resume()
    {
        MSVehicleControllerFree.mSVehicleControllerFree.SetEngineAbleSound(true);
        MSSceneControllerFree.mSSceneControllerFree.SetPause(false);
        pauseScreen.SetActive(false);
    }

    public void Restart()
    {
        int currentLevel = GameManager.gameManager.GetCurrentLevel().GetId();
        SceneManager.LoadScene(currentLevel + 1);
    }

    public void Quit()
    { 
        SceneManager.LoadScene("Menu");
    }
}
