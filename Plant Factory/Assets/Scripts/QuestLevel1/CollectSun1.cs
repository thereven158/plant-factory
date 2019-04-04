using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectSun1 : MonoBehaviour
{
    int counter = 0;
    private string curAmount;
    public Text amount;

    GameObject getText;
        
    void Update()
    {
        if (counter == 6)
        {
            Debug.Log("yeay");
        }
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
    }
}
