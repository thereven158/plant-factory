using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueMeetNADP : MonoBehaviour
{
    public Dialogue dialogue;

    GameObject getText;
    GameObject nadp;
    //public Win win;

    void Start()
    {
        nadp = GameObject.Find("nadpPlus");
        getText = GameObject.Find("CurrentAmount");
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    void OnTriggerEnter2D(Collider2D player)
    {
        
        if (player.tag == "Player")
        {
            TriggerDialogue();
            FindObjectOfType<DialogueManager>().lastDialog = true;
            //win.WinStage();
        }
    }
}
