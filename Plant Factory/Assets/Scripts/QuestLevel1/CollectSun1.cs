﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectSun1 : MonoBehaviour
{
    int counter = 0;
    private string curAmount;
    public Text amount;

    GameObject getText;
    GameObject adp;
    public QuestManager qManager;

    void Start()
    {
        adp = GameObject.Find("adp");
    }
    
    private void OnTriggerEnter2D(Collider2D player)
    {
        getText = GameObject.Find("CurrentAmount");
        curAmount = getText.GetComponent<Text>().text;
        counter = int.Parse(curAmount);

        if (player.tag == "Player")
        {
            counter++;
            Debug.Log(counter);
            amount.text = counter + "";
            Destroy(this.gameObject);
        }

        if (counter == 6)
        {
            Debug.Log("yeay");
            qManager.DisplayNextQuest();
            adp.GetComponent<DialogueSecondMeetAdp>().enabled = true;
        }
    }
}
