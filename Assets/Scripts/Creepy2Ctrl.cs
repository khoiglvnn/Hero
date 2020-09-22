using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creepy2Ctrl : MonoBehaviour
{
    public int Ehealth = 100;
    private static Animator anim;
    void Start()
    {
        anim = GetComponent<Animator> ();
    }
    
    void Update()
    {
        if (Ehealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    void Damage(int damage)
    {
        Ehealth -= damage;
    }
    private void OnCollisionEnter2D(Collision2D enemy)
    {
        if (enemy.gameObject.tag == "Bullet")
        {
            anim.SetBool("Striking", true);
            StartCoroutine(Activate());
        }
    }

    private IEnumerator Activate()
    {
        yield return new WaitForSeconds(1);
        anim.SetBool("Striking", false);
    }
}
