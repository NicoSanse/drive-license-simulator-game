using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClutchBehaviour : MonoBehaviour
{
    [SerializeField] GameObject loadingBar;
    public static ClutchBehaviour clutch;
    public enum Gears {Gear1 = 1, Gear2 = 2, Gear3 = 3, Gear4 = 4, Gear5 = 5, GearR = -1, GearN = 0};
    private bool clutchPressed;
    private Coroutine coroutineLoadBar;
    private int currentGear;


    void Awake()
    {
        clutch = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        clutchPressed = false;
        currentGear = (int) Gears.Gear1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGear(int gear) 
    {
        currentGear = gear;
    }

    public int GetCurrentGear() 
    {
        return currentGear;
    }

    public bool IsClutchPressed()
    {
        return clutchPressed;
    }

    public void SetClutchPressed(bool clutch)
    {
        clutchPressed = clutch;
    }

    public void ClutchIsPressed()
    {
        SetClutchPressed(true);
        //qua bisogna fare cose per gestire l'effettivo cambio marcia
        //sfruttando il valore clutchPressed
        //le istruzioni che seguono assumono che il cambio marcia sia già avvenuto
        loadingBar.SetActive(true);
        coroutineLoadBar = StartCoroutine(LoadBar(FindTimeForChangeTheGear(currentGear)));
    }

    public void ClutchIsReleased()
    {
        StopCoroutine(coroutineLoadBar);

        if(currentGear == 0)
        {
            print("auto in folle");
        }
        else if (currentGear != 0 && loadingBar.GetComponent<Slider>().value > 0.9f) 
        {
            print("Clutch Released ok");
        }
        else
        {
            print("Clutch released too early");
            //far spegnere la macchina
        }

        print("current gear: " + currentGear);

        SetClutchPressed(false);
        loadingBar.SetActive(false);
        EmptyBar();
    }

    private float FindTimeForChangeTheGear(int gear) 
    { 
        switch (gear) 
        { 
            case 0:
                return 0f;
            case 1:
                return 0.05f;
            case 2:
                return 0.1f;
            case 3: 
                return 0.12f;
            case 4:
                return 0.15f;
            case 5:
                return 0.2f;
            case -1:
                return 0.05f;
            default:
                return 0f;
        }
    }

    private IEnumerator LoadBar(float incrementValue)
    {

        while(loadingBar.GetComponent<Slider>().value <= 1f)
        {
            yield return new WaitForSeconds(0.1f);
            loadingBar.GetComponent<Slider>().value += incrementValue;
        }

        yield return null;
    }

    private void EmptyBar()
    {
        loadingBar.GetComponent<Slider>().value = 0f;
    }
}
