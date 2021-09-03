using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SO_Character : ScriptableObject
{
    [Header("Base Info")]
    public int health = 10;
    public float delayToKill = .5f;
    public List<SpriteRenderer> spriteRederers;
    public Color onHitColor = Color.red;
    public float onHitDuration = .3f;

    [Space]
    [Header("Player Info")]
    public float speed;
    public float runSpeed;
    public float jumpForce;
    public float powerJumpForce;

    [Space]
    [Header("Enemy Info")]
    public int attack = 5;
    public string attackAnim = "Attack";
}
