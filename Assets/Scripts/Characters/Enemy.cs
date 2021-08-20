using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int attack = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var target = collision.gameObject.GetComponent<Health>();

        if(target)
        {
            target.Damage(attack);
        }
    }
}
