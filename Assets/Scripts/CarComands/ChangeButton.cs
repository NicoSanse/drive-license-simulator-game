using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeButton : MonoBehaviour, IDragHandler
{
    private Vector2 previousPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 currentPosition = eventData.position;
        Vector2 direction = currentPosition - previousPosition;

        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                Debug.Log("Movimento verso destra");
            }
            else if (direction.x < 0)
            {
                Debug.Log("Movimento verso sinistra");
            }
        }
        else
        {
            if (direction.y > 0)
            {
                Debug.Log("Movimento verso l'alto");
            }
            else if (direction.y < 0)
            {
                Debug.Log("Movimento verso il basso");
            }
        }

        previousPosition = currentPosition;
    }
}
