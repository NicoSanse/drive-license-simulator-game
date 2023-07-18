using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelBehaviour : MonoBehaviour
{

    //capire quali sono i valori migliori per questi due parametri

    public float maxUpperPosition = 550f;
    public float minLowerPosition = -60f;
    void Start()
    {
        
    }

    void Update()
    {
        ControlLevelsListMovement();
    }

    public void ControlLevelsListMovement()
    {

        if (transform.position.y < minLowerPosition)
        {
            transform.position = new Vector3(transform.position.x, minLowerPosition, transform.position.z);
        }

        if (transform.position.y > maxUpperPosition)
        {
            transform.position = new Vector3(transform.position.x, maxUpperPosition, transform.position.z);
        }
    }
    
}
