using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeController : MonoBehaviour
{

    public GameObject objectSize;
    private bool aumentar = false;
    private bool reducir = false;
   


    // Update is called once per frame
    void Update()

    {
        if (aumentar == true)
        {
            objectSize.transform.localScale = objectSize.transform.localScale + new Vector3(1f, 1f, 1f) * Time.deltaTime;
        }

        if (reducir == true)
        {
            objectSize.transform.localScale = objectSize.transform.localScale - new Vector3(1f, 1f, 1f) * Time.deltaTime;
        }

        
    }

    public void aumento()
    {
        aumentar = true;
    }

    public void reduccion()
    {
        reducir = true;
    }

    
    public void sinFuncion()
    {
        aumentar = false;
        reducir = false;
        
    }
}
