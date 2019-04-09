using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueFirstMeetNadp : MonoBehaviour
{

    public Dialogue dialogue;
    public QuestManager qManager;

    GameObject adp, collectUI;

    void Start()
    {
        adp = GameObject.Find("adp");
        collectUI = GameObject.Find("CollectEnergy");
        collectUI.SetActive(false);
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
            collectUI.SetActive(true);
            adp.GetComponent<DialogueFirstMeetAdp>().enabled = false;
        }
    }
}
