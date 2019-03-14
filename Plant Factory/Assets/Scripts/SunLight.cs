using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunLight : MonoBehaviour
{
    public GameHandler gM;
    
    bool entered = false;

    private void Update()
    {
        if (entered) gM.HealingArea();
    }

    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.tag == "Player")
        {
            entered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D player)
    {
        if (player.tag == "Player")
        {
            entered = false;

            Debug.Log("Exit trigger");
        }
    }

}
