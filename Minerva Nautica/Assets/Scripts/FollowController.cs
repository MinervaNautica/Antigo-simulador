using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowController : MonoBehaviour
{
    public float speed;
    public float turnSpeed;
    private float horizontalInput;
    private float forwardInput;

    private Rigidbody boatRb;
    // Start is called before the first frame update
    void Start()
    {
        boatRb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // This is where we get player input
        horizontalInput =  Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // We move the vehicle forward
        boatRb.AddRelativeForce(Vector3.left * speed * forwardInput);
        // We turn the vehicle
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime, Space.World);
    }
}
