using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    public Transform player;

    public Vector2 minpos, maxpos;
    public bool bound;

    Vector3 pos_player, temp;
    void Start()
    {
        temp = transform.position;
        
    }
    
    void Update()
    {
        pos_player = player.transform.position;
        transform.position = new Vector3(pos_player.x, temp.y, temp.z);

        if(bound)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x,minpos.x, maxpos.x),
                Mathf.Clamp(transform.position.y,minpos.y, maxpos.y),
                Mathf.Clamp(transform.position.z,transform.position.z, transform.position.z));

        }
    }
}
