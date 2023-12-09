using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    public GameObject dialogo1;
    public GameObject dialogo2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            if(dialogo1.activeSelf)
            {
                dialogo1.SetActive(false);
                dialogo2.SetActive(true);
            }
            else
            {
                dialogo1.SetActive(true);
                dialogo2.SetActive(false);
            }
            
            
        }

    }
}
