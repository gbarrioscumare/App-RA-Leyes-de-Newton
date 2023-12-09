using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ROTATE : MonoBehaviour
{
    private float rotationSpeed = 5f;
    private bool isRotating = false;
    private Vector3 previousTouchPosition;

    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                isRotating = true;
                previousTouchPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved && isRotating)
            {
                Vector3 currentTouchPosition = touch.position;
                Vector3 deltaTouchPosition = currentTouchPosition - previousTouchPosition;

                // Rotar el objeto en función del movimiento del dedo en la pantalla
                transform.Rotate(Vector3.up, -deltaTouchPosition.x * rotationSpeed, Space.World);

                previousTouchPosition = currentTouchPosition;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                isRotating = false;
            }
        }
    }
}




