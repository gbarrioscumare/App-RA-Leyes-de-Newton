using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchZoom : MonoBehaviour
{
    private float distance;
    private float newdistance;
    private float scalefactor;
    private Vector3 ogscale;

    void Update()
    {
        if (Input.touchCount == 2)
        {
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            if (touch0.phase == TouchPhase.Ended || touch0.phase == TouchPhase.Canceled ||
                touch1.phase == TouchPhase.Ended || touch1.phase == TouchPhase.Canceled)
            {
                return;
            }
            if (touch0.phase == TouchPhase.Began || touch1.phase == TouchPhase.Began)
            {
                distance = Vector2.Distance(touch0.position, touch1.position);
                ogscale = gameObject.transform.localScale;
            }
            if (touch0.phase == TouchPhase.Moved && touch1.phase == TouchPhase.Moved)
            {
                newdistance = Vector2.Distance(touch0.position, touch1.position);
                scalefactor = newdistance / distance;
                Vector3 temp = ogscale * scalefactor;

                if (temp.x > 0.01 && temp.x < 15)
                {
                    gameObject.transform.localScale = ogscale * scalefactor;
                    //Debug.Log("Dentro de los parametros esperados");
                }

                //Debug.Log("La escala del objecto actualmente es: " + gameObject.transform.localScale);
            }
        }
    }
}