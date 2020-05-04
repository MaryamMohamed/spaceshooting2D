using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpanwer : MonoBehaviour
{
    public GameObject EnemyGo;

    float maxRateInSec = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnEnemy", maxRateInSec);
        InvokeRepeating("IncreaseSpawnRate", 0f, 30f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //function that create enemy posiotioned on top of edge of screen random
    void SpawnEnemy()
    {
        //find screen limits to enemy movement
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); //bottom left corner
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)); //bottom right corner

        GameObject anEnemy = (GameObject)Instantiate(EnemyGo);
        anEnemy.transform.position = new Vector2 (Random.Range (min.x, max.x), max.y);
        Schedule();
    }

    void Schedule()
    {
        float spawnInSec;

        if (maxRateInSec > 1f)
        {
            spawnInSec = Random.Range(1f, maxRateInSec);

        }
        else
            spawnInSec = 1f;
        Invoke("SpawnEnemy", spawnInSec);
    }

    //icrease defculty function
    void IncreaseSpawnRate()
    {
        if (maxRateInSec > 1f)
            maxRateInSec--;
        if (maxRateInSec == 1f)
            CancelInvoke("IncreaseSpawnRate");
    }
}
