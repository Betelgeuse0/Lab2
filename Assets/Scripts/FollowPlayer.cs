using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Rigidbody rb;
    private GameObject cookie;
    private bool touchedPlayer = false;

    public bool TouchedPlayer => touchedPlayer;

    public float speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        cookie = GameObject.Find("Cookie");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (touchedPlayer)
        {
            if (rb.velocity.magnitude > 1.0f)
                return;
            touchedPlayer = false;
        }
        
        Vector3 vel = cookie.transform.position - transform.position;
        vel.Normalize();
        vel *= speed;
        
        rb.velocity = vel;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
            Destroy(gameObject);
            //touchedPlayer = true;
    }
}
