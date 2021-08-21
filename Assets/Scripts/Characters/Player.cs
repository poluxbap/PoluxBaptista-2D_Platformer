using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidbody2D;
    public LayerMask groundLayer;
    public Animator anim;

    [Header("Physics")]
    public float speed;
    public float runSpeed;
    public float jumpForce;

    private bool _isRunning = false;

    void Update()
    {
        _isRunning = Input.GetKey(KeyCode.LeftControl);

        myRigidbody2D.velocity = new Vector2(Input.GetAxis("Horizontal") * (_isRunning ? runSpeed : speed), myRigidbody2D.velocity.y);

        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && onGround())
        {
            myRigidbody2D.velocity = Vector2.up * jumpForce;
        }

        anim.SetBool("grounded", onGround());
        anim.SetFloat("vel", myRigidbody2D.velocity.y);
    }

    private bool onGround()
    {
        return Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y - (transform.localScale.y / 2f)), transform.localScale.x / 2f, groundLayer);
    }
}
