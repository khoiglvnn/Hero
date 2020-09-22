using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackdelay = 0.3f;
    public bool attacking = false;
    public GameObject gun;
    public GameObject bullet;

    public Animator anim;
    public Collider2D trigger;

    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        trigger.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !attacking)
        {
            Instantiate(bullet, gun.transform.position, gun.transform.rotation);
            attacking = true;
            trigger.enabled = true;
            attackdelay = 0.3f;
        }

        if (attacking)
        {
            if (attackdelay > 0)
            {
                attackdelay -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                trigger.enabled = false;
            }
        }
        
        anim.SetBool("Attacking", attacking);
    }
}
