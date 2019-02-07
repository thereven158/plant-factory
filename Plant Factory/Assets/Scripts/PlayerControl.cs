using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public float speedX;
    public float jumpSpeed;
    bool facingRight, jumping;
    float speed;

    Rigidbody2D rb;

     private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        facingRight = true;
        jumping = false;
    }

    // Update is called once per frame
    void Update ()
    {
        //Player Movement
        PlayerMove(speed);

        //Left Player Move
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            speed = -speedX;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            speed = 0;
        }

        //Right Player Move
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            speed = speedX;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            speed = 0;
        }

        //Jumping
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            jumping = true;
            rb.AddForce(new Vector2(rb.velocity.x, jumpSpeed));
        }
    }

    void PlayerMove (float playerSpeed)
    {
        rb.velocity = new Vector3 (speed, rb.velocity.y, 0);
    }

    public void WalkLeft ()
    {
        speed = -speedX;
    }

    public void WalkRight()
    {
        speed = speedX;
    }

    public void StopMoving ()
    {
        speed = 0;
    }

    public void Jumping ()
    {
        rb.AddForce(new Vector2(rb.velocity.x, jumpSpeed));
    }
}
