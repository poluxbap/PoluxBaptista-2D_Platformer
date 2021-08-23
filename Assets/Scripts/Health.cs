using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 10;
    public float delayToKill = .5f;

    private int _currentHealth;
    public bool isDead;

    public Animator anim;

    private void Awake()
    {
        isDead = false;
        _currentHealth = health;  
    }

    public void Damage(int damage)
    {
        if(!isDead)
        {
            _currentHealth -= damage;
        }

        if(_currentHealth <= 0)
        {
            Kill();
        }
    }

    private void Kill()
    {
        isDead = true;
        anim.SetBool("IsDead", isDead);
        anim.SetTrigger("Death");
        Destroy(gameObject, delayToKill);
    }
}
