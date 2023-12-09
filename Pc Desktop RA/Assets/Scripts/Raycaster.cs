using System;
using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private GameObject targets;
    private string[] guessed = {"-1", "-1", "-1", "-1", "-1", "-1", "-1", };
    private int tries = 7;
    private int score = 0;
    public GameObject InputError;
    public GameObject End;
    public GameObject WrongObj;
    public GameObject score_text;
    public GameObject intentos_text;
    public GameObject completed;
    void Start()
    {
        cam = Camera.main;   
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //Debug.Log("hited object by ray is : "+hit.collider.gameObject.name);
                if (hit.collider.gameObject.GetComponent<touch_boton_caja>() != null)
                {
                    hit.collider.gameObject.GetComponent<touch_boton_caja>().Activate();
                }
                else
                {
                    if(tries > 0)
                    {
                        //Debug.Log("tires > 0 : code exucuted");
                        string[] temp = targets.GetComponent<Quiztxt>().objects;
                        string temp1 = hit.collider.gameObject.name;
                        CheckList(temp,temp1);
                    }
                    else
                    {
                        StartCoroutine(ActMessage(End));
                    }
                }
            }
        }
    }

    void CheckList(String[] list, string name)
    {
        Debug.Log("que es esto " + name);
        if (list.Contains(name) && !guessed.Contains(name))
        {
            //Debug.Log("list contains object and hasnt been guessed");
            for(int i = 0; i<7; i++)
            {
                if (guessed[i] == "-1")
                {
                    guessed[i] = name;
                    break;
                }
            }
            score++;
            tries--;
            score_text.GetComponent<QuizStats>().UpdateScore(score);
            intentos_text.GetComponent<QuizStats>().UpdateTries(tries);
            targets.GetComponent<Quiztxt>().UpdateQuestion(guessed);

            if (guessed[6]!= "-1")
            {
                StartCoroutine(ActMessage(completed));
            }
        }
        else
        {
            if (guessed.Contains(name))
            {
                //Debug.Log("object is in list but has been guessed");
                StartCoroutine(ActMessage(InputError));
            }
            else
            {
                //Debug.Log("Object is not in list");
                StartCoroutine(ActMessage(WrongObj));
                tries--;
                intentos_text.GetComponent<QuizStats>().UpdateTries(tries);
            }
        }
    }
    IEnumerator ActMessage(GameObject text)
    {
        text.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        text.SetActive(false);
    }
    public void Re_Score()
    {
        tries = 7;
    }
}
