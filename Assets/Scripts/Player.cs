using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidbody2D;

    [Header("Physics")]
    public float speed;
    public Vector2 friction = new Vector2(.1f, 0);
    public float jumpForce;

    void Update()
    {
        MovemenntX();
        MovementY();
    }

    public void MovemenntX()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            myRigidbody2D.velocity = new Vector2(speed, myRigidbody2D.velocity.y);
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            myRigidbody2D.velocity = new Vector2(-speed, myRigidbody2D.velocity.y);
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
        }
    }
}
