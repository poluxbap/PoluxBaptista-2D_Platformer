using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidbody2D;
    public LayerMask groundLayer;
    public Animator anim;
    public Health player;

    [Header("Physics")]
    public float speed;
    public float runSpeed;
    public float jumpForce;

    private bool _isRunning = false;
    private float _horizontalAxes;
    private bool _isFlipped = false;

    public void Awake()
    {
        _horizontalAxes = Input.GetAxis("Horizontal");
    }

    void Update()
    {
        //FlipChildren();

        _isRunning = Input.GetKey(KeyCode.LeftControl);
        
        if(!player.isDead)
        {
            myRigidbody2D.velocity = new Vector2(_horizontalAxes * (_isRunning ? runSpeed : speed), myRigidbody2D.velocity.y);

            AnimationStateConfig();

            if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && onGround())
            {
                myRigidbody2D.velocity = Vector2.up * jumpForce;
            }

            anim.SetBool("Grounded", onGround());
            anim.SetFloat("Vel", myRigidbody2D.velocity.y);
        }
    }

    private void AnimationStateConfig()
    {
        if (_horizontalAxes > 0)
        {
            _isFlipped = true;
            anim.SetBool(_isRunning ? "Run" : "Walk", true);
        }
        else if (_horizontalAxes < 0)
        {
            _isFlipped = false;
            anim.SetBool(_isRunning ? "Run" : "Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
            anim.SetBool("Run", false);
        }
    }

    private void FlipChildren()
    {
        //for()
        this.GetComponentInChildren<SpriteRenderer>().flipX = _isFlipped;
    }

    private bool onGround()
    {
        return Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y - (transform.localScale.y / 2f)), transform.localScale.x / 2f, groundLayer);
    }
}
