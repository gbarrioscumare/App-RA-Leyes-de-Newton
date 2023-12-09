using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TerceraLeyCubo : MonoBehaviour
{
    public Rigidbody cuboRigidbody;
    public Collider cuboCollider;
    public Transform cuboTransform;
    public TMP_InputField masaInput;
    public TextMeshProUGUI velocidadText;
    public TextMeshProUGUI masaText;
    public TextMeshProUGUI valorFricción;
    public Button aumentarFuerzaButton;
    public Button aumentarFuerza10Button;
    public Button DisminuirFuerzaButton;
    public Button DisminuirFuerza10Button;
    public Button detenerFuerzaButton;
    //public Transform puntoInicial;
    public TextMeshProUGUI FuerzaTM;
    //public Collider meta;
    public Transform paredIzquierda;
    public Transform paredDerecha;
    public Transform FrenteParedIzq;
    public Transform FrenteParedDer;
    public GameObject DialogoDF;
    public float gizmosScale = 0.1f;
    public GameObject fuerzaAplicadaObject;
    public GameObject fuerzaNormalObject;
    public GameObject fuerzaFriccionObject;
    public GameObject pesoObject;
    public Vector3 FuerzaAplicada;
    public Vector3 FuerzaFriccion;
    public float escalaZInicial;
    public Transform paredIZQCubo;
    public Transform paredDERCubo;
    public float desplazamientoXFuerzaAplicada = 1.0f;
    public float desplazamientoXFriccion = 1.0f;
    public Collider Pisoley3;

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
    private float aceleracionDeLaGravedad = 9.81f;
    private float fuerzaNormal;
    private float velocidadMaxima = 200f; // límite de velocidad máxima.


 
    public Scrollbar friccionScrollbar; //  referencia al Scrollbar de fricción.
    public float fuerzaDeFriccion;
    public float fuerzaDeFriccionGismoz;
    public float valorMaximoDeFriccion = 1f; // Define el valor máximo (200 N).
    private float fuerzaResultante;
    private float friccionEstatica;
    private float friccionDinamica;



    private void Start()
    {

        FuerzaAplicada = fuerzaAplicadaObject.transform.position;
        FuerzaFriccion = fuerzaFriccionObject.transform.position;
        cuboCollider.material.staticFriction = 0f; // Configura un valor inicial para la fricción estática.
        cuboCollider.material.dynamicFriction = 0f; // Configura un valor inicial para la fricción dinámica.
        masaCuboInicial = cuboRigidbody.mass;
        posicionInicialCubo = cuboTransform.position;
        aumentarFuerzaButton.onClick.AddListener(AumentarFuerza);
        aumentarFuerza10Button.onClick.AddListener(AumentarFuerza10);
        DisminuirFuerzaButton.onClick.AddListener(DisminuirFuerza);
        DisminuirFuerza10Button.onClick.AddListener(DisminuirFuerza10);
    }

    private void Update()
    {
        velocidadText.text = "Velocidad: " + cuboRigidbody.velocity.magnitude.ToString("F1") + " m/s";
        masaText.text = "Masa: " + cuboRigidbody.mass.ToString("F0") + " KG";
        // calcula la aceleración usando la segunda ley de Newton: Fuerza = Masa * Aceleración.
        float aceleracion = fuerza / cuboRigidbody.mass;
        // Calcula la fuerza necesaria para esta aceleración.
        float fuerzaNecesaria = cuboRigidbody.mass * aceleracion;
        if (aplicandoFuerza)
        {
            // Verificar si el usuario ingresó un valor en el campo de entrada
            if (!string.IsNullOrEmpty(masaInput.text) && float.TryParse(masaInput.text, out float masaCubo))
            {
                // Si el usuario ingresó un valor numérico y es mayor que cero, utilízalo como masa
                if (masaCubo > 0)
                {
                    cuboRigidbody.mass = masaCubo;
                    // Actualiza la fuerza normal cuando la masa cambia.
                    fuerzaNormal = masaCubo * aceleracionDeLaGravedad;
                }
            }
            else
            {
                // Si el campo está vacío o la masa es inválida, use el valor predeterminado de 1 kg
                cuboRigidbody.mass = 1f;
                // Actualiza la fuerza normal cuando se restablece la masa.
                fuerzaNormal = cuboRigidbody.mass * aceleracionDeLaGravedad;
            }          
            // Aplica esta fuerza al objeto con ForceMode.Force.
            if (fuerzaDeFriccion == 0)
            {
                fuerzaResultante = fuerza;
                FuerzaTM.text = "Fuerza: " + fuerzaResultante.ToString("F0") + " N";
                // Sin fricción, aplicamos la fuerza necesaria como se hacía anteriormente.
                if (fuerzaNecesaria > 0)
                {
                    cuboRigidbody.AddForce(Vector3.right * fuerzaNecesaria * ajuste, ForceMode.Force);
                    
                }
                else if (fuerzaNecesaria < 0)
                {
                    cuboRigidbody.AddForce(Vector3.left * Mathf.Abs(fuerzaNecesaria) * ajuste, ForceMode.Force);
                    
                }
            }
            AjustarVisualizacionFuerza();
            if (cuboRigidbody.velocity.magnitude > velocidadMaxima)
            {
                // Limita la velocidad si supera el valor máximo.
                cuboRigidbody.velocity = cuboRigidbody.velocity.normalized * velocidadMaxima;
            }
            // Verifica si el cubo toca una pared.
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
            // Verifica si el cubo toca una pared.
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
            FuerzaTM.text = "Fuerza: " + fuerza.ToString() + " N";
        }
    }

    public void ActualizarFriccion(float value)
    {
        float valorConfigurado = friccionScrollbar.value;

        // Redondea el valor configurado al múltiplo más cercano de 0.1.
        float valorRedondeado = Mathf.Round(valorConfigurado * 10.0f) / 10.0f;


        // Configura la fricción basada en el valor redondeado.
        cuboCollider.material.staticFriction = valorRedondeado * valorMaximoDeFriccion / 7;
        cuboCollider.material.dynamicFriction = valorRedondeado * valorMaximoDeFriccion / 7;

        //Debug.Log(cuboCollider.material.staticFriction);
        //Debug.Log(cuboCollider.material.dynamicFriction);

    }

    //Vectores
    private void AjustarVisualizacionFuerza()
    {
        float magnitudFuerza = fuerza;
        float magnitudFriccion = friccionScrollbar.value;

        pesoObject.transform.localScale = new Vector3(0.1f, cuboRigidbody.mass * escalaZInicial * 5f, 0.1f);
        fuerzaNormalObject.transform.localScale = new Vector3(0.1f, cuboRigidbody.mass * escalaZInicial * 5f, 0.1f);

        // Calcular la posición del objeto que representa la magnitud de la fuerza en base al punto de colisión
        Vector3 posicionObjetoFuerza = cuboTransform.position;
        Vector3 posicionObjetoFuerzaFriccion = cuboTransform.position;

        if (fuerza > 0)
        {
            fuerzaFriccionObject.transform.position = paredIZQCubo.position;
            fuerzaAplicadaObject.transform.position = paredDERCubo.position;
            // Fuerza aplicada positiva: Coloca la fuerza aplicada a la derecha y la fricción a la izquierda.
            fuerzaAplicadaObject.transform.localScale = new Vector3(0.1f, 0.1f, magnitudFuerza * escalaZInicial);
            fuerzaFriccionObject.transform.localScale = new Vector3(0.1f, 0.1f, magnitudFriccion * 3);

            // Calcula la posición del objeto de la fuerza aplicada
            Vector3 offsetFuerzaAplicada = new Vector3(magnitudFuerza * escalaZInicial * 0.5f, 0f, 0f);
            posicionObjetoFuerza += offsetFuerzaAplicada;

            // Calcula la posición del objeto de la fuerza de fricción
            Vector3 offsetFuerzaFriccion = new Vector3(-magnitudFriccion * escalaZInicial * 10f, 0f, 0f);
            posicionObjetoFuerza -= offsetFuerzaFriccion;

            fuerzaAplicadaObject.transform.position = posicionObjetoFuerza;
        }
        else if (fuerza < 0)
        {
            Debug.Log("entreAfuerza<0");
            fuerzaFriccionObject.transform.position = paredDERCubo.position;
            fuerzaAplicadaObject.transform.position = paredIZQCubo.position;

            fuerzaFriccionObject.transform.localScale = new Vector3(0.1f, 0.1f, magnitudFriccion * 3);
            fuerzaAplicadaObject.transform.localScale = new Vector3(0.1f, 0.1f, magnitudFuerza * escalaZInicial);

            // Calcula la posición del objeto de la fuerza de fricción
            Vector3 offsetFuerzaFriccion = new Vector3(magnitudFriccion * escalaZInicial * 20f, 0f, 0f);
            posicionObjetoFuerzaFriccion += offsetFuerzaFriccion;

            // Calcula la posición del objeto de la fuerza aplicada
            Vector3 offsetFuerzaAplicada = new Vector3(-magnitudFuerza * escalaZInicial * 0.5f, 0f, 0f);
            posicionObjetoFuerza -= offsetFuerzaAplicada;

            fuerzaAplicadaObject.transform.position = posicionObjetoFuerza;
            fuerzaFriccionObject.transform.position = posicionObjetoFuerzaFriccion;
        }
        else
        {
            // Fuerza aplicada igual a cero: No se muestra ninguna fuerza.
            fuerzaAplicadaObject.transform.localScale = new Vector3(0f, 0f, 0f);
            fuerzaFriccionObject.transform.localScale = new Vector3(0f, 0f, 0f);
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

    private void ReiniciarEnFrenteParedDerecha()
    {
        cuboTransform.position = FrenteParedDer.position;
    }

    private void ReiniciarEnFrenteParedIzquierda()
    {
        cuboTransform.position = FrenteParedIzq.position;
    }

    public void ReiniciarSimulacion()
    {
        aplicandoFuerza = false;
        fuerza = 0f;
        cuboRigidbody.velocity = Vector3.zero;
        cuboRigidbody.mass = masaCuboInicial;
        cuboRigidbody.transform.position = posicionInicialCubo;
        DialogoDF.SetActive(false);
        pesoObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        fuerzaNormalObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        fuerzaAplicadaObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        fuerzaFriccionObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        fuerzaFriccionObject.transform.position = paredIZQCubo.position;
        fuerzaAplicadaObject.transform.position = paredDERCubo.position;



    }
}
