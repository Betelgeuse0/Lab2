using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOffScreen : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
    }
    void Update()
    {
        //destroy the gameObject if they are bumped too far away
        if ((player.transform.position - transform.position).magnitude > 25.0f)
            Destroy(gameObject);
    }
}
