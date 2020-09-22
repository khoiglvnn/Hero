using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    public float Bspeed = 50f;
    public float lifeTime = 2f;
    float t;
    void Start()
    {
        t = 0;
        rb = GetComponent<Rigidbody2D>();

    }
    void Update()
    {
        rb.velocity = transform.right * Bspeed;

        t += Time.deltaTime;
        if(t>= lifeTime)
        {
            Destroy(gameObject, 2f);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
