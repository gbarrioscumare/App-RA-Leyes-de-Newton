using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despliegue : MonoBehaviour
{
    public List<GameObject> Contenedores;
    public GameObject Botiquin;
    public List<GameObject> ListaCompleta;
    public List<GameObject> ListaDespliegue1;
    public List<GameObject> ListaDespliegue2;
    public List<GameObject> ListaDespliegue3;
    public List<GameObject> ListaDespliegue4;
    public List<GameObject> ListaDespliegue5;
    public List<GameObject> ListaDespliegue6;
    public List<GameObject> ListaDespliegue7;
    public int contadorDespliegue =0;
    
    
    void Update(){
        //print(contadorDespliegue);
    }


    public void WhenDespligue1ON(){
        contadorDespliegue+=1;

        for(int i = 0; i< Contenedores.Count;i++){
            Contenedores[i].SetActive(false);
        }
        for(int i = 0; i<ListaCompleta.Count; i++)
        {
            ListaCompleta[i].SetActive(false);
        }
        for(int i = 0; i<ListaDespliegue1.Count; i++)
        {
            ListaDespliegue1[i].SetActive(true);
        }
    }
    public void WhenDespligue1OFF(){
        for(int i = 0; i< Contenedores.Count;i++){
            Contenedores[i].SetActive(true);
        }
        Botiquin.SetActive(true);
        for(int x = 0; x<ListaCompleta.Count; x++)
        {
            ListaCompleta[x].SetActive(true);
        }
        for(int x = 0; x<ListaDespliegue1.Count; x++)
        {
            ListaDespliegue1[x].SetActive(false);
        }
    }


    public void WhenDespligue2ON(){
        contadorDespliegue+=1;

        for(int i = 0; i< Contenedores.Count;i++){
            Contenedores[i].SetActive(false);
        }
        for(int i = 0; i<ListaCompleta.Count; i++)
        {
            ListaCompleta[i].SetActive(false);
        }
        for(int i = 0; i<ListaDespliegue2.Count; i++)
        {
            ListaDespliegue2[i].SetActive(true);
        }
    }

    public void WhenDespligue2OFF(){

        for(int i = 0; i< Contenedores.Count;i++){
            Contenedores[i].SetActive(true);
        }
        Botiquin.SetActive(true);
        for(int x = 0; x<ListaCompleta.Count; x++)
        {
            ListaCompleta[x].SetActive(true);
        }
        for(int x = 0; x<ListaDespliegue2.Count; x++)
        {
            ListaDespliegue2[x].SetActive(false);
        }
    }


    public void WhenDespligue3ON(){
        contadorDespliegue+=1;

        for(int i = 0; i< Contenedores.Count;i++){
            Contenedores[i].SetActive(false);
        }
        for(int i = 0; i<ListaCompleta.Count; i++)
        {
            ListaCompleta[i].SetActive(false);
        }
        for(int i = 0; i<ListaDespliegue3.Count; i++)
        {
            ListaDespliegue3[i].SetActive(true);
        }
    }
    public void WhenDespligue3OFF(){
        for(int i = 0; i< Contenedores.Count;i++){
            Contenedores[i].SetActive(true);
        }
        Botiquin.SetActive(true);
        for(int x = 0; x<ListaCompleta.Count; x++)
        {
            ListaCompleta[x].SetActive(true);
        }
        for(int x = 0; x<ListaDespliegue3.Count; x++)
        {
            ListaDespliegue3[x].SetActive(false);
        }
    }

    public void WhenDespligue4ON(){
        contadorDespliegue+=1;

        for(int i = 0; i< Contenedores.Count;i++){
            Contenedores[i].SetActive(false);
        }
        for(int i = 0; i<ListaCompleta.Count; i++)
        {
            ListaCompleta[i].SetActive(false);
        }
        for(int i = 0; i<ListaDespliegue4.Count; i++)
        {
            ListaDespliegue4[i].SetActive(true);
        }
    }
    public void WhenDespligue4OFF(){
        for(int i = 0; i< Contenedores.Count;i++){
            Contenedores[i].SetActive(true);
        }
        Botiquin.SetActive(true);
        for(int x = 0; x<ListaCompleta.Count; x++)
        {
            ListaCompleta[x].SetActive(true);
        }
        for(int x = 0; x<ListaDespliegue4.Count; x++)
        {
            ListaDespliegue4[x].SetActive(false);
        }
    }


    public void WhenDespligue5ON(){
        contadorDespliegue+=1;

        for(int i = 0; i< Contenedores.Count;i++){
            Contenedores[i].SetActive(false);
        }
        for(int i = 0; i<ListaCompleta.Count; i++)
        {
            ListaCompleta[i].SetActive(false);
        }
        for(int i = 0; i<ListaDespliegue5.Count; i++)
        {
            ListaDespliegue5[i].SetActive(true);
        }
    }
    public void WhenDespligue5OFF(){
        for(int i = 0; i< Contenedores.Count;i++){
            Contenedores[i].SetActive(true);
        }
        Botiquin.SetActive(true);
        for(int x = 0; x<ListaCompleta.Count; x++)
        {
            ListaCompleta[x].SetActive(true);
        }
        for(int x = 0; x<ListaDespliegue5.Count; x++)
        {
            ListaDespliegue5[x].SetActive(false);
        }
    }


    public void WhenDespligue6ON(){
        contadorDespliegue+=1;

        for(int i = 0; i< Contenedores.Count;i++){
            Contenedores[i].SetActive(false);
        }
        for(int i = 0; i<ListaCompleta.Count; i++)
        {
            ListaCompleta[i].SetActive(false);
        }
        for(int i = 0; i<ListaDespliegue6.Count; i++)
        {
            ListaDespliegue6[i].SetActive(true);
        }
    }
    public void WhenDespligue6OFF(){
        for(int i = 0; i< Contenedores.Count;i++){
            Contenedores[i].SetActive(true);
        }
        Botiquin.SetActive(true);
        for(int x = 0; x<ListaCompleta.Count; x++)
        {
            ListaCompleta[x].SetActive(true);
        }
        for(int x = 0; x<ListaDespliegue6.Count; x++)
        {
            ListaDespliegue6[x].SetActive(false);
        }
    }

    public void WhenDespligue7ON(){
        contadorDespliegue+=1;

        for(int i = 0; i< Contenedores.Count;i++){
            Contenedores[i].SetActive(false);
        }
        for(int i = 0; i<ListaCompleta.Count; i++)
        {
            ListaCompleta[i].SetActive(false);
        }
        for(int i = 0; i<ListaDespliegue7.Count; i++)
        {
            ListaDespliegue7[i].SetActive(true);
        }
    }
    public void WhenDespligue7OFF(){
        for(int i = 0; i< Contenedores.Count;i++){
            Contenedores[i].SetActive(true);
        }
        Botiquin.SetActive(true);
        for(int x = 0; x<ListaCompleta.Count; x++)
        {
            ListaCompleta[x].SetActive(true);
        }
        for(int x = 0; x<ListaDespliegue7.Count; x++)
        {
            ListaDespliegue7[x].SetActive(false);
        }
    }
}
