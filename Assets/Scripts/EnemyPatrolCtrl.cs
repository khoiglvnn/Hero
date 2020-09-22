using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyPatrolCtrl : MonoBehaviour
{

    public int health = 100;
    public int Edamage = 10;
    public float Espeed = 4f;
    public Transform A, B;
    public Rigidbody2D enemy;
    public GameObject player;
    
    float enemySpeed;
    public Vector2 directional;
    private static Animator anim;

    public void Awake()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("Idle", true);
        
    }

    public void Start()
    {
        if (player.transform.position.x > B.transform.position.x)
        {
            enemySpeed = -Espeed;
            A.transform.parent = null;
            B.transform.parent = null;
            anim.SetBool("Walk", true);
            
        }
        else
        {
            enemySpeed = Espeed;
            A.transform.parent = null;
            B.transform.parent = null;
            anim.SetBool("Walk", true);
        }
    }

    void Update()
    {
        enemy.velocity = new Vector2(enemySpeed,0);
        transform.right = enemy.velocity;
        
        if (enemy.transform.position.x > B.transform.position.x)
        {
            enemySpeed = -Espeed;
        }
        else if(enemy.transform.position.x < A.transform.position.x)
        {
            enemySpeed = Espeed;
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            anim.SetBool("Hurt", true);
            StartCoroutine(Hurt());
        }
    }
    
    private IEnumerator Hurt()
    {
        yield return new WaitForSeconds(2);
        anim.SetBool("Hurt", false);
    }

    
    private void Damage(int damage)
    {
        health -= damage;
    }
}
