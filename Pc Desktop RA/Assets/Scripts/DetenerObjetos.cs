using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetenerObjetos : MonoBehaviour
{
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Detener la velocidad cuando hay una colisión
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}
