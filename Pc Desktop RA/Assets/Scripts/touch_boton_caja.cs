using UnityEngine;

public class touch_boton_caja : MonoBehaviour
{
    public GameObject Botiquin;
    public GameObject Caja;
    public GameObject Question;
    public GameObject volver;
    public GameObject intentos;

    public void Activate()
    {
        Caja.SetActive(true);
        volver.SetActive(true);
        Question.SetActive(false);
        Botiquin.SetActive(false);
        intentos.transform.localPosition = new Vector3(-14f, 875f, -0f);
        //intentos.transform.localPosition = new Vector3(-14f, 500f, -6.103517e-05f);

    }
}
