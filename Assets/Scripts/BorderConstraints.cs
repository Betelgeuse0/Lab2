using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderConstraints : MonoBehaviour
{
    private Vector2 boundDist = new Vector2(8, 4.5f);
    private Vector2 bounds;
    private Rigidbody rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        GameObject mainCamera = GameObject.Find("Main Camera");
        bounds = new Vector2(mainCamera.transform.position.x, mainCamera.transform.position.z);
    }

    void FixedUpdate()
    {
        float zBound = bounds.y;
        float xBound = bounds.x;
        
        Vector3 rbPos = rb.position;
        float xPos = rbPos.x;
        float zPos = rbPos.z;
        Vector3 vel = rb.velocity;
        
        //Debug.Log(rbPos);
        if (rbPos.z < (zBound - boundDist.y))
        {
            zPos = zBound - boundDist.y;
        }
        else if (rbPos.z > (zBound + boundDist.y))
        {
            zPos = zBound + boundDist.y;
        }

        if (rbPos.x < (xBound - boundDist.x))
        {
            xPos = xBound - boundDist.x;
        }
        else if (rbPos.x > (xBound + boundDist.x))
        {
            xPos = xBound + boundDist.x;
        }
        
        rb.position = new Vector3(xPos, 0, zPos);
    }
}
