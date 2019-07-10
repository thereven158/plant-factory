using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectSun3Lvl2 : MonoBehaviour
{
    int counter;
    private string curAmount;
    public Text amount;

    public GameObject quizMenu3;
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
            quizMenu3.SetActive(true);
            Debug.Log(counter);
        }

        
    }

    public void DestroyThis()
    {
        Destroy(this.gameObject);
    }

    public void CollectPlus()
    {
        getText = GameObject.Find("CurrentAmount");
        curAmount = getText.GetComponent<Text>().text;
        counter = int.Parse(curAmount);

        counter++;
        amount.text = counter + "";

        if (counter == 5)
        {
            qManager.DisplayNextQuest();
            adp.GetComponent<DialogueSecondMeetAdp>().enabled = true;
        }
    }
}
