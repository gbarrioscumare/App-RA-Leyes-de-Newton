using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MouseZoom : MonoBehaviour
{
    Vector2 mousescroll;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 ogscale = gameObject.transform.localScale;
        float deltay = Input.mouseScrollDelta.y * 0.1f;
        Vector3 scalefactor = Vector3.one * deltay;
        if (deltay > 0 || deltay < 0)
        {
            gameObject.transform.localScale = ogscale + scalefactor;
        }
    }

}