using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControladorPelotas : MonoBehaviour
{
    public Rigidbody pelota1;
    public Rigidbody pelota2;
    public TMP_InputField fuerzaInput1;
    public TMP_InputField fuerzaInput2;
    public TMP_InputField anguloInput1;
    public TMP_InputField anguloInput2;
    public TMP_InputField velocidadMaximaInput; // Campo de entrada de texto para la velocidad máxima
    public float velocidadDecayRate = 0.1f; // Tasa de disminución de velocidad por segundo

    // Valor máximo de fuerza permitido
    private float maxFuerza = 320f;
    private bool aplicarFuerza = false;

    public void IniciarAplicacionFuerza()
    {
        aplicarFuerza = true;
        float speed = pelota1.velocity.magnitude;
        Debug.Log(speed);
    }

    void Update()
    {
        if (aplicarFuerza)
        {
            // Obtener los valores de fuerza, ángulo y velocidad máxima ingresados por el usuario desde los campos de entrada de texto
            float fuerza1 = ObtenerFuerzaValidada(fuerzaInput1.text);
            float fuerza2 = ObtenerFuerzaValidada(fuerzaInput2.text);
            float angulo1 = float.TryParse(anguloInput1.text, out float angulo1Ingresado) ? angulo1Ingresado : 0f;
            float angulo2 = float.TryParse(anguloInput2.text, out float angulo2Ingresado) ? angulo2Ingresado : 0f;
            float velocidadMaxima = float.TryParse(velocidadMaximaInput.text, out float velocidadMaximaIngresada) ? velocidadMaximaIngresada : 50f;

            Vector3 direccion1 = Quaternion.Euler(0, angulo1, 0) * Vector3.right;
            Vector3 direccion2 = Quaternion.Euler(0, angulo2, 0) * Vector3.left;

            LimitarVelocidad(pelota1, velocidadMaxima); // Limita la velocidad antes de aplicar la fuerza
            LimitarVelocidad(pelota2, velocidadMaxima); // Limita la velocidad antes de aplicar la fuerza

            pelota1.AddForce(direccion1.normalized * fuerza1, ForceMode.Impulse);
            pelota2.AddForce(direccion2.normalized * fuerza2, ForceMode.Impulse);

            pelota1.transform.rotation = Quaternion.Euler(0, angulo1, 0);
            pelota2.transform.rotation = Quaternion.Euler(0, angulo2, 0);

            aplicarFuerza = false;
        }
    }

    private float ObtenerFuerzaValidada(string inputText)
    {
        float fuerzaIngresada;
        if (float.TryParse(inputText, out fuerzaIngresada))
        {
            if (fuerzaIngresada > maxFuerza)
            {
                return maxFuerza;
            }
            else
            {
                return fuerzaIngresada;
            }
        }
        else
        {
            return 0f;
        }
    }
    private void LimitarVelocidad(Rigidbody pelota, float velocidadMaxima)
    {
        // Obtener la velocidad actual del objeto
        Vector3 velocidadActual = pelota.velocity;

        // Calcular la magnitud de la velocidad actual
        float magnitudVelocidadActual = velocidadActual.magnitude;

        // Si la magnitud de la velocidad actual supera la velocidad máxima
        if (magnitudVelocidadActual > velocidadMaxima)
        {
            // Normalizar la velocidad para obtener la dirección
            Vector3 direccionVelocidad = velocidadActual.normalized;

            // Establecer la nueva velocidad respetando la dirección original y la velocidad máxima
            pelota.velocity = direccionVelocidad * velocidadMaxima;
        }
    }
    private bool chocoConPared = false; // Variable para controlar si ha chocado con una pared

    private void OnCollisionEnter(Collision collision)
    {
        // Verificar si la colisión ocurrió con una pared
        if (collision.gameObject.CompareTag("Pared") && !chocoConPared)
        {
            // Obtener la dirección del rebote usando Vector3.Reflect
            Vector3 direccionRebote = Vector3.Reflect(transform.forward, collision.contacts[0].normal);

            // Establecer la nueva dirección de movimiento
            transform.forward = direccionRebote;

            // Establecer que ha chocado con una pared
            chocoConPared = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Cuando sale de la colisión con la pared, permitir nuevos rebotes
        if (collision.gameObject.CompareTag("Pared"))
        {
            chocoConPared = false;
        }
    }

}


