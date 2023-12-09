using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTouch : MonoBehaviour
{
    public float velocidadMouse = 20f;
    public float velocidadTouch = 0.05f;
    public Camera cam;

    void OnMouseDrag()
    {
        float rotX = Input.GetAxis("Mouse X") * velocidadMouse;
        float rotY = Input.GetAxis("Mouse Y") * velocidadMouse;

        Vector3 right = Vector3.Cross(cam.transform.up, transform.position - cam.transform.position);
        Vector3 up = Vector3.Cross(transform.position - cam.transform.position, right);
        transform.rotation = Quaternion.AngleAxis(-rotX, up) * transform.rotation;
        transform.rotation = Quaternion.AngleAxis(rotY, right) * transform.rotation;
    }
    
    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            //Debug.Log("Touch at " + touch.position);
            Ray camRay = cam.ScreenPointToRay(touch.position);
            RaycastHit raycastHit;
            if(Physics.Raycast (camRay, out raycastHit, 10))
            {
                if(touch.phase == TouchPhase.Began)
                {
                    //Debug.Log("Touch");
                }
                else if(touch.phase == TouchPhase.Moved)
                {
                    transform.Rotate(touch.deltaPosition.y * velocidadTouch, -touch.deltaPosition.x * velocidadTouch, 0, Space.World);
                }
      

            }
        }
    }
}
