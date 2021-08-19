using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidbody2D;

    [Header("Physics")]
    public float speed;
    public float runSpeed;
    public Vector2 friction = new Vector2(.1f, 0);
    public float jumpForce;

    [Header("Animation jump")]
    public float jumpScaleX = .7f;
    public float jumpScaleY = 1.5f;
    public float jumpAnimationDuration = .3f;
    public Ease jumpEase = Ease.OutBack;

    [Header("Animation land")]
    public float landScaleX = 1.5f;
    public float landScaleY = .7f;
    public float landAnimationDuration = .3f;
    public Ease landEase = Ease.OutBack;

    private bool _isRunning = false;

    void Update()
    {
        MovemenntX();
        MovementY();
    }

    public void MovemenntX()
    {
        _isRunning = Input.GetKey(KeyCode.LeftControl);

        if(Input.GetKey(KeyCode.RightArrow))
        {
            myRigidbody2D.velocity = new Vector2(_isRunning ? runSpeed : speed, myRigidbody2D.velocity.y);
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            myRigidbody2D.velocity = new Vector2(_isRunning ? -runSpeed : -speed, myRigidbody2D.velocity.y);
        }

        if(myRigidbody2D.velocity.x > 0)
        {
            myRigidbody2D.velocity -= friction;
        }
        else if(myRigidbody2D.velocity.x < 0)
        {
            myRigidbody2D.velocity += friction;
        }
    }

    public void MovementY()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
        {
            myRigidbody2D.velocity = Vector2.up * jumpForce;
            myRigidbody2D.transform.localScale = Vector2.one;
            DOTween.Kill(myRigidbody2D.transform);
            HadleJumpAnimation();
        }

    }

    public void HadleJumpAnimation()
    {
        myRigidbody2D.transform.DOScaleX(jumpScaleX, jumpAnimationDuration).SetLoops(2, LoopType.Yoyo).SetEase(jumpEase);
        myRigidbody2D.transform.DOScaleY(jumpScaleY, jumpAnimationDuration).SetLoops(2, LoopType.Yoyo).SetEase(jumpEase);
    }
}
