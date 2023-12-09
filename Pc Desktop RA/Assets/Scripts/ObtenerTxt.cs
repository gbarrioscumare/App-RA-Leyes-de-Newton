using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObtenerTxt : MonoBehaviour
{
    public Text text;
    public TMP_Text textFinal;
    
    // Start is called before the first frame update
    void Start()
    {
        textFinal.text = text.text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

