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
        // Convertir el ángulo a una dirección en el plano XY
        Vector3 direccion = Quaternion.Euler(0f, angulo, 0f) * Vector3.right;

        // Rotar la flecha hacia la dirección deseada
        forceArrow.ActualizarDireccion(direccion);

        // Aplicar la fuerza en la dirección actualizada
        rb.AddForce(direccion * fuerza);
    }
}