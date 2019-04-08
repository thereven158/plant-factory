using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectEnergi1 : MonoBehaviour
{
    int counter = 0;
    private string curAmount;
    public Text amount;

    GameObject getText;
    GameObject h2o;
    public QuestManager qManager;

    void Start()
    {
        h2o = GameObject.Find("h2o");
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
            h2o.GetComponent<DialogueSecondMeetAdp>().enabled = true;
        }
    }
}
