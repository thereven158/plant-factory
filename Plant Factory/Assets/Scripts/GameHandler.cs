using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public float reduceHpRate = 1f;
    float nextReduceHp = 0.0f;

    public HealthBar healthBar;
    private HealthSystem healthSystem = new HealthSystem(100);
    private int currentHp = 100;

    // Start is called before the first frame update
    void Start()
    {
        

        healthBar.Setup(healthSystem);
    }

    // Update is called once per frame
    void Update()
    {
        //reduce HP every second
        if (Time.time > nextReduceHp)
        {
            nextReduceHp = Time.time + reduceHpRate;

            if (currentHp > 0)
            {
                currentHp -= 1;
                healthSystem.Damaged(1);
            }

            if (currentHp == 0)
            {
                currentHp = 100;
                healthSystem.Heal(100);
            }
        }
    }
}
