using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Refresh : MonoBehaviour
{
   public void Reload()
    {
        SceneManager.LoadScene("Main");
    }
}
