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

    public void AddVision ()
    {
        transform.localScale = new Vector3(transform.localScale.x + 0.1f,
                                           transform.localScale.y + 0.1f,
                                           transform.localScale.z);
    }

    public void ReduceVision()
    {
        transform.localScale = new Vector3(transform.localScale.x - 0.1f,
                                           transform.localScale.y - 0.1f,
                                           transform.localScale.z);
    }
}
