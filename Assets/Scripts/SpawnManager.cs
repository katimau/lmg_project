using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
      //vedä tähän SpawnManager Unityssa, korjaa spawnPos -tehty
      public GameObject spawnPoint;
    private Vector3 spawnPos = new Vector3(35, 0, 0);

    //startDelay ja repeatRate olivat molemmat 2, mutta kokeillaan näin alkuun
    private float startDelay = 5;
    private float repeatRate = 2;

    private PlayerController playerControllerScript;

    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {

    }

    void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }
}
