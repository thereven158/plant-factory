using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rB;
    GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        rB.velocity = transform.right * speed;
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    private void OnTriggerEnter2D(Collider2D enemyTag)
    {
        
        if(enemyTag.tag == "Enemy")
        {
            Destroy(gameObject);
            Destroy(enemy);
        }
    }
}
