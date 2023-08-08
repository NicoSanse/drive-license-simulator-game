using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLights : MonoBehaviour
{
    private SpriteRenderer[] lights;
    private GameObject redLight;
    private GameObject yellowLight;
    private GameObject greenLight;
    private GameObject littleRedLight;
    private GameObject littleGreenLight;
    private bool isPlayerPassing;
    private bool otherCarsClose;
    private int timesCalled;
    private PlayerController player;
    private ParticlesManagement particles;
    private RaycastHit hit;
    private GameObject otherCar;

    void Start()
    {
        player = PlayerController.GetPlayerControllerInstance();
        particles = ParticlesManagement.GetParticlesInstance();
        lights = GetComponentsInChildren<SpriteRenderer>(true);
        redLight = lights[1].gameObject;
        yellowLight = lights[3].gameObject;
        greenLight = lights[4].gameObject;
        littleRedLight = lights[2].gameObject;
        littleGreenLight = lights[0].gameObject;
        timesCalled = 0;

        isPlayerPassing = false;
        otherCarsClose = false;

        ChangeLights();
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        CheckPlayerPassing();
        StopOtherCars();
    }

    private void ChangeLights()
    {
        if(redLight.activeSelf) StartCoroutine(ChangeLightsCoroutine1());
        else StartCoroutine(ChangeLightsCoroutine2());
    }

    private IEnumerator ChangeLightsCoroutine1()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            redLight.SetActive(false);
            greenLight.SetActive(true);
            littleGreenLight.SetActive(false);
            littleRedLight.SetActive(true);
            yield return new WaitForSeconds(5);
            greenLight.SetActive(false);
            yellowLight.SetActive(true);
            yield return new WaitForSeconds(3);
            yellowLight.SetActive(false);
            redLight.SetActive(true);
            littleRedLight.SetActive(false);
            littleGreenLight.SetActive(true);
        }
    }

    private IEnumerator ChangeLightsCoroutine2()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            greenLight.SetActive(false);
            yellowLight.SetActive(true);
            yield return new WaitForSeconds(3);
            yellowLight.SetActive(false);
            redLight.SetActive(true);
            littleRedLight.SetActive(false);
            littleGreenLight.SetActive(true);
            yield return new WaitForSeconds(5);
            redLight.SetActive(false);
            greenLight.SetActive(true);
            littleGreenLight.SetActive(false);
            littleRedLight.SetActive(true);
        }
    }

    private void CheckPlayerPassing()
    {
        if (timesCalled == 0)
        {
            if (redLight.activeSelf || yellowLight.activeSelf)
            {
                isPlayerPassing = Physics.Raycast(transform.position + new Vector3(0, 1f, 0), transform.right, 9f, LayerMask.GetMask("Player"));

                if (isPlayerPassing)
                {
                    if (redLight.activeSelf)
                    {
                        player.RedLightMistake();
                    }
                    else if (yellowLight.activeSelf)
                    {
                        player.YellowLightMistake();
                    }
                    else
                    {
                        particles.SwitchMaterial("green");
                        particles.Play();
                    }
                    timesCalled++;
                }
            }
        }
    }

    private void StopOtherCars()
    {
        otherCarsClose = Physics.Raycast(transform.position + new Vector3(2f, 1f, 0), transform.right, out hit, 9f, LayerMask.GetMask("OtherCars"));
        Debug.DrawRay(transform.position + new Vector3(2f, 1f, 0), transform.right * 9f, Color.yellow);

        if (otherCarsClose)
        { 
            otherCar = hit.transform.gameObject;
            if(redLight.activeSelf || yellowLight.activeSelf)
            {
                otherCar.SendMessage("Stop");
            }
            else
            {
                otherCar.SendMessage("Go");
            }
        }
    }

}
