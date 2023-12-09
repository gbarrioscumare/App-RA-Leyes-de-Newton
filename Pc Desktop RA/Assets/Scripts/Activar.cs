using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activar : MonoBehaviour
{

    LayerMask mask;
    public float distancia = 1.5f;
    
    void Start()
    {
        mask = LayerMask.GetMask("Raycast Detect");
    }
    void update()
    {
        Debug.Log("rest");
        RaycastHit hit;

        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distancia, mask))
        {
            if(hit.collider.tag == "Objeto Interactivo")
            {
                if(Input.GetMouseButton(0))
                {
                    hit.collider.transform.GetComponent<Habilitar>().HabilitarObject();                }
            }
        }
    }
   
}
