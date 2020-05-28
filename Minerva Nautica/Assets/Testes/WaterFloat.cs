using Ditzelgames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Water;

public class WaterFloat : MonoBehaviour
{
    public float AirDrag = 1;
    public float WaterDrag = 10;
    public Transform[] FloatPoints;

    protected Rigidbody Rigidbody;
    protected Water Waves;

    protected float WaterLine;
    protected Vector3[] WaterLinePoints;

    //help vectors
    protected Vector3 centerOffset;

    public Vector3 Center { get { return transform.position + centerOffset; } }
    
    // Start is called before the first frame update
    void Awake()
    {
        Waves = FindObjectOfType<Water>();
        Rigidbody = GetComponent<Rigidbody>();
        Rigidbody.useGravity = false;

        //compuTe center
        WaterLinePoints = new Vector3[FloatPoints.Length];
        for (int i = 0; i < FloatPoints.Length; i++)
            WaterLinePoints[i] = FloatPoints[i].position;
        centerOffset = PhysicsHelper.GetCenter(WaterLinePoints) - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // !!!!!APENAS PARA FACILINAR VISUALIZAÇÃO DOS PONTOS!!!!!!!
    //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        if (FloatPoints == null)
            return;

        for(int i =0; i < FloatPoints.Length; i++)
        {
            if (FloatPoints[i] == null)
                continue;

            if (Waves != null)
            {
                //draw cube
                Gizmos.color = Color.red;
                Gizmos.DrawCube(WaterLinePoints[i], Vector3.one * 0.3f);
            }

            //draw sphere
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(FloatPoints[i].position, 0.1f);

        }

        //draw center
        if (Application.isPlaying)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawCube(new Vector3(Center.x, WaterLine, Center.z), Vector3.one * 0.5f);
        }
    }
}
