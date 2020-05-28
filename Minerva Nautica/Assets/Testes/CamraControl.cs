using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamraControl : MonoBehaviour
{
    //what the camera will follow
    public Transform Target;

    //values of the FielOfView
    public int ultraZoom = 20;
    public int zoom = 30;
    public int zoomOut = 45;

    //for the camera transition 
    float smooth = 5;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(Target);

        var key = Input.inputString;

        if (key == "u")
        {
            GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, ultraZoom, Time.deltaTime * smooth);
        }
        else
        {
            if (key == "i")
            {
                GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, zoom, Time.deltaTime * smooth);
            }
            else
            {
                GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, zoomOut, Time.deltaTime * smooth);
            }
        }

    }
}
