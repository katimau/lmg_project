using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<SpawnInfo> objectsToSpawn;

    private PlayerController playerControllerScript;

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        foreach (SpawnInfo si in objectsToSpawn)
        {
            si.timeToNextSpawn = si.startTime;
        }
    }

    void FixedUpdate()
    {
        if (playerControllerScript.gameOver == false)
        {
            foreach (SpawnInfo si in objectsToSpawn)
            {
                si.timeToNextSpawn -= Time.fixedDeltaTime;
                if (si.timeToNextSpawn <= 0)
                {
                    si.timeToNextSpawn += Random.Range(si.repeatIntervalMin, si.repeatIntervalMax);
                    Instantiate(si.prefab, si.spawnPosition, Quaternion.identity);
                }
            }
        }
    }
}
