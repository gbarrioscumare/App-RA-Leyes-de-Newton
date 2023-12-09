using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TransformData
{
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 scale;
}

public class ReiniciarValoresObjetos : MonoBehaviour
{
    public GameObject[] objetos;
    private TransformData[] transformacionesIniciales;

    private Rigidbody[] objetosRigidbody; // Array para almacenar los Rigidbody de los objetos

    private void Start()
    {
        GuardarValoresIniciales();
    }

    public void ReiniciarValores()
    {
        for (int i = 0; i < objetos.Length; i++)
        {
            // Restaurar las transformaciones iniciales del objeto
            objetos[i].transform.position = transformacionesIniciales[i].position;
            objetos[i].transform.rotation = transformacionesIniciales[i].rotation;
            objetos[i].transform.localScale = transformacionesIniciales[i].scale;

            // Restaurar las propiedades físicas del objeto
            objetosRigidbody[i].velocity = Vector3.zero;
            objetosRigidbody[i].angularVelocity = Vector3.zero;

            // Activar los colliders de los objetos
            Collider[] colliders = objetos[i].GetComponentsInChildren<Collider>();
            foreach (Collider collider in colliders)
            {
                collider.enabled = true;
            }
        }

        // Detener el movimiento del objeto controlado por el usuario
        AutoControlado autoControlado = FindObjectOfType<AutoControlado>();
        if (autoControlado != null)
        {
            autoControlado.DetenerMovimiento();
        }
    }

    private void GuardarValoresIniciales()
    {
        transformacionesIniciales = new TransformData[objetos.Length];
        objetosRigidbody = new Rigidbody[objetos.Length];

        for (int i = 0; i < objetos.Length; i++)
        {
            transformacionesIniciales[i] = new TransformData
            {
                position = objetos[i].transform.position,
                rotation = objetos[i].transform.rotation,
                scale = objetos[i].transform.localScale
            };

            objetosRigidbody[i] = objetos[i].GetComponent<Rigidbody>();
        }
    }
}