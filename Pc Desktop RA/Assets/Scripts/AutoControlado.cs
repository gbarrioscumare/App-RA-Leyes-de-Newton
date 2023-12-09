using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AutoControlado : MonoBehaviour
{
    private Rigidbody rb;
    private float velocidadIngresada;
    private bool movimientoIniciado = false;
    public Transform autoTransform;
    public Transform puntoInicial;
    public TMP_InputField inputField;
    private Vector3 initialPosition; // Almacena la posición inicial

    public float fuerzaChoque = 5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Almacena la posición inicial al inicio del juego
        initialPosition = transform.position;
    }

    public void AplicarVelocidad(float velocidad)
    {
        rb.velocity = transform.forward * velocidad;
    }

    public void ComenzarMovimiento()
    {
        // Obtener la velocidad ingresada por el usuario desde el InputField
        velocidadIngresada = float.Parse(inputField.text);

        // Iniciar el movimiento del auto controlado por el usuario con la velocidad ingresada
        movimientoIniciado = true;
    }

    public void DetenerMovimiento()
    {
        // Detener el movimiento del auto controlado por el usuario
        rb.velocity = Vector3.zero;
        movimientoIniciado = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (movimientoIniciado && collision.gameObject.CompareTag("AutoMovimiento"))
        {
            // Calcular la dirección del objeto en movimiento constante
            Vector3 direccionAutoMovimiento = collision.gameObject.transform.forward;

            // Calcular la dirección del objeto controlado por el usuario
            Vector3 direccionAutoControlado = transform.forward;

            // Calcular la dirección resultante del choque
            Vector3 direccionChoque = direccionAutoMovimiento.normalized + direccionAutoControlado.normalized;

            // Normalizar la dirección del choque y aplicar una fuerza
            rb.AddForce(direccionChoque.normalized * fuerzaChoque, ForceMode.Impulse);

            // Detener el movimiento del objeto controlado
            rb.velocity = Vector3.zero;

            // Detener el movimiento del objeto en movimiento constante
            collision.rigidbody.velocity = Vector3.zero;
        }
    }

    public void ReanudarMovimiento()
    {
        // Reanudar el movimiento del auto controlado por el usuario
        movimientoIniciado = true;
    }

    public void ReiniciarPosicion()
    {
        autoTransform.position = puntoInicial.position;
        // Restablecer la entrada de texto de velocidad a 0
        inputField.text = "0";
    }

    private void FixedUpdate()
    {
        if (movimientoIniciado)
        {
            // Mover el auto controlado por el usuario con la velocidad ingresada
            rb.velocity = transform.forward * velocidadIngresada;
        }
    }
}
