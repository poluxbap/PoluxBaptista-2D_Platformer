using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CharacterBase : MonoBehaviour
{
    public int health = 10;
    public float delayToKill = .5f;

    public bool isDead;

    public Animator anim;

    [Space]
    [Header("onHit Animation")]
    public List<SpriteRenderer> spriteRederers;
    public Color onHitColor = Color.red;
    public float onHitDuration = .3f;

    private int _currentHealth;
    private Tween _currentTwenn;

    private void OnValidate()
    {
        spriteRederers = new List<SpriteRenderer>();
        foreach (var child in transform.GetComponentsInChildren<SpriteRenderer>())
        {
            spriteRederers.Add(child);
        }
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
        isDead = false;
        _currentHealth = health;
    }

    public void Damage(int damage)
    {
        if (!isDead)
        {
            _currentHealth -= damage;
        }

        if (_currentHealth <= 0)
        {
            Kill();
        }

        FlashColorOnHit();
    }

    private void Kill()
    {
        isDead = true;
        anim.SetBool("IsDead", isDead);
        anim.SetTrigger("Death");
        Destroy(gameObject, delayToKill);
    }

    public void FlashColorOnHit()
    {

        if (_currentTwenn != null)
        {
            _currentTwenn.Kill();
            spriteRederers.ForEach(i => i.color = Color.white);
        }

        foreach (var sprite in spriteRederers)
        {
            _currentTwenn = sprite.DOColor(onHitColor, onHitDuration).SetLoops(2, LoopType.Yoyo);
        }
    }
}
