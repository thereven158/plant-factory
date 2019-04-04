using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger : MonoBehaviour
{

    public Quest quest;

    private void Start()
    {
        Invoke("TriggerQuest", 1);
    }

    public void TriggerQuest()
    {
        FindObjectOfType<QuestManager>().StartQuest(quest);
    }

}