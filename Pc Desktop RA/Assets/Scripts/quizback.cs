using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quizback : MonoBehaviour
{
    public GameObject[] activarBotiquin;

    public void Activar()
    {
        GameObject[] apagarEscena;

        apagarEscena = GameObject.FindGameObjectsWithTag("Caja");
        activarBotiquin = GameObject.FindGameObjectsWithTag("Botiquin");
        foreach(GameObject Caja in apagarEscena) {
            Caja.SetActive(true);
        }
        foreach(GameObject Botiquin in activarBotiquin)
        {
            Botiquin.SetActive(false);
        }        
        
    }

    public void Volver()
    {
        GameObject[] apagarEscena;

        //Debug.Log("ACA ESTA LA LISTA"+ activarBotiquin.Length);
        apagarEscena = GameObject.FindGameObjectsWithTag("Caja");
        //Debug.Log(apagarEscena.Length);

        foreach (GameObject Botiquin in activarBotiquin)
        {
            Botiquin.SetActive(true);
        }
        foreach (GameObject Caja in apagarEscena)
        {
            Caja.SetActive(false);
        }

        /*apagarEscena = GameObject.FindGameObjectsWithTag("Caja");
        activarBotiquin = GameObject.FindGameObjectsWithTag("Botiquin");
        apagarEscena.SetActive(false);
        activarBotiquin.SetActive(true);
        */
    }
}
