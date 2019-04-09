using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public float speedX;
    public float jumpSpeed;
    bool facingRight, jumping;

    float speed;
    
    AudioSource audioSource;
    
    Rigidbody2D rb;

    Transform playerTrans;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        facingRight = false;
        jumping = false;
        playerTrans = this.transform;
    }

    // Update is called once per frame
    void Update ()
    {
        //Player Movement using arrow
        PlayerMove(speed);

               
        //Left Player Move
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            speed = -speedX;
            facingRight = false;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            speed = 0;
        }

        //Right Player Move
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            speed = speedX;
            facingRight = true;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            speed = 0;
        }

        if (facingRight == false)
        {
            Vector3 currentRot = playerTrans.eulerAngles;
            currentRot.y = 0;
            playerTrans.eulerAngles = currentRot;
        }

        if (facingRight == true)
        {
            Vector3 currentRot = playerTrans.eulerAngles;
            currentRot.y = 180;
            playerTrans.eulerAngles = currentRot;
        }

        //Jumping
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            jumping = true;
            audioSource.Play();
            rb.AddForce(new Vector2(rb.velocity.x, jumpSpeed));
        }
    }

    void PlayerMove (float playerSpeed)
    {
        rb.velocity = new Vector3 (speed, rb.velocity.y, 0);
    }

    //Player movement using button
    public void WalkLeft ()
    {
        speed = -speedX;
        facingRight = false;
    }

    public void WalkRight()
    {
        speed = speedX;
        facingRight = true;
    }

    public void StopMoving ()
    {
        speed = 0;
    }

    public void Jumping ()
    {
        audioSource.Play();
        rb.AddForce(new Vector2(rb.velocity.x, jumpSpeed));
    }
    
}
