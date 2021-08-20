using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 10;
    public float delayToKill = .5f;

    private int _currentHealth;
    private bool _isDead;

    private void Awake()
    {
        _isDead = false;
        _currentHealth = health;
    }

    public void Damage(int damage)
    {
        if(!_isDead)
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
        _isDead = true;
        Destroy(gameObject, delayToKill);
    }
}
