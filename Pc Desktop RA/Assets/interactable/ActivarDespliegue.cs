using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarDespliegue : Interactable
{
    Despliegue activate;
    public string NombreObjeto;
    
    
    public override void Interact(){
        //print(GameObject.transform.parent);
        base.Interact();
        NombreObjeto = transform.root.name;

        activate = GameObject.FindGameObjectWithTag("DesplegarObjetos").GetComponent<Despliegue>();

        if (NombreObjeto == "Contenedor 1") { activate.WhenDespligue1ON(); }
        if (NombreObjeto == "Contenedor 2") { activate.WhenDespligue2ON(); }
        if (NombreObjeto == "Contenedor 3") { activate.WhenDespligue3ON(); }
        if (NombreObjeto == "Contenedor 4") { activate.WhenDespligue4ON(); }
        if (NombreObjeto == "Contenedor 5") { activate.WhenDespligue5ON(); }
        if (NombreObjeto == "Contenedor 6") { activate.WhenDespligue6ON(); }
        if (NombreObjeto == "Contenedor 7") { activate.WhenDespligue7ON(); }

    }
}
