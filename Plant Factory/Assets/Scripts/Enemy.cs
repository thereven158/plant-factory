using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public LayerMask enemyMask;
    public float speed;
    Rigidbody2D enemyRb;
    Transform enemyTrans;
    float enemyWidth, enemyHeight;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = this.GetComponent<Rigidbody2D>();
        enemyTrans = this.transform;
        SpriteRenderer enemySprite = this.GetComponent<SpriteRenderer>();
        enemyWidth = enemySprite.bounds.extents.x;
        enemyHeight = enemySprite.bounds.extents.y;
    }

    
    void FixedUpdate()
    {
        //Check to see if there's ground in front of us before moving forward
        Vector2 lineCastPos = enemyTrans.position.toVector2() - enemyTrans.right.toVector2() * enemyWidth;
        Debug.DrawLine(lineCastPos, lineCastPos + Vector2.down);
        Debug.DrawLine(lineCastPos, lineCastPos - enemyTrans.right.toVector2() * .02f);
        bool isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.down, enemyMask);
        bool isBlocked = Physics2D.Linecast(lineCastPos, lineCastPos - enemyTrans.right.toVector2() * .02f, enemyMask);

        //if there no ground, turn around or if it's blocked, turn around
        if (!isGrounded || isBlocked)
        {
            Vector3 currentRot = enemyTrans.eulerAngles;
            currentRot.y += 180;
            enemyTrans.eulerAngles = currentRot;
        }

        //always move forward
        Vector2 enemyVelocity = enemyRb.velocity;
        enemyVelocity.x = -enemyTrans.right.x * speed;
        enemyRb.velocity = enemyVelocity;
    }

    private void OnTriggerEnter2D(Collider2D playerTag)
    {

        if (playerTag.tag == "Player")
        {
            Destroy(gameObject);

        }
    }
}
