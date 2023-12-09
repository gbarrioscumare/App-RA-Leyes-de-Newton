using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimeraLey : MonoBehaviour
{
    public Transform flecha;
    private Rigidbody rb;
    private ForceArrow forceArrow;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        forceArrow = GetComponent<ForceArrow>();
    }

    public void AplicarFuerza(float fuerza, float angulo)
    {
        // Convertir el �ngulo a una direcci�n en el plano XY
        Vector3 direccion = Quaternion.Euler(0f, angulo, 0f) * Vector3.right;

        // Rotar la flecha hacia la direcci�n deseada
        forceArrow.ActualizarDireccion(direccion);

        // Aplicar la fuerza en la direcci�n actualizada
        rb.AddForce(direccion * fuerza);
    }
}