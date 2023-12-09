using UnityEngine;
using TMPro;

public class QuizStats : MonoBehaviour
{
    private TMP_Text field;
    private string s_score = "Puntaje obtenido : ";
    private string s_intentos = "Intentos restantes : ";

    public void UpdateScore(int puntaje)
    {
        field = this.gameObject.GetComponent<TMP_Text>();
        field.text = s_score + puntaje;
    }
    public void UpdateTries(int intentos)
    {
        field = this.gameObject.GetComponent<TMP_Text>();
        field.text = s_intentos + intentos;
    }
    public void ResetPos()
    {
        this.gameObject.transform.localPosition = new Vector3(-14f, 400f, 0f);
    }
    public void EndQuiz()
    {
        Invoke("FinalPoints", 0);
        Invoke("FinalPoints", 2);
    }
    public void MaxTries()
    {
        var x = this.gameObject.GetComponent<TMP_Text>();
        x.text = "Intentos restantes : 7";
    }
    void FinalPoints()
    {
        if ((this.gameObject.activeSelf))
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(true);
        }
    }
}
