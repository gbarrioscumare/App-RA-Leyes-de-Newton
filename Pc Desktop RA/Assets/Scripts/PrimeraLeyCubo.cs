using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PrimeraLeyCubo : MonoBehaviour
{
    public Rigidbody cuboRigidbody;
    public Transform cuboTransform;
    public TMP_InputField masaInput;
    public TextMeshProUGUI velocidadText;
    public TextMeshProUGUI masaText;
    public Button aumentarFuerzaButton;
    public Button aumentarFuerza10Button;
    public Button DisminuirFuerzaButton;
    public Button DisminuirFuerza10Button;
    public Button detenerFuerzaButton;
    public Transform puntoInicial;
    public TextMeshProUGUI FuerzaTM;
    public Collider meta;
    public Transform paredIzquierda;
    public Transform paredDerecha;
    public Transform FrenteParedIzq;
    public Transform FrenteParedDer;
    public GameObject DialogoDF;

    private float fuerza = 0f;
    private float masa = 1f;  // Peso inicial del cubo
    private bool aplicandoFuerza = false;

    private Vector3 posicionInicialCubo;
    private bool tocoParedIzquierda = false;
    private bool tocoParedDerecha = false;
    private bool reinicioParedIzquierda = false;
    private bool reinicioParedDerecha = false;
    private float masaCuboInicial;
    private Vector3 velocidadPreReinicio;
    private bool debeReiniciarPosicion = false;
    private float masaCubo;
    private float ajuste = 7f;
    public float velocidadMaxima = 200f;

    private void Start()
    {
        masaCuboInicial = cuboRigidbody.mass;
        posicionInicialCubo = cuboTransform.position;
        aumentarFuerzaButton.onClick.AddListener(AumentarFuerza);
        aumentarFuerza10Button.onClick.AddListener(AumentarFuerza10);
        DisminuirFuerzaButton.onClick.AddListener(DisminuirFuerza);
        DisminuirFuerza10Button.onClick.AddListener(DisminuirFuerza10);
        detenerFuerzaButton.onClick.AddListener(DetenerFuerza);
    }

    private void Update()
    {
        velocidadText.text = "Velocidad: " + cuboRigidbody.velocity.magnitude.ToString("F2") + " m/s";
        masaText.text = "Masa: " + cuboRigidbody.mass.ToString("F0") + " KG";

        if (aplicandoFuerza)
        {
            // Verificar si el usuario ingresó un valor en el campo de entrada
            if (!string.IsNullOrEmpty(masaInput.text) && float.TryParse(masaInput.text, out float masaCubo))
            {
                // Si el usuario ingresó un valor numérico y es mayor que cero, utilízalo como masa
                if (masaCubo > 0)
                {
                    cuboRigidbody.mass = masaCubo;
                }
            }
            else
            {
                // Si el campo está vacío o la masa es inválida, use el valor predeterminado de 1 kg
                cuboRigidbody.mass = 1f;
            }

            // Calcular la aceleración
            float aceleracion = fuerza / cuboRigidbody.mass;

            // Calcular la fuerza requerida para la aceleración
            float fuerzaNecesaria = cuboRigidbody.mass * aceleracion;

            // Aplicar esta fuerza al objeto con ForceMode.Force
            if (fuerzaNecesaria > 0)
            {
                cuboRigidbody.AddForce(Vector3.right * fuerzaNecesaria * ajuste, ForceMode.Force);
            }
            else if (fuerzaNecesaria < 0)
            {
                cuboRigidbody.AddForce(Vector3.left * Mathf.Abs(fuerzaNecesaria) * ajuste, ForceMode.Force);
            }

            FuerzaTM.text = "Fuerza: " + fuerza.ToString() + " N";

            if (cuboRigidbody.velocity.magnitude > velocidadMaxima)
            {
                cuboRigidbody.velocity = cuboRigidbody.velocity.normalized * velocidadMaxima;
            }

            // Verificar si el cubo toca una pared
            if (cuboTransform.position.x < FrenteParedIzq.position.x)
            {
                if (!reinicioParedIzquierda)
                {
                    ReiniciarEnFrenteParedDerecha();
                    tocoParedIzquierda = false;
                    reinicioParedIzquierda = true;
                    debeReiniciarPosicion = true;
                }
            }
            else if (cuboTransform.position.x > FrenteParedDer.position.x)
            {
                if (!reinicioParedDerecha)
                {
                    ReiniciarEnFrenteParedIzquierda();
                    tocoParedDerecha = false;
                    reinicioParedDerecha = true;
                    debeReiniciarPosicion = true;
                }
            }
            else
            {
                reinicioParedIzquierda = false;
                reinicioParedDerecha = false;
            }
        }
        else
        {
            // Verificar si el cubo toca una pared
            if (cuboTransform.position.x < FrenteParedIzq.position.x)
            {
                if (!reinicioParedIzquierda)
                {
                    ReiniciarEnFrenteParedDerecha();
                    tocoParedIzquierda = false;
                    reinicioParedIzquierda = true;
                    debeReiniciarPosicion = true;
                }
            }
            else if (cuboTransform.position.x > FrenteParedDer.position.x)
            {
                if (!reinicioParedDerecha)
                {
                    ReiniciarEnFrenteParedIzquierda();
                    tocoParedDerecha = false;
                    reinicioParedDerecha = true;
                    debeReiniciarPosicion = true;
                }
            }
            else
            {
                reinicioParedIzquierda = false;
                reinicioParedDerecha = false;
            }
            FuerzaTM.text = fuerza.ToString() + " N";
        }
    }

    public void AumentarFuerza()
    {
        fuerza += 1f;
        aplicandoFuerza = true;
        DialogoDF.SetActive(false);
    }

    public void AumentarFuerza10()
    {
        fuerza += 25f;
        aplicandoFuerza = true;
        DialogoDF.SetActive(false);
    }

    public void DisminuirFuerza()
    {
        fuerza -= 1f;
        aplicandoFuerza = true;
        DialogoDF.SetActive(false);
    }

    public void DisminuirFuerza10()
    {
        fuerza -= 25f;
        aplicandoFuerza = true;
        DialogoDF.SetActive(false);
    }

    public void DetenerFuerza()
    {
        aplicandoFuerza = false;
        fuerza = 0f;
        // Define un valor umbral para considerar que la velocidad es "casi" cero.
        float velocidadUmbral = 0.01f; 

        // Verifica si la velocidad en el eje x es menor que el valor umbral.
        if (Mathf.Abs(cuboRigidbody.velocity.x) > velocidadUmbral)
        {
            // Activa el objeto si la velocidad es "casi" cero.
            DialogoDF.SetActive(true);
        }
    }

    private void ReiniciarEnFrenteParedDerecha()
    {
        cuboTransform.position = FrenteParedDer.position;
        //cuboRigidbody.velocity = velocidadPreReinicio;
    }

    private void ReiniciarEnFrenteParedIzquierda()
    {
        cuboTransform.position = FrenteParedIzq.position;
        //cuboRigidbody.velocity = velocidadPreReinicio;
    }

    public void ActualizarMasa()
    {
        if (float.TryParse(masaInput.text, out float nuevaMasa))
        {
            masa = nuevaMasa;
        }
    }

    public void ReiniciarSimulacion()
    {
        aplicandoFuerza = false;
        fuerza = 0f;
        cuboRigidbody.velocity = Vector3.zero;
        masaInput.text = masaCuboInicial.ToString();
        velocidadText.text = "0 m/s";
        FuerzaTM.text = "0 N";
        cuboRigidbody.transform.position = posicionInicialCubo;
        DialogoDF.SetActive(false);
    }
}
