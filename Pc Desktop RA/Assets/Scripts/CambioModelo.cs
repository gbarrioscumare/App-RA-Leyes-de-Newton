using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;
using System.IO;

    public struct data
{
    public string Titulo;
    public string Parrafo;
    public string ImageURL;
    public string ModelURL;
}

    

    public class CambioModelo : MonoBehaviour    
{
    [SerializeField] TMP_Text uiTituloText;
    [SerializeField] TMP_Text uiParrafoText;
    [SerializeField] RawImage uiRawImage;
    [SerializeField] GameObject uiGameObject;
    public Mesh viewedModel;
    public MeshFilter ObjetoCambiar;
    public GameObject Modelo;

    string jsonURL = "https://drive.google.com/uc?export=download&id=1w8iBb0BXT9EISJS6EKfcQeBJ5l-lBDF1";

    // Start is called before the first frame update
    public void cambiar()
    {
        StartCoroutine(GetData(jsonURL));
    }

    IEnumerator GetData(string url)
    {
        UnityWebRequest request = UnityWebRequest.Get(url);

        yield return request.Send();

        if (request.isNetworkError)
        {
            // error
        }
        else
        {
            Debug.Log("El texto se envio");
            //success...
            data jsondialogo = JsonUtility.FromJson<data>(request.downloadHandler.text);

            uiTituloText.text = jsondialogo.Titulo;
            uiParrafoText.text = jsondialogo.Parrafo;

            
            StartCoroutine(GetModel(jsondialogo.ModelURL));

        }

        request.Dispose();
    }

    IEnumerator GetModel(string url)
    {
        UnityWebRequest request = null;

        if (request == null)
        {
            Debug.Log("no habia request");

            request = UnityWebRequestAssetBundle.GetAssetBundle(url);
        }



        yield return request.Send();

        if (request.isNetworkError)
        {

        }
        else
        {
            Debug.Log("el modelo se envio");


            AssetBundle AB = ((DownloadHandlerAssetBundle)request.downloadHandler).assetBundle;

            GameObject zorro = (GameObject)AB.LoadAsset("Mano");

            Debug.Log("cargando modelo");

            //Instantiate(zorro);


            //yield return new WaitForSeconds(5);

            Modelo = Instantiate(zorro);
            //Foxy = GameObject.Find("Foxy(Clone)");
            //Foxy.transform.Rotate(0.0f, 0.0f, 0.0f, Space.Self);
            //Foxy.SetActive(true);

            Debug.Log("listo!");
            MeshFilter MeshDeObjeto = (MeshFilter)Modelo.GetComponent("MeshFilter");
            Renderer renderer = Modelo.GetComponent<Renderer>();

            viewedModel = MeshDeObjeto.mesh;
            ObjetoCambiar.mesh = viewedModel;
            ObjetoCambiar.GetComponent<MeshRenderer>().material = renderer.material;

            Destroy(Modelo);
            request = null;

        }
        request.Dispose();
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
