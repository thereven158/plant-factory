using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToFotosistem1 : MonoBehaviour
{

    public Win win;
   

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.tag == "Player")
        {
            win.WinStage();
        }
    }
}
