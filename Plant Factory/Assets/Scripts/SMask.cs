using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMask : MonoBehaviour
{

    [Range(0.05f, 0.2f)]
    public float flickTime;

    [Range(0.02f, 0.09f)]
    public float addSize;

    public Transform target;

    private float timer;
    private bool bigger;
    
    //Reduce vision/sec
    public float reduceRate = 1f;
    float nextReduce = 0.0f;

    //GameHandler
    public GameHandler gameHandler;

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > flickTime)
        {
            if(bigger)
            {
                transform.localScale = new Vector3(transform.localScale.x + addSize,
                                           transform.localScale.y + addSize,
                                           transform.localScale.z);
            }
            else
            {
                transform.localScale = new Vector3(transform.localScale.x - addSize,
                                           transform.localScale.y - addSize,
                                           transform.localScale.z);
            }

            timer = 0;
            bigger = !bigger;
        }

        transform.position = Vector3.MoveTowards(transform.position, target.position, 20 * Time.deltaTime);

        
    }

    //add vision when button + pressed
    public void AddVision ()
    {
        if (gameHandler.outOfHealth == false)
        {
            if (gameHandler.counter == 10)
            {
                gameHandler.counter = 10;
                Debug.Log("Maxed zoom out");
            }
            if (gameHandler.counter <= 10)
            {
                gameHandler.counter += 1;
                transform.localScale = new Vector3(transform.localScale.x + 0.1f,
                                               transform.localScale.y + 0.1f,
                                               transform.localScale.z);
            }
        }
               
    }

    //reduce vision when button - pressed
    public void ReduceVision()
    {
        if (gameHandler.outOfHealth == false)
        {
            if (gameHandler.counter == -5)
            {
                gameHandler.counter = -5;
                Debug.Log("Maxed zoom in");
            }

            if (gameHandler.counter >= -5)
            {
                gameHandler.counter -= 1;
                transform.localScale = new Vector3(transform.localScale.x - 0.1f,
                                                   transform.localScale.y - 0.1f,
                                                   transform.localScale.z);
            }
        }
        
            
    }

    /*public void ReducePersec()
    {
        transform.localScale = new Vector3(transform.localScale.x - 0.01f,
                                           transform.localScale.y - 0.01f,
                                           transform.localScale.z);
    }*/

    public void OutofHealth()
    {
        transform.localScale = new Vector3(0.3f, 0.3f, 0);
    }

    public void NoOutofHealth()
    {
        transform.localScale = new Vector3(1f, 1f, 0);
    }
}
