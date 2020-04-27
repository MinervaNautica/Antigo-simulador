using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatObject : MonoBehaviour
{
    private Rigidbody rb;
    // K 
    public float K = 5;
    public float atrito;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Simulating buoyancy to the object:
        float level = transform.position.y;

        if (level < 0.5f)
        {
            rb.drag = atrito;
            rb.AddForce(Vector3.up * (-level) * K);
        }
        else
            rb.drag = 0.1f;
    }
}
