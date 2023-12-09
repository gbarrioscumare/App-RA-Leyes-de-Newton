using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Habilitar : MonoBehaviour
{
    public GameObject dialogoAR;


    public void HabilitarObject()
    {
        Debug.Log("rest");
        if (dialogoAR.activeSelf)
        {
            dialogoAR.SetActive(false);
        }
        else
        {
            dialogoAR.SetActive(true);
        }
    }



}
