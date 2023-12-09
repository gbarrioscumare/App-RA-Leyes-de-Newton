using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

using UnityMeshSimplifier;

public class Poligonos : MonoBehaviour
{
    public GameObject objectToSimplify;
    public float targetPercentage = 0.5f; // Porcentaje objetivo de reducción de polígonos

    private void Start()
    {
        // Obtener el componente MeshFilter del objeto a simplificar
        MeshFilter meshFilter = objectToSimplify.GetComponent<MeshFilter>();

        // Comprobar si el componente MeshFilter existe
        if (meshFilter != null)
        {
            // Obtener la malla del objeto
            Mesh originalMesh = meshFilter.sharedMesh;

            // Crear una copia de la malla original
            Mesh simplifiedMesh = Instantiate(originalMesh);

            // Crear un objeto simplificador
            var simplifier = new UnityMeshSimplifier.MeshSimplifier();

            // Establecer la malla a simplificar en el objeto simplificador
            simplifier.Initialize(simplifiedMesh);

            // Simplificar la malla basándose en el porcentaje objetivo
            simplifier.SimplifyMesh(targetPercentage);

            // Aplicar los cambios a la malla simplificada
            simplifiedMesh = simplifier.ToMesh();

            // Asignar la malla simplificada al MeshFilter del objeto
            meshFilter.mesh = simplifiedMesh;
        }
    }
}