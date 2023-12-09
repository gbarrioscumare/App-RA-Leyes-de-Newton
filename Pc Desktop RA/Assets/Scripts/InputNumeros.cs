
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputNumeros : MonoBehaviour
{
    public TMP_InputField fuerzaInput;
    public TMP_InputField masaInput;
    public TMP_InputField velocidadInput;

    private void Start()
    {
        fuerzaInput.onValueChanged.AddListener(VerificarNumero);
        masaInput.onValueChanged.AddListener(VerificarNumero);
        velocidadInput.onValueChanged.AddListener(VerificarNumero);
    }

    private void VerificarNumero(string nuevoValor)
    {
        // Intenta convertir el nuevo valor a float
        if (!float.TryParse(nuevoValor, out float resultado))
        {
            // Si no es un número válido, establece el campo de texto a vacío
            fuerzaInput.text = "";
            masaInput.text = "";
            velocidadInput.text = "";
        }
    }
}
