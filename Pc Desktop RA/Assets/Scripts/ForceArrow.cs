using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceArrow : MonoBehaviour
{
    public void ActualizarDireccion(Vector3 direccion)
    {
        // Orientar la flecha hacia la direcci�n especificada
        transform.LookAt(transform.position + direccion);
    }
}