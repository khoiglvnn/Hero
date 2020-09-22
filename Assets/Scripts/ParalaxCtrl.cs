using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxCtrl : MonoBehaviour
{
    public MeshRenderer[] bg = new MeshRenderer[3];
    Vector2 bg0, bg1, bg2, bg3;
    public Transform player;
    Vector3 temp;
    void Start()
    {
        bg0 = bg[0].material.mainTextureOffset;
        bg1 = bg[1].material.mainTextureOffset;
        bg2 = bg[2].material.mainTextureOffset;
        bg3 = bg[3].material.mainTextureOffset;

    }

    
    void Update()
    {
        bg[0].material.mainTextureOffset = new Vector2(bg0.x + PlayerCtrl.h / 450, bg0.y);
        bg[1].material.mainTextureOffset = new Vector2(bg1.x + PlayerCtrl.h / 450, bg1.y);
        bg[2].material.mainTextureOffset = new Vector2(bg2.x + PlayerCtrl.h / 450, bg2.y);
        bg[3].material.mainTextureOffset = new Vector2(bg3.x + PlayerCtrl.h / 450, bg3.y);
        temp = transform.position;

        bg0 = bg[0].material.mainTextureOffset;
        bg1 = bg[1].material.mainTextureOffset;
        bg2 = bg[2].material.mainTextureOffset;
        bg2 = bg[3].material.mainTextureOffset;
    }
}
