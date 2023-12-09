using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rendimiento : MonoBehaviour
{
    public int targetFrameRate = 30; // Framerate objetivo para mejorar el rendimiento

    private void Start()
    {
        // Establecer el framerate objetivo
        Application.targetFrameRate = targetFrameRate;

        // Configurar la calidad m�s baja
        SetLowestQuality();
    }

    private void SetLowestQuality()
    {
        int lowestQualityLevel = QualitySettings.names.Length - 1; // �ndice del nivel de calidad m�s bajo

        // Establecer el nivel de calidad m�s bajo
        QualitySettings.SetQualityLevel(lowestQualityLevel, true);
    }
}