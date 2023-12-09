using UnityEngine;
using TMPro;
using System.Linq;
using System.Drawing;
using Unity.VisualScripting;

public class Quiztxt : MonoBehaviour
{
    private TMP_Text component;
    private string[] elements = {"alcohol","alcohol pad","algodon","aposito de gasa","aposito espuma","aposito absorvente","cinta"
    ,"cinta medica","cloruro de sodio","gasa no tejida 5x5","gasa no tejida 10x10","gasa parafinada","jeringa","palos de helado"
    ,"tijeras","carton","caja de guantes","gel pack"};
    [HideInInspector] public string[] objects = new string[7];
    public void Datafield()
    {
        //botiquin = GameObject.Find("Botiquinpref(Clone)");
        string data = "Seleccione en el botiquin uno de los siguientes siguientes elementos: ";
        int[] usednumbers = new int[19];
        objects = new string[7];
        int cont = 0;
        for (int i=0; i<7; i++)
        {
            int n = Random.Range(0, 18);
            if (usednumbers.Contains(n))
            {
                i--;
            }
            else
            {
                data += elements[n] + " ,";
                objects[cont] = elements[n];
                usednumbers[cont] += n;
                cont++;
            }
        }
        component = GetComponent<TMP_Text>();
        component.text = (data.Remove(data.Length - 2) + ".");

    }
    public void UpdateQuestion(string[] x)
    {
        string y = "Seleccione en el botiquin uno de los siguientes siguientes elementos: ";
        foreach(string obj in objects)
        {
            if(!x.Contains(obj))
            {
                y += obj + " ,";
            }
        }
        component = GetComponent<TMP_Text>();
        component.text = (y.Remove(y.Length - 2) + ".");
    }

}
