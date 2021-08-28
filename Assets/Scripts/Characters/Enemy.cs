using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : CharacterBase
{
    public int attack = 5;
    public string attackAnim = "Attack";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var target = collision.gameObject.GetComponent<CharacterBase>();

        if(target)
        {
            target.Damage(attack);
            anim.SetTrigger(attackAnim);
        }
    }
}
