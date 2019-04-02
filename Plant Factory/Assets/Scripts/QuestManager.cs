using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{

    private Queue<string> sentences;

    public Text questText;
    public GameObject questBox;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        questBox = GameObject.Find("QuestBox");
    }

    void Update()
    {
        Debug.Log("Quest Count : " + sentences.Count);
    }

    public void StartQuest(Quest quest)
    {
        Debug.Log("Start conversation");

        sentences.Clear();

        foreach (string sentence in quest.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextQuest();
    }

    public void DisplayNextQuest()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        Debug.Log(sentence);
        //dialogueText.text = sentence;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        questText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            questText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        Debug.Log("End Quest");
    }
}
