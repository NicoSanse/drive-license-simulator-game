using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParticlesManagement : MonoBehaviour
{
    private static ParticlesManagement particlesInstance;
    [SerializeField] private Material[] materials;

    void Awake()
    { 
        particlesInstance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SwitchMaterial(string material)
    {
        switch (material)
        {
            case "green": 
                GetComponent<ParticleSystemRenderer>().material = materials[0];
                break;
            case "yellow":
                GetComponent<ParticleSystemRenderer>().material = materials[1];
                break;
            case "red":
                GetComponent<ParticleSystemRenderer>().material = materials[2];
                break;
            default:
                print("Error: wrong material");
                break;
        }
    }

    public void Play()
    { 
        GetComponent<ParticleSystem>().Play();
    }

    public static ParticlesManagement getParticlesInstance()
    {
        return particlesInstance;
    }
}
