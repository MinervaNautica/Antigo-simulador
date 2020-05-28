using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//MEDIAMAX YT CHANEL

//[RequireComponent(typeof(FloatObjectScript))]
public class ControllerScript : MonoBehaviour
{
    public Vector3 COM;
    [Space(15)]
    public float speed = 1.0f;
    public float steerSpeed = 1.0f;
    public float movementThresold = 10.0f;

    
    float verticalInput;
    float movementFactor;
    float horizontalInput;
    float steerFactor;

    // Update is called once per frame
    void Update()
    {
        Movement();
        Steer();
    }



    void Movement()
    {
        verticalInput = Input.GetAxis("Vertical");
        movementFactor = Mathf.Lerp(movementFactor, verticalInput, Time.deltaTime / movementThresold);
        transform.Translate(movementFactor * speed, 0.0f, 0.0f);
    }

    void Steer()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        steerFactor = Mathf.Lerp(steerFactor, horizontalInput * verticalInput, Time.deltaTime / movementThresold);
        transform.Rotate(0.0f, steerFactor * steerSpeed, 0.0f);
    }
}
