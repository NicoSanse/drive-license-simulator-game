using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClutchBehaviour : MonoBehaviour
{
    [SerializeField] GameObject loadingBar;
    public static ClutchBehaviour clutch;
    public enum Gear { Gear1 = 1, Gear2 = 2, Gear3 = 3, Gear4 = 4, Gear5 = 5, GearR = -1, GearN = 0 };
    private bool clutchPressed;
    private Coroutine coroutineLoadBarAndChangeScale;
    private Gear currentGear;


    void Awake()
    {
        clutch = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        clutchPressed = false;
        currentGear = Gear.Gear1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetGear(Gear gear)
    {
        currentGear = gear;
    }

    public Gear GetCurrentGear()
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

    //triggered by GUIManager class, starts the coroutine to decrease the scale
    public void ClutchIsPressed()
    {
        SetClutchPressed(true);
        StartCoroutine(DecreaseScale());
    }

    //triggered by ChangeGearPanelBehaviour class, starts the coroutine
    //to increase the value of the bar and the scale of the clutch
    public void GearHasBeenChanged() 
    {
        loadingBar.SetActive(true);
        coroutineLoadBarAndChangeScale = StartCoroutine(LoadBarAndChangeScale(FindTimeForChangeTheGear(currentGear), GetComponent<RectTransform>()));
    }

    //triggered by GUIManger class, stops the coroutine and checks if the clutch was released
    //in a proper time
    public void ClutchIsReleased()
    {
        if (coroutineLoadBarAndChangeScale != null)
        { 
            StopCoroutine(coroutineLoadBarAndChangeScale); 
        }

        if (currentGear == 0)
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

        SetClutchPressed(false);
        MakeDisappearTheLoadingBar();
        EmptyBar();
        Car.car.NotifyGearChanged();
    }

    //!!!!!forse la seguente funzione si può splittare in due distinte

    //increases the value of the bar and increases the scale of the clutch
    //the rate of increment is split in 50 to increase the scale, though i can't
    //really remember why
    private IEnumerator LoadBarAndChangeScale(float incrementValue, RectTransform rectTransform)
    {
        yield return new WaitForSeconds(0.2f);

        while (loadingBar.GetComponent<Slider>().value <= 1f && rectTransform.localScale.x < 0.1f && rectTransform.localScale.y < 0.3f)
        {
            yield return new WaitForSeconds(0.01f);
            loadingBar.GetComponent<Slider>().value += incrementValue;
            loadingBar.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = Color.Lerp(Color.red, Color.green, loadingBar.GetComponent<Slider>().value);
            rectTransform.localScale += new Vector3(incrementValue/50, (incrementValue/50) * 3, 0f);
        }

        yield return null;
    }

    //decreases the scale of the clutch, can't use the CommonPedalsBehaviours
    //because interfers with other funcionalities
    private IEnumerator DecreaseScale()
    {
        while (GetComponent<RectTransform>().localScale.x > 0.08f && GetComponent<RectTransform>().localScale.y > 0.24f)
        {
            GetComponent<RectTransform>().localScale += new Vector3(-0.001f, -0.001f * 3, 0f);
            yield return new WaitForSeconds(0.001f);
        }
    }

    //sets to 0 the value of the bar
    private void EmptyBar()
    {
        loadingBar.GetComponent<Slider>().value = 0f;
    }

    //makes the bar inactive
    private void MakeDisappearTheLoadingBar()
    {
        loadingBar.SetActive(false);
    }

    //finds the best time for each gear(actually its a rate value)
    private float FindTimeForChangeTheGear(Gear gear)
    {
        switch (gear)
        {
            case Gear.Gear1:
                return 0.005f;
            case Gear.Gear2:
                return 0.01f;
            case Gear.Gear3:
                return 0.015f;
            case Gear.Gear4:
                return 0.02f;
            case Gear.Gear5:
                return 0.025f;
            case Gear.GearR:
                return 0.005f;
            case Gear.GearN:
                return 0f;
            default:
                return 0f;
        }
    }
}
