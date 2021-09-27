using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CharacterBase : MonoBehaviour
{
    public SO_Character charInfo;
    public SO_Int coins;
    public SO_Int powerJumps;
    public SO_Int shields;
    public Animator anim;
    public bool isDead = false;

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
        isDead = false;
        _currentHealth = charInfo.health;
    }

    public void Damage(int damage)
    {
        if (isDead) return;

        if(shields.value > 0)
        {
            ItemsManager.Instance.AddItem(ItemsManager.ItemType.SHIELD, -1);
            FlashColorOnHit();
            return;
        }

        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            Kill();
        }

        FlashColorOnHit();
    }

    protected virtual void Kill()
    {
        isDead = true;
        anim.SetBool("IsDead", isDead);
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
