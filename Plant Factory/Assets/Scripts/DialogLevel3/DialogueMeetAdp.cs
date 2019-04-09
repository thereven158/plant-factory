using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueMeetAdp: MonoBehaviour
{
    public Dialogue dialogue;

    GameObject getText;
    GameObject adp;
    public Win win;

    void Start()
    {
        adp = GameObject.Find("adp");
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
            win.WinStage();
        }
    }
}
