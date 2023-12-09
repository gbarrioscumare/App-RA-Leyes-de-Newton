using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateController : MonoBehaviour
{
    public GameObject objectRotate;
    public float rotateSpeed = 40f;
    private bool rotarArriba = false;
    private bool rotarAbajo = false;
    private bool rotarIzquierda = false;
    private bool rotarDerecha = false;


    // Update is called once per frame
    void Update()
    {
        if(rotarArriba == true)
        {
            objectRotate.transform.Rotate(new Vector3(-rotateSpeed, 0f ,  0f) * Time.deltaTime);
        }

        if (rotarAbajo == true)
        {
            objectRotate.transform.Rotate(new Vector3(rotateSpeed, 0f, 0f) * Time.deltaTime);
        }

        if (rotarIzquierda == true)
        {
            objectRotate.transform.Rotate(new Vector3(0f, 0f, rotateSpeed) * Time.deltaTime);
        }

        if (rotarDerecha == true)
        {
            objectRotate.transform.Rotate(new Vector3(0f, 0f, -rotateSpeed) * Time.deltaTime);
        }
    }

    public void HaciaArriba()
    {
        rotarArriba = true;
    }

    public void HaciaAbajo()
    {
        rotarAbajo = true;
    }

    public void HaciaIzquiera()
    {
        rotarIzquierda = true;
    }

    public void HaciaDerecha()
    {
        rotarDerecha = true;
    }
    public void sinFuncion()
    {
        rotarArriba = false;
        rotarAbajo = false;
        rotarIzquierda = false;
        rotarDerecha = false;

    }
}
