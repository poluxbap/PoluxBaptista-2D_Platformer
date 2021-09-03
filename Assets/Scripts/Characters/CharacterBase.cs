using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CharacterBase : MonoBehaviour
{
    public SO_Character charInfo;
    public SO_Int items;
    public Animator anim;

    private int _currentHealth;
    private Tween _currentTwenn;

    private void OnValidate()
    {
        charInfo.spriteRederers = new List<SpriteRenderer>();
        foreach (var child in transform.GetComponentsInChildren<SpriteRenderer>())
        {
            charInfo.spriteRederers.Add(child);
        }
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
        charInfo.isDead = false;
        _currentHealth = charInfo.health;
    }

    public void Damage(int damage)
    {
        if (!charInfo.isDead && items.shield == 0)
        {
            _currentHealth -= damage;
        }
        else if(items.shield > 0)
        {
            items.shield--;
        }

        if (_currentHealth <= 0)
        {
            Kill();
        }

        FlashColorOnHit();
    }

    private void Kill()
    {
        charInfo.isDead = true;
        anim.SetBool("IsDead", charInfo.isDead);
        anim.SetTrigger("Death");
        Destroy(gameObject, charInfo.delayToKill);
    }

    public void FlashColorOnHit()
    {

        if (_currentTwenn != null)
        {
            _currentTwenn.Kill();
            charInfo.spriteRederers.ForEach(i => i.color = Color.white);
        }

        foreach (var sprite in charInfo.spriteRederers)
        {
            _currentTwenn = sprite.DOColor(charInfo.onHitColor, charInfo.onHitDuration).SetLoops(2, LoopType.Yoyo);
        }
    }
}
