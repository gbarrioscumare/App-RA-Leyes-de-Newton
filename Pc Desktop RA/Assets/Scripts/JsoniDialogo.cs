using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;
using System.IO;

public struct ata
{
    public string Titulo;
    public string Parrafo;
    public string ImageURL;
    public string ModelURL;
}
public class JsoniDialogo : MonoBehaviour
{
    [SerializeField] TMP_Text uiTituloText;
    [SerializeField] TMP_Text uiParrafoText;
    [SerializeField] RawImage uiRawImage;
    [SerializeField] GameObject uiGameObject;
    public Mesh viewedModel;
    public MeshFilter ObjetoCambiar;
    public GameObject Modelo;


    string jsonURL = "https://drive.google.com/uc?export=download&id=1w8iBb0BXT9EISJS6EKfcQeBJ5l-lBDF1" ;

    void Start()
    {
        StartCoroutine(GetData (jsonURL));
    }

    IEnumerator GetData(string url)
    {
        UnityWebRequest request = UnityWebRequest.Get(url);

        yield return request.Send();

        if(request.isNetworkError)
        {
            // error
        }
        else
        {
            Debug.Log("El texto se envio");
            //success...
            ata jsondialogo = JsonUtility.FromJson<ata>(request.downloadHandler.text);

            uiTituloText.text = jsondialogo.Titulo;
            uiParrafoText.text = jsondialogo.Parrafo;

            StartCoroutine(GetImage(jsondialogo.ImageURL));
            StartCoroutine(GetModel(jsondialogo.ModelURL));

        }

        request.Dispose();
    }

    IEnumerator GetImage(string url)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture (url);

        yield return request.Send();

        if (request.isNetworkError)
        {
            
        }
        else
        {
            Debug.Log("la imagen se envio");
            uiRawImage.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
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

            GameObject zorro = (GameObject)AB.LoadAsset(uiTituloText.text);

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
