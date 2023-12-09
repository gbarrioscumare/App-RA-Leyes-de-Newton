using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReiniciarIntro : MonoBehaviour
{
    public GameObject[] objetosAReiniciar; // Arreglo de objetos que se reiniciarán
    private Vector3[] posicionesIniciales; // Almacena las posiciones iniciales de los objetos

    void Start()
    {
        // Inicializa el arreglo de posiciones iniciales con las posiciones actuales de los objetos
        posicionesIniciales = new Vector3[objetosAReiniciar.Length];
        for (int i = 0; i < objetosAReiniciar.Length; i++)
        {
            posicionesIniciales[i] = objetosAReiniciar[i].transform.position;
        }
    }

    // Método para reiniciar las posiciones de los objetos
    public void ReiniciarPosiciones()
    {
        for (int i = 0; i < objetosAReiniciar.Length; i++)
        {
            objetosAReiniciar[i].transform.position = posicionesIniciales[i];
        }
    }
}
