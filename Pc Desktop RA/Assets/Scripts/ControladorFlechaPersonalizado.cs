using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControladorFlechaPersonalizado : MonoBehaviour
{
    public Rigidbody flechaRigidbody;
    public Rigidbody autoRigidbody;
    public Transform flechaTransform;
    public Transform autoTransform;
    public Collider puntoFinalCollider;  // Usamos el colisionador del punto final
    public Transform puntoInicial;
    public TMP_InputField fuerzaInput;
    public TMP_InputField masaAutoInput;
    public TextMeshProUGUI AceleracionTM;
    public TextMeshProUGUI VelocidadTM;
    public Button empezarButton;
    public Button reiniciarButton;
    private float fuerzaInicial;
    private float masaAutoInicial;
    public float velocidadMaxima = 500f; // Nuevo l�mite de velocidad


    private bool simulacionIniciada = false;
    private Vector3 posicionInicialAuto;
    private Vector3 posicionInicialFlecha;
    private Vector3 posicionInicialRelativa; // Guardar la posici�n relativa al colisionar

    private void Start()
    {
        posicionInicialFlecha = flechaRigidbody.transform.position;
        posicionInicialAuto = autoRigidbody.transform.position;
        empezarButton.onClick.AddListener(IniciarSimulacion);
        reiniciarButton.onClick.AddListener(ReiniciarSimulacion);
        posicionInicialRelativa = flechaTransform.position - autoTransform.position; // Calcula la posici�n relativa inicial
    }

    private void Update()
    {
        float velocidad = 0;
        if (simulacionIniciada)
        {
            float fuerza;
            float masaAuto;

            if (float.TryParse(fuerzaInput.text, out fuerza) && float.TryParse(masaAutoInput.text, out masaAuto))
            {
                //Calcular la aceleraci�n resultante del autom�vil seg�n la segunda ley de Newton
                autoRigidbody.mass = masaAuto;
                Vector3 direccion = - flechaTransform.right; // Direcci�n hacia adelante de la flecha
                Vector3 fuerzaEmpuje = direccion * fuerza * 50;

                // Aplicar la fuerza de empuje al auto
                flechaRigidbody.AddForce(fuerzaEmpuje);
                if (autoRigidbody.velocity.magnitude > velocidadMaxima)
                {
                    autoRigidbody.velocity = autoRigidbody.velocity.normalized * velocidadMaxima;
                }
                // Mostrar la velocidad en el TextMeshProUGUI
                float speed = autoRigidbody.velocity.magnitude;
                float aceleracion = fuerza / masaAuto;
                VelocidadTM.text = speed.ToString();
                AceleracionTM.text = aceleracion.ToString();

                // Si colisiona con el punto final, guardar posici�n relativa y reiniciar
                if (puntoFinalCollider.bounds.Intersects(autoTransform.GetComponent<Collider>().bounds))
                {
                    ReiniciarPosicion();
                }
            }
        }
    }

    public void IniciarSimulacion()
    {
        simulacionIniciada = true;
        Debug.Log("Iniciando Simulaci�n");
    }

    private void ReiniciarPosicion()
    {
        autoTransform.position = puntoInicial.position;
        flechaTransform.position = puntoInicial.position + posicionInicialRelativa; // Restaura la posici�n relativa
        Debug.Log("Reiniciando Posici�n");
    }
    public void ReiniciarSimulacion()
    {
        // Reinicia todos los valores a sus estados iniciales
        simulacionIniciada = false;
        autoRigidbody.velocity = Vector3.zero;
        flechaRigidbody.velocity = Vector3.zero;
        fuerzaInput.text = fuerzaInicial.ToString();
        masaAutoInput.text = masaAutoInicial.ToString();
        AceleracionTM.text = "0"; // Ajusta esto a tu valor inicial deseado
        VelocidadTM.text = "0"; // Ajusta esto a tu valor inicial deseado

        // Reinicia las posiciones de los objetos
        autoRigidbody.transform.position = posicionInicialAuto;
        flechaRigidbody.transform.position = posicionInicialFlecha;

        // Tambi�n podr�as reiniciar otros valores aqu� si es necesario...

        Debug.Log("Reiniciando Simulaci�n");
    }
}
