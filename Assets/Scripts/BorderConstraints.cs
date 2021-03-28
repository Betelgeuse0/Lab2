using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderConstraints : MonoBehaviour
{
    public float xBound = 11;
    public float zBound = 5;
    
    void Update()
    {
        float xPos = transform.position.x;
        float zPos = transform.position.z;
        
        if (transform.position.z < -zBound)
        {
            zPos = -zBound;
        }
        else if (transform.position.z > zBound)
        {
            zPos = zBound;
        }

        if (transform.position.x < -xBound)
        {
            xPos = -xBound;
        }
        else if (transform.position.x > xBound)
        {
            xPos = xBound;
        }

        transform.position = new Vector3(xPos, 0, zPos);
    }
}
