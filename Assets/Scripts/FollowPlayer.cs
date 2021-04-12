using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Rigidbody rb;
    private GameObject player;
    private PlayerController playerScript;
    private bool touchedPlayer = false;

    public float speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (touchedPlayer)
        {
            if (rb.velocity.magnitude > 1.0f)
                return;
            else
                touchedPlayer = false;
        }
        
        Vector3 vel = playerScript.Rb.position - rb.position;
        vel.Normalize();
        vel *= speed;
        
        rb.velocity = vel;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
            touchedPlayer = true;
    }
}
