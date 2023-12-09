using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarTouchN : MonoBehaviour
{
    private float rotationSpeed = 5f;
    private Touch touch;
    private Vector2 touchStartPosition;

    private void Update()
    {
        // Verificar si hay al menos un toque en la pantalla
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            // Verificar si el toque comenzó en esta pantalla
            if (touch.phase == TouchPhase.Began)
            {
                touchStartPosition = touch.position;
            }
            // Verificar si el toque se está moviendo
            else if (touch.phase == TouchPhase.Moved)
            {
                // Calcular la dirección del movimiento
                Vector2 touchCurrentPosition = touch.position;
                float rotationAmountX = (touchCurrentPosition.x - touchStartPosition.x) * rotationSpeed * Time.deltaTime;
                float rotationAmountY = (touchCurrentPosition.y - touchStartPosition.y) * rotationSpeed * Time.deltaTime;

                // Rotar el objeto en los ejes X e Y
                transform.Rotate(Vector3.up, -rotationAmountX, Space.World);
                transform.Rotate(Vector3.right, rotationAmountY, Space.World);

                // Actualizar la posición inicial para el próximo movimiento
                touchStartPosition = touchCurrentPosition;
            }
        }
    }
}
