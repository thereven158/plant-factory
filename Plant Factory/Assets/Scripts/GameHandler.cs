using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameHandler : MonoBehaviour
{
    //Reduce HP/sec
    public float reduceHpRate = 1f;
    float nextReduceHp = 0.0f;

    public HealthBar healthBar;
    private HealthSystem healthSystem = new HealthSystem(100);
    private int currentHp = 100;

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
