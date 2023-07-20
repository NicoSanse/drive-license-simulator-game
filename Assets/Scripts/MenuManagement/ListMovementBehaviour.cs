using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class helps control the movement of the list of levels
public class ListMovementBehaviour : MonoBehaviour
{
    //these two values are not the same as the ones in the inspector
    //but still can control the position of the content of the list
    public float maxUpperPosition = 550f;
    public float minLowerPosition = -80f;
    
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
