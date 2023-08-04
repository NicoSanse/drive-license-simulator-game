using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//this class manages the particles release, which are meant as comunicative instrument
//to tell the user that he is doing something wrong or right

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

    public static ParticlesManagement GetParticlesInstance()
    {
        return particlesInstance;
    }
}
