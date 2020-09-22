using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public float speed = 50f, maxspeed = 10, jumpPow = 100f;
    public bool lake = true, doublejump = false;
    public static float h;
    
    
    public float fireRate = 2f;
    
    
    public Rigidbody2D player;
    public Animator anim;
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }
    
    void Update()
    {
        anim.SetBool("Lake", lake);
        anim.SetFloat("Speed", Mathf.Abs(player.velocity.x));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(lake)
            {
                player.AddForce((Vector2.up * jumpPow));
                doublejump = true;
                lake = true;
                
            }      
            else
            {
                if(doublejump)
                {
                    doublejump = false;
                    player.velocity = new Vector2(player.velocity.x, 0);
                    player.AddForce(Vector2.up * jumpPow * 1f);
                    lake = false;
                }
            }
            anim = gameObject.GetComponent<Animator>();
        }
    }
    private void FixedUpdate()
    {
        h = Input.GetAxis("Horizontal");
        if (h != 0)
        {
            transform.right = new Vector3(player.velocity.x, 0,0);
        }
        

        player.AddForce((Vector2.right) * speed * h);

        if (player.velocity.x > maxspeed)
        {
            player.velocity = new Vector2(maxspeed, player.velocity.y);
        }
        if (player.velocity.x < -maxspeed)
        {
            player.velocity = new Vector2(-maxspeed, player.velocity.y);
        }
    }
}
