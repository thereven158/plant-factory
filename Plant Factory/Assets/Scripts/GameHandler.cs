using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameHandler : MonoBehaviour
{
    //Reduce HP/sec
    public float reduceHpRate = 1f;
    float nextReduceHp = 0.0f;

    //Healing Area
    private float healHpRate = 1f;
    float nextHealHp = 0.0f;

    public HealthBar healthBar;
    private HealthSystem healthSystem = new HealthSystem(100);


    //Counter Plus/Minus Button
    public int counter = 0;
    double additionalDamage;

    bool playerTrigger = false;
    public bool outOfHealth = false;

    //SMask
    private SMask sMask;

    //energy
    public float energy;

    //next Level
    public int levelToUnlock;
    public int levelUnlockDark;
    public SceneFader sceneFader;

    //lighting tilemap
    public Tilemap DarkMap;
    public Tilemap BlurredMap;
    public Tilemap Background;
    public Tile DarkTile;
    public Tile BlurredTile;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.Setup(healthSystem);
        sMask = FindObjectOfType<SMask>();

        //lighting tilemap
        DarkMap.origin = BlurredMap.origin = Background.origin;
        DarkMap.size = BlurredMap.size = Background.size;

        foreach (Vector3Int p in DarkMap.cellBounds.allPositionsWithin)
        {
            DarkMap.SetTile(p, DarkTile);
        }

        foreach (Vector3Int p in BlurredMap.cellBounds.allPositionsWithin)
        {
            BlurredMap.SetTile(p, BlurredTile);
        }
    }

    // Update is called once per frame
    void Update()
    {
        CounterVisionButton();

        if (Input.GetKeyDown(KeyCode.KeypadEnter)) WinStage();
    }

    public void ReduceHpPerSec(double addDamage)
    {
        //reduce HP every second
        if (Time.time > nextReduceHp)
        {
            nextReduceHp = Time.time + reduceHpRate;

            if (healthSystem.GetHealth() > 0)
            {
                outOfHealth = false;
                healthSystem.Damaged(addDamage);
                //sMask.ReducePersec();
                //Debug.Log("hp " + healthSystem.GetHealth());
            }

            if (healthSystem.GetHealth() == 0)
            {
                outOfHealth = true;
                counter = 0;
                sMask.OutofHealth();
            }
        }
    }

    public void HealingArea()
    {
        counter = 0;
        sMask.NoOutofHealth();
        //reduce HP every second
        if (Time.time > nextHealHp)
        {
            nextHealHp = Time.time + healHpRate;

            if (healthSystem.GetHealth() < 100)
            {
                healthSystem.Heal(10);
                //Debug.Log("hp " + healthSystem.GetHealth());
            }

            if (healthSystem.GetHealth() > 100)
            {
                healthSystem.Heal(100);
            }
        }
    }

    public void WinStage()
    {
        Debug.Log("Win Level");
        PlayerPrefs.SetInt("lightStageReached", levelToUnlock);
        PlayerPrefs.SetInt("darkStageReached", levelUnlockDark);
        sceneFader.FadeToLevel(levelToUnlock);
    }

    public void CounterVisionButton()
    {
        if (counter < -4) additionalDamage = 0.5;
        if (counter < -3) additionalDamage = 0.6;
        if (counter < -2) additionalDamage = 0.7;
        if (counter < -1) additionalDamage = 0.8;
        if (counter < 0) additionalDamage = 0.9;
        if (counter == 0) additionalDamage = 1;
        if (counter > 1) additionalDamage = 2;
        if (counter > 3) additionalDamage = 3;
        if (counter > 6) additionalDamage = 4;
        if (counter > 9) additionalDamage = 5;

        ReduceHpPerSec(additionalDamage);
        //Debug.Log("Counter" + counter);
        //Debug.Log("GetDamaged" + additionalDamage);
    }

}
