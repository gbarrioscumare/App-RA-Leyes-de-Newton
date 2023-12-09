using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GravityButton : MonoBehaviour
{
    public Rigidbody rb;


    private bool isGravityActive = false;

    public void OnButtonClick()
    {
        isGravityActive = rb.useGravity;
        // Cambiar el estado de la gravedad y la propiedad useGravity del Rigidbody
        if (isGravityActive)
        {
            print("-------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            print(isGravityActive);
            rb.useGravity = false;
        }
        else
        {
            print("_______________________________________________________________________________");
            rb.useGravity = true;
        }
    }
}
