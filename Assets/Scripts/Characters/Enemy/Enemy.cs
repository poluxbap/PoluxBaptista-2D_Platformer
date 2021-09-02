using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : CharacterBase
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var target = collision.gameObject.GetComponent<CharacterBase>();

        if(target)
        {
            target.Damage(charInfo.attack);
            anim.SetTrigger(charInfo.attackAnim);
        }
    }
}
