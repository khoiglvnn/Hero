using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int maxHealth = 50;
    public int curHealth = 50;

    public HealthBar healthBar;
    void Start()
    {
        maxHealth = curHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if(curHealth <= 0)
        {
            Death();
        }
    }

    void TakeDamage(int damage)
    {
        curHealth -= damage;
        healthBar.SetCurHealth(curHealth);
    }
    public void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
