using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizHandler : MonoBehaviour
{

    //Collect1
    public GameObject quizMenu1;
    public GameObject sun1;
    CollectSun1 colSun1;

    //Collect2
    public GameObject quizMenu2;
    public GameObject sun2;
    CollectSun2 colSun2;

    //Collect3
    public GameObject quizMenu3;
    public GameObject sun3;
    CollectSun3 colSun3;

    // Start is called before the first frame update
    void Start()
    {
        colSun1 = sun1.GetComponent<CollectSun1>();
        colSun2 = sun2.GetComponent<CollectSun2>();
        colSun3 = sun3.GetComponent<CollectSun3>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Correct1()
    {
        quizMenu1.SetActive(false);
        colSun1.CollectPlus();
        colSun1.DestroyThis();
    }

    public void Wrong1()
    {
        quizMenu1.SetActive(false);
    }

    public void Correct2()
    {
        quizMenu2.SetActive(false);
        colSun2.CollectPlus();
        colSun2.DestroyThis();
    }

    public void Wrong2()
    {
        quizMenu2.SetActive(false);
    }

    public void Correct3()
    {
        quizMenu3.SetActive(false);
        colSun3.CollectPlus();
        colSun3.DestroyThis();
    }

    public void Wrong3()
    {
        quizMenu3.SetActive(false);
    }
}
