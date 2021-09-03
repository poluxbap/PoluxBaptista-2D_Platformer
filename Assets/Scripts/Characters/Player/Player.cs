using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CharacterBase
{
    public Rigidbody2D myRigidbody2D;
    public LayerMask groundLayer;
    public Transform ground;

    private float _localSpeed;
    private float _horizontalAxes;

    private void Awake()
    {
        ground = transform.GetChild(1);
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (isDead) return;

        _horizontalAxes = Input.GetAxis("Horizontal");

        if(_horizontalAxes == 0)
        {
            _localSpeed = 0;
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftControl))
            {
                _localSpeed = charInfo.runSpeed;
            }
            else
            {
                _localSpeed = charInfo.speed;
            }
        }

        myRigidbody2D.velocity = new Vector2(_horizontalAxes * _localSpeed, myRigidbody2D.velocity.y);

        AnimationStateConfig();

        if (Input.GetKeyDown(KeyCode.UpArrow) && onGround())
        {
            if(items.powerjump > 0)
            {
                myRigidbody2D.velocity = Vector2.up * charInfo.powerJumpForce;
                items.powerjump--;
            }
            else
            {
                myRigidbody2D.velocity = Vector2.up * charInfo.jumpForce;
            }
        }

        anim.SetBool("Grounded", onGround());
        anim.SetFloat("YMov", myRigidbody2D.velocity.y);
    }

    private void AnimationStateConfig()
    {
        if(_horizontalAxes != 0)
        {
            var direction = Mathf.Sign(_horizontalAxes);
            myRigidbody2D.transform.localScale = new Vector3(direction, 1, 1);
        }

        anim.SetFloat("XMov", _localSpeed);
    }

    private bool onGround()
    {
        return Physics2D.OverlapCircle(ground.position, .75f, groundLayer);
    }
}
