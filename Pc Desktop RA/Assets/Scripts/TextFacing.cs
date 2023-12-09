using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextFacing : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        transform.LookAt(Camera.main.transform.position, Camera.main.transform.up);
        transform.Rotate(0.0f, 180.0f, 0.0f, Space.Self);

    }
}