using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LakeCheck : MonoBehaviour
{
    public PlayerCtrl player;
    void Start()
    {
        player = gameObject.GetComponent<PlayerCtrl>();
    }

    
    void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger == false)
        {
            player.lake = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.isTrigger == false)
        {
            player.lake = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.isTrigger == false)
        {
            player.lake = false;
        }
    }
}
