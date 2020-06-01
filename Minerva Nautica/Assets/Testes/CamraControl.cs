using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamraControl : MonoBehaviour
{
    //what the camera will follow
    public Transform Target;

    //values of the FielOfView
    public int Zoom = 20;
    public int Normal = 30;
    //public int zoomOut = 45;

    //for the camera transition 
    float smooth = 5;

    //variavel de controle do zoom. Inicia como sem zoom.
    private bool isZoomed = false;

   
    void LateUpdate()
    {
        transform.LookAt(Target);      

    }

    // Update is called once per frame
    void Update()
    {
       var key = Input.inputString; //lê a tecla inserida

        if (key == "i")
        {
            isZoomed = !isZoomed; // zoom se torna verdadeiro
        }
        if (key == "o")
        {
            isZoomed = false;
        }
        if (isZoomed)
        {
            GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, Zoom, Time.deltaTime * smooth);
        }
        else
        {
             
            GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, Normal, Time.deltaTime * smooth);               
        } 
    }
}
