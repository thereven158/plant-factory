using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueFirstMeetH2o : MonoBehaviour
{

    public Dialogue dialogue;
    public QuestManager qManager;

    GameObject h2o;

    void Start()
    {
        h2o = GameObject.Find("h2o");
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    void OnTriggerEnter2D(Collider2D player)
    {
        if (!gameObject.GetComponent<DialogueFirstMeetH2o>().enabled)
        {
            return;
        }

        if (player.tag == "Player")
        {
            Debug.Log("Enter Trigger Dialogue");
            qManager.DisplayNextQuest();
            TriggerDialogue();
            h2o.GetComponent<DialogueFirstMeetH2o>().enabled = false;
        }
    }
}
