using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CambiarColorNombre : MonoBehaviour
{
    public TextMeshProUGUI texto;
    // Start is called before the first frame update
    public void ActualizarColor()
    {
        Debug.Log("entre");
        texto.color = new Color32(15, 98, 230, 255);
    }

}
