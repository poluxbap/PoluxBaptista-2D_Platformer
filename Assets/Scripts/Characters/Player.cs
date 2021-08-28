using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CharacterBase
{
    public Rigidbody2D myRigidbody2D;
    public LayerMask groundLayer;
    public Transform ground;

    [Space]
    [Header("Physics")]
    public float speed;
    public float runSpeed;
    public float jumpForce;

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
                _localSpeed = runSpeed;
            }
            else
            {
                _localSpeed = speed;
            }
        }

        myRigidbody2D.velocity = new Vector2(_horizontalAxes * _localSpeed, myRigidbody2D.velocity.y);

        AnimationStateConfig();

        if (Input.GetKeyDown(KeyCode.UpArrow) && onGround())
        {
            myRigidbody2D.velocity = Vector2.up * jumpForce;
        }

        anim.SetBool("Grounded", onGround());
        anim.SetFloat("Vel", myRigidbody2D.velocity.y);
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
