using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//this class models the clutch
public class ClutchBehaviour : MonoBehaviour
{
    [SerializeField] GameObject loadingBar;
    private static ClutchBehaviour clutch;
    public enum Gear { Gear1 = 1, Gear2 = 2, Gear3 = 3, Gear4 = 4, Gear5 = 5, GearR = -1, GearN = 0 };
    private static Gear currentGear;
    private bool clutchPressed;
    private Coroutine coroutineLoadBarAndChangeScale;
    private Car car;
    private Rigidbody carRigidbody;
    private ParticlesManagement particles;
    private SaveManager saveManager;
    private SaveState saveState;
    private Menu menu;
    private Level currentLevel;
    private PlayerController player;
    private List<string> tempMistakes;


    void Awake()
    {
        clutch = this;
    }

    void Start()
    {
        Initialization();
    }

    void Update()
    {

    }

    //triggered by GUIManager class, starts the coroutine to decrease the scale of the clutch image
    public void ClutchIsPressed()
    {
        SetClutchPressed(true);
        StartCoroutine(DecreaseScale());
    }

    //triggered by ChangeGearPanelBehaviour class, starts the coroutine to increase the value of the releasing bar and the scale of the clutch image
    public void GearHasBeenChanged() 
    {
        loadingBar.SetActive(true);
        coroutineLoadBarAndChangeScale = StartCoroutine(LoadBarAndChangeScale(FindTimeForChangeTheGear(currentGear), GetComponent<RectTransform>()));
    }

    //triggered by GUIManger class, stops the coroutine started earlier and checks if the clutch was released in a proper time
    public void ClutchIsReleased()
    {
        GetComponent<RectTransform>().localScale = new Vector3(0.1f, 0.3f, 1f);
        if (coroutineLoadBarAndChangeScale != null)
        { 
            StopCoroutine(coroutineLoadBarAndChangeScale); 
        }

        if (currentGear == 0)
        {
            //don't do anything
        }
        else if (currentGear != 0 && loadingBar.GetComponent<Slider>().value > 0.9f)
        {
            particles.SwitchMaterial("green");
            particles.Play();
        }
        else
        {
            ClucthReleasedTooEarly();
            MSVehicleControllerFree.mSVehicleControllerFree.MySetEngineOnOff(true);
            car.Off();
        }

        SetClutchPressed(false);
        MakeDisappearTheLoadingBar();
        EmptyBar();
        car.NotifyGearChanged();
    }


    //increases the value of the bar and increases the scale of the clutch. The rate 
    //of increment is split in 50 to increase the scale, though i can't really remember why
    private IEnumerator LoadBarAndChangeScale(float incrementValue, RectTransform rectTransform)
    {
        yield return new WaitForSeconds(0.2f);

        while (loadingBar.GetComponent<Slider>().value <= 1f && rectTransform.localScale.x < 0.1f && rectTransform.localScale.y < 0.3f)
        {
            yield return new WaitForSeconds(0.01f);
            loadingBar.GetComponent<Slider>().value += incrementValue;
            loadingBar.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = Color.Lerp(Color.red, Color.green, loadingBar.GetComponent<Slider>().value);
            rectTransform.localScale += new Vector3(incrementValue/50, (incrementValue/50) * 3, 0f);

            if (currentGear == Gear.Gear1) carRigidbody.AddForce(transform.forward * 800 * (incrementValue + 1));
            if (currentGear == Gear.GearR) carRigidbody.AddForce(transform.forward * -800 * (incrementValue + 1));
        }

        yield return null;
    }

    //decreases the scale of the clutch. Can't use the CommonPedalsBehaviours
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

    //adds the error the player made and decreases the score
    private void ClucthReleasedTooEarly()
    {
        particles.SwitchMaterial("red");
        particles.Play();
        
        if (!currentLevel.IsMistakeAlreadyAdded("You released the clutch too early!"))
        {
            currentLevel.AddMistake("You released the clutch too early!");
            tempMistakes.Add("You released the clutch too early!");
        }

        int tempScore = player.GetScore();
        player.SetScore(tempScore - 10);
    }

    private void Initialization()
    {
        clutchPressed = false;
        currentGear = Gear.GearN;
        car = Car.GetCarInstance();
        carRigidbody = car.GetComponent<Rigidbody>();
        particles = ParticlesManagement.GetParticlesInstance();
        saveManager = SaveManager.GetSaveManagerInstance();
        saveState = saveManager.GetSaveState();
        menu = Menu.GetMenuInstance();
        currentLevel = saveState.GetListOfLevels()[menu.GetCurrentLevel().GetId() - 1];
        player = PlayerController.GetPlayerControllerInstance();
        tempMistakes = player.GetTempMistakes();
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

    public static ClutchBehaviour GetClutchBehaviourInstance()
    {
        return clutch;
    }
}
