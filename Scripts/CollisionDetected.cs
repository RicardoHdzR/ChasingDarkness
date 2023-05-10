using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetected : MonoBehaviour
{
    //public GameObject wall;
    //public Renderer render;

    

    private void OnCollisionEnter2D(Collision2D collision)
    {   
        Debug.Log("Colision Detectada");
        GetComponent<Renderer>().material.color = Color.white;
        CancelInvoke("CambiaColor");
        //Esto dentro del trigger
        Invoke("CambiarColor", 2f);

        
    }
    //Esto afuera
    void CambiarColor(){
        GetComponent<Renderer>().material.color = Color.black;
    }

    

}
