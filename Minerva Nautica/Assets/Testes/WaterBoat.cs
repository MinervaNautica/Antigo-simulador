using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ditzelgames;

public class WaterBoat : MonoBehaviour
{
    //Visible Properties
    public Transform Motor;
    public float SteerPower = 500f;
    public float Power = 5f;
    public float MaxSpeed = 10f;
    public float Drag = 0.1f;

    //used Components
    protected Rigidbody boatRB;
    protected Quaternion StartRotation;

    public void Awake()
    {
        boatRB = GetComponent<Rigidbody>();
        StartRotation = Motor.localRotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //default direction
        var forceDirection = transform.forward;
        var steer = 0;

        //steerdirection [-1,0,1]
        if (Input.GetKey(KeyCode.A))
            steer = 1;
        if (Input.GetKey(KeyCode.D))
            steer = -1;

        //Rotational Force
        boatRB.AddForceAtPosition(steer * transform.right * SteerPower / 100f, Motor.position);

        //Compute vectors
        var forward = Vector3.Scale(new Vector3(1, 0, 1), transform.forward);

        //forward / backward power
        if (Input.GetKey(KeyCode.W))
            PhysicsHelper.ApplyForceToReachVelocity(boatRB, forward * MaxSpeed, Power);
        if (Input.GetKey(KeyCode.S))
            PhysicsHelper.ApplyForceToReachVelocity(boatRB, forward * -MaxSpeed, Power);



    }
}
