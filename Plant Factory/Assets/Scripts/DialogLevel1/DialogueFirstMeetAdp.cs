﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueFirstMeetAdp : MonoBehaviour
{

    public Dialogue dialogue;
    public QuestManager qManager;

    GameObject adp;

    void Start()
    {
        adp = GameObject.Find("adp");
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    void OnTriggerEnter2D(Collider2D player)
    {
        if (!gameObject.GetComponent<DialogueFirstMeetAdp>().enabled)
        {
            return;
        }

        if (player.tag == "Player")
        {
            Debug.Log("Enter Trigger Dialogue");
            qManager.DisplayNextQuest();
            TriggerDialogue();
            adp.GetComponent<DialogueFirstMeetAdp>().enabled = false;
        }
    }
}
