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
    public Transform ground;

    [Header("Physics")]
    public float speed;
    public float runSpeed;
    public float jumpForce;

    private float _localSpeed;
    private float _horizontalAxes;

    void Update()
    {
        if(!player.isDead)
        {
            _horizontalAxes = Input.GetAxis("Horizontal");

            if(_horizontalAxes == 0)
            {
                _localSpeed = 0;
            }
            else
            {
                if (Input.GetKey(KeyCode.LeftControl))
                {
                    _localSpeed = runSpeed;
                }
                else
                {
                    _localSpeed = speed;
                }
            }

            myRigidbody2D.velocity = new Vector2(_horizontalAxes * _localSpeed, myRigidbody2D.velocity.y);

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
            myRigidbody2D.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (_horizontalAxes < 0)
        {
            myRigidbody2D.transform.localScale = new Vector3(-1, 1, 1);
        }

        anim.SetFloat("XMov", _localSpeed);
    }

    private bool onGround()
    {
        return Physics2D.OverlapCircle(ground.position, .75f, groundLayer);
    }
}
