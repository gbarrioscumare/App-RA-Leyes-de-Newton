using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class AutoMovimiento : MonoBehaviour
{
    public Transform puntoInicio;
    public Transform puntoFinal;
    public float velocidad = 5f;
    public float umbralInclinacion = 90f;

    private Rigidbody rb;
    private Quaternion rotacionInicial;
    private bool haciaPuntoFinal = true;

    private bool movimientoIniciado = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rotacionInicial = transform.rotation;
    }

    private void Update()
    {
        MoverAuto();
    }

    private void MoverAuto()
    {
        Vector3 direccionMovimiento = (haciaPuntoFinal ? puntoFinal.position - transform.position : puntoInicio.position - transform.position).normalized;
        Vector3 velocidadMovimiento = direccionMovimiento * velocidad;
        rb.velocity = velocidadMovimiento;

        if (haciaPuntoFinal && Vector3.Distance(transform.position, puntoFinal.position) <= 0.1f)
        {
            // El auto ha llegado al punto final, reiniciar posición y rotación
            transform.position = puntoFinal.position;
            transform.rotation = rotacionInicial;

            // Cambiar dirección hacia el punto inicial
            haciaPuntoFinal = false;
        }
        else if (!haciaPuntoFinal && Vector3.Distance(transform.position, puntoInicio.position) <= 0.1f)
        {
            // El auto ha llegado al punto inicial, reiniciar posición y rotación
            transform.position = puntoInicio.position;
            transform.rotation = rotacionInicial;

            // Cambiar dirección hacia el punto final
            haciaPuntoFinal = true;
        }

        if (EstaInclinado())
        {
            rb.velocity = Vector3.zero;
        }
    }

    private bool EstaInclinado()
    {
        float anguloInclinacion = Vector3.Angle(transform.up, Vector3.up);
        return anguloInclinacion > umbralInclinacion;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PuntoFinal"))
        {
            // El auto tocó el punto final, reiniciar posición y rotación
            transform.position = puntoInicio.position;
            transform.rotation = rotacionInicial;

            // Cambiar dirección hacia el punto final
            haciaPuntoFinal = true;
        }
    }
}