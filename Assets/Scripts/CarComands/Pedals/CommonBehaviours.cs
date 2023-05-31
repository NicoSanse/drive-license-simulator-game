using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonBehaviours
{
    public static IEnumerator ChangeScale(bool pedalPressed, RectTransform rectTransform)
    {
        if (pedalPressed) 
        {
            if (rectTransform.localScale.x > 0.08f && rectTransform.localScale.y > 0.24f)
            {
                rectTransform.localScale += new Vector3(-0.001f, -0.001f * 3, 0f);
                yield return new WaitForSeconds(0.001f);
            }
        }
        else if (rectTransform.localScale.x < 0.1f && rectTransform.localScale.y < 0.3f)
        {
            rectTransform.localScale += new Vector3(0.001f, 0.001f * 3, 0f);
            yield return new WaitForSeconds(0.001f);
        }
        yield return null;
    }
}
