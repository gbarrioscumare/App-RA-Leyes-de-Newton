using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public GameObject ObjetoADestruir;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    public void DestruirObjeto()
    {
        Destroy(ObjetoADestruir);
        Time.timeScale = 1f;
    }


}
