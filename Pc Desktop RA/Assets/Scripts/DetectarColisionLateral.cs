using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarColisionLateral : MonoBehaviour
{
    private AutoControlado autoControlado;

    public LayerMask sueloLayer; // Capa que representa el suelo

    private void Start()
    {
        autoControlado = GetComponentInParent<AutoControlado>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Verificar si la colisión es con el objeto que representa las paredes laterales del collider
        if (collision.gameObject.CompareTag("ParedLateral"))
        {
            // Comprobar si el suelo también está presente en la colisión
            if (IsSueloInCollision(collision))
            {
                autoControlado.DetenerMovimiento();
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Verificar si la colisión es con el objeto que representa las paredes laterales del collider
        if (collision.gameObject.CompareTag("ParedLateral"))
        {
            autoControlado.ReanudarMovimiento();
        }
    }

    private bool IsSueloInCollision(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            if (IsSuelo(contact.otherCollider.gameObject))
            {
                return true;
            }
        }
        return false;
    }

    private bool IsSuelo(GameObject gameObject)
    {
        return gameObject.CompareTag("Suelo") && (1 << gameObject.layer & sueloLayer) != 0;
    }
}
