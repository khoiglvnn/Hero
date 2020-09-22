using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CreepyCtrl1 : MonoBehaviour
{
    public int health = 100;
    private static Animator anim;
    void Start()
    {
        anim = GetComponent<Animator> ();
    }
    
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        
    }
    void Damage(int damage)
    {
        health -= damage;
    }

    private void OnCollisionEnter2D(Collision2D enemy)
    {
        if (enemy.gameObject.tag == "Bullet")
        {
            anim.SetBool("Dead", true);
            StartCoroutine(Activate());
        }
    }

    private IEnumerator Activate()
    {
        yield return new WaitForSeconds(1);
        anim.SetBool("Dead", false);
    }
}
