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
    private int timesCalled;
    private PlayerController player;
    private ParticlesManagement particles;

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

        ChangeLights();
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        CheckPlayerPassing();
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
                Debug.DrawRay(transform.position + new Vector3(0, 1f, 0), transform.right * 9f, Color.green);

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

}
