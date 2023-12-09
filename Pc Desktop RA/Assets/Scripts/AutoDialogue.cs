using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class AutoDialogue : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public string[] lines;
    public int[] linea;
    public int[] lineaNumeros;
    public int[] lineaGasa,
    lineaPinza, 
    lineaParche, 
    lineaParche2, 
    lineaVendas,
    lineaCinta, 
    lineaPanal, 
    lineaAlfiler, 
    lineaGuantes,
    lineaSuero, 
    lineaTermometro,
    lineaTijera;
  
    public float textSpeed = 0.1f;
    int index;
    Camera cam;
    public GameObject vieja;
    public GameObject numeros;
    public GameObject gasa;
    public GameObject pinza;
    public GameObject parche;
    public GameObject parche2;
    public GameObject vendas;
    public GameObject cinta;
    public GameObject panal;
    public GameObject alfiler;
    public GameObject guantes;
    public GameObject suero;
    public GameObject termometro;
    public GameObject tijeras;
    public GameObject nombreGasa1;
    public GameObject nombreGasa2;
    public GameObject nombreGasa3;
    public GameObject nombreCinta;
    public GameObject nombreTijera;
    public GameObject nombreGuantes;
    public GameObject nombreSuero;
    

    //public GameObject[] imagenes;
    private GameObject[] g_objects;

    void Start()
    {
        cam = Camera.main;
        dialogueText.text = string.Empty; 
        g_objects = new GameObject[14];
        g_objects[0] = vieja;
        g_objects[1] = numeros;
        g_objects[2] = gasa;
        g_objects[3] = pinza;
        g_objects[4] = parche;
        g_objects[5] = parche2;
        g_objects[6] = vendas;
        g_objects[7] = cinta;
        g_objects[8] = panal;
        g_objects[9] = alfiler;
        g_objects[10] = guantes;
        g_objects[11] = suero;
        g_objects[12] = termometro;
        g_objects[13] = tijeras;
        
        StartDialogue();
    }

    void Update()
    {
        //if (hit.collider.gameObject.GetComponent<Button>() != null)
        if(linea.Contains(index))
        {
            vieja.SetActive(true);

        }
        else
        {
            vieja.SetActive(false);
        }
        
        if (lineaNumeros.Contains(index))
        {
            numeros.SetActive(true);
        }
        else
        {
            numeros.SetActive(false);
        }
        if(lineaGasa.Contains(index))
        {
            gasa.SetActive(true);
            /*
            var colorText1 = nombreGasa1.GetComponent<CambiarColorNombre>();
            colorText1.ActualizarColor();
            var colorText2 = nombreGasa2.GetComponent<CambiarColorNombre>();
            colorText2.ActualizarColor();
            var colorText3 = nombreGasa3.GetComponent<CambiarColorNombre>();
            colorText3.ActualizarColor();
            */
        }
        else
        {
            gasa.SetActive(false);
        }
        if(lineaPinza.Contains(index))
        {
            pinza.SetActive(true);
        }
        else
        {
            pinza.SetActive(false);
        }
        if(lineaParche.Contains(index))
        {
            parche.SetActive(true);
        }
        else
        {
            parche.SetActive(false);
        }
        if(lineaParche2.Contains(index))
        {
            parche2.SetActive(true);
        }
        else
        {
            parche2.SetActive(false);
        }
        if(lineaVendas.Contains(index))
        {
            vendas.SetActive(true);

        }
        else
        {
            vendas.SetActive(false);
        }
        if(lineaCinta.Contains(index))
        {
            cinta.SetActive(true);
            var colorText5 = nombreCinta.GetComponent<CambiarColorNombre>();
            colorText5.ActualizarColor();
        }
        else
        {
            cinta.SetActive(false);
        }
        if(lineaPanal.Contains(index))
        {
            panal.SetActive(true);
        }
        else
        {
            panal.SetActive(false);
        }
        if(lineaAlfiler.Contains(index))
        {
            alfiler.SetActive(true);
        }
        else
        {
            alfiler.SetActive(false);
        }
        if(lineaGuantes.Contains(index))
        {
            guantes.SetActive(true);
            var colorText6 = nombreGuantes.GetComponent<CambiarColorNombre>();
            colorText6.ActualizarColor();
        }
        else
        {
            guantes.SetActive(false);
        }
        if(lineaSuero.Contains(index))
        {
            suero.SetActive(true);
            var colorText7 = nombreSuero.GetComponent<CambiarColorNombre>();
            colorText7.ActualizarColor();
        }
        else
        {
            suero.SetActive(false);
        }
        if(lineaTermometro.Contains(index))
        {
            termometro.SetActive(true);
        }
        else
        {
            termometro.SetActive(false);
        }
        if(lineaTijera.Contains(index))
        {
            tijeras.SetActive(true);
            var colorText6 = nombreGuantes.GetComponent<CambiarColorNombre>();
            colorText6.ActualizarColor();
        }
        else
        {
            tijeras.SetActive(false);
        }
        
    }
    public void NextText()
    {
        if (dialogueText.text == lines[index])
        {
            NextLine();
        }
        else
        {
            StopAllCoroutines();
            dialogueText.text = lines[index];
        }
    }
    public void PreviousText()
    {
        if (dialogueText.text == lines[index])
        {
            PreviousLine();
        }
        else
        {
            StopAllCoroutines();
            dialogueText.text = lines[index];
        }
    }
    public void StartDialogue()
    {
        index = 0;
        StartCoroutine(WriteLine());
        string nombre = index.ToString();
        FindObjectOfType<audiocontroller>().Play(nombre);
    }

    IEnumerator WriteLine()
    {
        foreach(char letter in lines[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(textSpeed);

        }
    }
    public void NextLine()
    {
        if (index < lines.Length - 1 )
        {
            index++;
            string nombre = index.ToString();
            //FindObjectOfType<audiocontroller>().Play(nombre);
            dialogueText.text = string.Empty;
            StartCoroutine(WriteLine());

        }
        else
        {
            vieja.SetActive(false);
            gameObject.SetActive(false);
        }
    }
    public void PreviousLine()
    {
    
        if (index <= lines.Length - 1)
        {
            index--;
            if(index >= 0)
            {
                dialogueText.text = string.Empty;
                StartCoroutine(WriteLine());
            }
            else
            {
                index = 0;
            }
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
    /*public void Cerrar()
    {
        for (int x = 0; x < imagenes.Length; x++)
        {
            imagenes[x].SetActive(false);
        }
    }*/
    public void ImageCheck()
    {
        foreach (GameObject temp in g_objects)
        {
            if (temp.activeSelf)
            {
                temp.SetActive(false);
            }
        }
    }
}
